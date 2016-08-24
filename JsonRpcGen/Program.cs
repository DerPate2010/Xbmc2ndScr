

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JsonRpcGen.ParameterHandler;
using JsonRpcGen.TypeHandler;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;



namespace JsonRpcGen
{
    class Program
    {
        public const string PRAGMA = "#pragma warning disable CS0108";

        static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { "http://localhost:8080/jsonrpc", "kodi", "kodi", "XBMCRPC" };
#endif
            Global.TargetDir = new DirectoryInfo(@"..\..\..\XBMCRPC13.Portable\" + args[3]);
            if (Global.TargetDir.Exists)
            {
                Global.TargetDir.Delete(true);
            }
            Global.BaseNamespace = args[3];

            var schemaTask = GetSchema(args[0], args[1], args[2]);
            try
            {
                schemaTask.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot read JSON scheme! Kodi not running?");
                Console.WriteLine("Error: {0}", e.Message);
                Console.Write("Hit RETURN to continue:");
                Console.ReadLine();
                return;
            }
            var schema = schemaTask.Result;
            //JObject schema = JObject.Parse(File.ReadAllText(@"..\..\kodi16.json"));

            var types = schema["result"]["types"];
            var methods = schema["result"]["methods"];
            var notifications = schema["result"]["notifications"];

            // MAM: we also save the API Version we have received from Kodi as a String Constant in our Namespace
            var version = schema["result"]["version"];

            CollectTypes(types);

            foreach (var type in Global.TypeMap.GetEnumerable())
            {

                var nestedTypes =
                    Global.TypeMap.GetEnumerable().Where(t => t.TypeHandler.LocalNamespace == type.TypeHandler.Fullname);
                if (nestedTypes.Any())
                {

                }
            }

            string notificationInvoker;

            var methodClasses = GenMethods(methods, notifications, out notificationInvoker);

            WriteTypes();

            CopyBaseClases(methodClasses, notificationInvoker);

            // MAM: save the API Version so that the User of the Lib can read it and act upon it
            GenVersion(version.ToString());
        }

        private static void WriteTypes()
        {
            foreach (var typeReference in Global.TypeMap.GetEnumerable())
            {
                if (typeReference.TypeHandler.IsBuiltIn)
                {
                    continue;
                }
                if (typeReference.TypeHandler.IsNestedClass)
                {
                    continue;
                }

                var parts = typeReference.TypeHandler.Namespace.Split('.');
                var subPath = Path.Combine(parts.ToArray());
                var path = Path.Combine(Global.TargetDir.FullName, subPath);

                var classDir = new DirectoryInfo(path);
                if (!classDir.Exists)
                {
                    classDir.Create();
                }

                var classFile = new FileInfo(Path.Combine(path, typeReference.TypeHandler.Name + ".cs"));
                TextWriter writer = new StreamWriter(classFile.Open(FileMode.Create, FileAccess.Write));

                WriteUsings(writer);

                writer.WriteLine("namespace " + typeReference.TypeHandler.Namespace);
                writer.WriteLine("{");
                typeReference.TypeHandler.WriteDefinition(writer);
                writer.WriteLine("}");

                writer.Close();
            }
        }

        private static void WriteUsings(TextWriter writer)
        {
            writer.WriteLine("using System;");
            writer.WriteLine("using System.Collections.Generic;");
            writer.WriteLine("using System.Linq;");
            writer.WriteLine("using Newtonsoft.Json.Linq;");
            writer.WriteLine("using System.Runtime.Serialization;");
            // MAM: get rid of this annoying warning created by KODI
            writer.WriteLine(PRAGMA);
            writer.WriteLine("");
        }

        private static void CollectTypes(JToken types)
        {
            foreach (JProperty type in types)
            {
                Global.TypeMap.GetOrAddType(type);
            }
        }

        private static void CopyBaseClases(List<string> methodClasses, string notificationInvoker)
        {
            File.Copy("Templates\\IPlatformServices.templ", Path.Combine(Global.TargetDir.FullName, "IPlatformServices.cs"), true);
            File.Copy("Templates\\ISocket.templ", Path.Combine(Global.TargetDir.FullName, "ISocket.cs"), true);
            File.Copy("Templates\\ISocketFactory.templ", Path.Combine(Global.TargetDir.FullName, "ISocketFactory.cs"), true);
            File.Copy("Templates\\NotificationListenerSocketState.templ", Path.Combine(Global.TargetDir.FullName, "NotificationListenerSocketState.cs"), true);
            File.Copy("Templates\\ConnectionSettings.templ", Path.Combine(Global.TargetDir.FullName, "ConnectionSettings.cs"), true);

            var client = File.ReadAllText("Templates\\Client.templ");
            var methodsPropertiesList = methodClasses.Select(m => "        public Methods." + m + " " + m + " { get; private set; }");
            var methodProperties = string.Join(Environment.NewLine, methodsPropertiesList);
            client = client.Replace("%json_methods_properties%", methodProperties);
            var methodsInitList = methodClasses.Select(m => "           " + m + " = new Methods." + m + "(this);");
            var methodInits = string.Join(Environment.NewLine, methodsInitList);
            client = client.Replace("%json_methods_init%", methodInits);
            client = client.Replace("%notification_invoker%", notificationInvoker);
            File.WriteAllText(Path.Combine(Global.TargetDir.FullName, "Client.cs"), client);
        }

        async static internal Task<JObject> GetSchema(string address, string user, string password)
        {
            var request = WebRequest.Create(address);
            request.Credentials = new NetworkCredential(user, password);
            request.ContentType = "application/json";
            request.Method = "POST";
            var postStream = await request.GetRequestStreamAsync();

            var jsonPost = new JObject { new JProperty("jsonrpc", "2.0"), new JProperty("method", "JSONRPC.Introspect"), new JProperty("id", 1) };
            var jsonRequest = jsonPost.ToString();
            byte[] postData = Encoding.UTF8.GetBytes(jsonRequest);
            postStream.Write(postData, 0, postData.Length);
            postStream.Dispose();

            var response = await request.GetResponseAsync();
            var responseStream = response.GetResponseStream();
            string responseData = null;
            if (responseStream != null)
            {
                var streamReader = new StreamReader(responseStream);
                responseData = streamReader.ReadToEnd();
                responseStream.Dispose();
                streamReader.Dispose();
            }

            response.Close();

            JObject query = JObject.Parse(responseData);
            return query;
        }

        /// <summary>
        /// Generate Methods for each JSON callable function that we have found in the KODI list
        /// </summary>
        /// <param name="methods"></param>
        /// <param name="notifications"></param>
        /// <param name="notificationInvoke"></param>
        /// <returns></returns>
        private static List<string> GenMethods(JToken methods, JToken notifications, out string notificationInvoke)
        {
            notificationInvoke = null;
            var path = Path.Combine(Global.TargetDir.FullName, "Methods");
            var methodDir = new DirectoryInfo(path);
            if (methodDir.Exists)
            {
                methodDir.Delete(true);
            }
            methodDir.Create();
            var writer3 = new StringWriter();

            var multiMethods = new List<string>();

            foreach (JProperty method in methods)
            {
                var parts = method.Name.Split('.');
                var namesp = Global.BaseNamespace + ".Methods";
                var className = parts[0];
                var methodName = parts[1];
                var classFile = new FileInfo(Path.Combine(path, className + ".cs"));
                if (!classFile.Exists)
                {
                    var writer = new StreamWriter(classFile.Open(FileMode.Create, FileAccess.Write));
                    writer.WriteLine("using System;");
                    writer.WriteLine("using System.Threading.Tasks;");
                    writer.WriteLine("using Newtonsoft.Json.Linq;");
                    writer.WriteLine(PRAGMA);
                    writer.WriteLine("");
                    writer.WriteLine("namespace " + namesp);
                    writer.WriteLine("{");
                    writer.WriteLine("   public partial class " + className);
                    writer.WriteLine("   {");
                    writer.WriteLine("        private readonly Client _client;");
                    writer.WriteLine("          public " + className + "(Client client)");
                    writer.WriteLine("          {");
                    writer.WriteLine("              _client = client;");
                    writer.WriteLine("          }");
                    writer.Close();
                }

                var retType = GetReturnType(method, className + "." + methodName);
                var parameters = GetParams(method, className + "." + methodName).ToList();

                var overloads = new List<List<ParamTypeHandler>>();
                var dim = parameters.Count(p => p.Type.TypeHandler is MultiTypeHandler);
                if (dim > 1)
                {
                    multiMethods.Add(methodName + " - " + dim);
                }
                var overloadParam = parameters.FirstOrDefault(p => p.Type.TypeHandler is MultiTypeHandler);
                if (overloadParam == null)
                {
                    overloads.Add(parameters);
                }
                else
                {
                    var indexToReplace = parameters.IndexOf(overloadParam);
                    AddOverloads(overloadParam, parameters, indexToReplace, overloads);

                    var overload = new List<ParamTypeHandler>(parameters);
                    overload.RemoveAt(indexToReplace);
                    overloads.Add(overload);
                }

                foreach (var overload in overloads)
                {
                    //var parameter = parameters.ElementAt(i);
                    //parameters.SetOverload(i);
                    //retType.SetOverload(i);

                    // MAM: we often encountered a sharing violation here, so we try to relax the thing a bit
                    var writer2 = new StreamWriter(classFile.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite));
                    // MAM: set Autoflush, so every line is written out instantly
                    writer2.AutoFlush = true;

                    //retType.WriteType(writer2, replacements);
                    //parameters.WriteTypes(writer2, replacements);
                    writer2.WriteLine();
                    var description = method.First["description"];
                    if (description != null)
                    {
                        writer2.WriteLine("                /// <summary>");
                        writer2.Write("                /// ");
                        writer2.WriteLine(description.ToString());
                        writer2.WriteLine("                /// </summary>");

                        foreach (var p in overload)
                        {
                            writer2.Write("                /// <param name=\"{0}\"> {1}",p.Name,p.Required?"REQUIRED ":"");
                            if (p.Description != null)
                            {
                                writer2.Write("{0}", p.Description);
                            }
                            writer2.WriteLine("</param>");
                        }
                        writer2.WriteLine("                /// <returns>{0}</returns>", retType.TypeHandler.NetType);

                    }
                    writer2.Write("        public async Task<");
                    writer2.Write(retType.TypeHandler.NetType);
                    writer2.Write("> ");
                    writer2.Write(methodName);
                    writer2.Write("(");
                    writer2.Write(GetParameterList(overload));
                    writer2.Write("");
                    writer2.WriteLine(")");
                    writer2.WriteLine("        {");

                    // MAM: later! no need for constructor if we have a quickexit situation
                    // writer2.WriteLine("            var jArgs = new JObject();");

                    // MAM: check if first argument is numeric
                    var first = true; // MAM 230816
                    var NoParameter = true; // MAM: if we have no Paramter to send at all, dont add jArgs to the wait call!

                    foreach (var pname in overload)
                    {
                        NoParameter = false;
                        // MAM: fast exit if first argument is not given
                        if (first == true)
                        {
                            first = false; // MAM: only one time for each Method only please!
                            string FirstType = pname.Type.TypeHandler.NetType.ToString();
                            if (FirstType == "int")
                            {
                                writer2.WriteLine("             if (" + pname.Name + " == 0 )");
                                writer2.WriteLine("             {");
                                switch (retType.Name)
                                {
                                    case "integer":
                                        writer2.WriteLine("                 return 0;"); break;
                                    case "bool":
                                        writer2.WriteLine("                 return false;"); break;
                                    case "double":
                                        writer2.WriteLine("                 return 0;"); break;
                                    default:
                                        writer2.WriteLine("                 return null;"); break;
                                }
                                writer2.WriteLine("              }");
                                writer2.WriteLine("");
                            }
                            writer2.WriteLine("            var jArgs = new JObject();");
                            writer2.WriteLine("");
                        }

                        // MAM: only check, if parameter is optional!
                        if (pname.Required == false)
                        {
                            string FirstType = pname.Type.TypeHandler.NetType.ToString();
                            switch (FirstType)
                            {
                                case "integer":
                                    writer2.WriteLine("             if (" + pname.Name + " != 0)");
                                    break;
                                case "string":
                                    writer2.WriteLine("             if (" + pname.Name + " != null)");
                                    break;
                                case "bool": // MAM: bool are always to be send, no matter of their value
                                    break;
                                default:
                                    writer2.WriteLine("             if (" + pname.Name + " != null)");
                                    break;
                            }
                        }

                        writer2.WriteLine("             {");
                        writer2.WriteLine("                 var jprop" + pname.Name + " = JToken.FromObject(" + pname.Name + ", _client.Serializer);");
                        writer2.WriteLine("                 jArgs.Add(new JProperty(\"" + pname.OriginalName + "\", jprop" + pname.Name + "));");
                        writer2.WriteLine("             }");

                    }
                    if (NoParameter == false)
                    {
                        writer2.WriteLine("            return await _client.GetData<" + retType.TypeHandler.NetType + ">(\"" + method.Name + "\", jArgs);");
                    }
                    else
                    {
                        writer2.WriteLine("            return await _client.GetData<" + retType.TypeHandler.NetType + ">(\"" + method.Name + "\",null);");
                    }
                    writer2.WriteLine("        }");

                    writer2.Close();
                }
            }

            foreach (JProperty notification in notifications)
            {
                var parts = notification.Name.Split('.');
                var className = parts[0];
                var methodName = parts[1];
                var classFile = new FileInfo(Path.Combine(path, className + ".cs"));

                var parameters = GetParams(notification, className + "." + methodName);
                //var retType = GetReturnHandler(notification, replacements);
                //for (int i = 0; i < parameters.GetOverloadCount(); i++)
                {
                    //parameters.SetOverload(i);
                    //retType.SetOverload(i);
                    var writer2 = new StreamWriter(classFile.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite));
                    writer2.AutoFlush = true;
                    //retType.WriteType(writer2, replacements);
                    //parameters.WriteTypes(writer2, replacements);
                    writer2.WriteLine();
                    writer2.Write("        public delegate void ");
                    writer2.Write(methodName);
                    //if (i > 0)
                    //{
                    //    writer2.Write("2");
                    //}
                    writer2.Write("Delegate(");
                    writer2.Write(GetParameterList(parameters));
                    writer2.Write("");
                    writer2.WriteLine(");");
                    writer2.Write("        public event ");
                    writer2.Write(methodName);
                    //if (i > 0)
                    //{
                    //    writer2.Write("2");
                    //}
                    writer2.Write("Delegate ");
                    writer2.Write(methodName);
                    //if (i > 0)
                    //{
                    //    writer2.Write("2");
                    //}
                    writer2.WriteLine(";");
                    writer2.Write("        internal void Raise");
                    writer2.Write(methodName);
                    //if (i > 0)
                    //{
                    //    writer2.Write("2");
                    //}
                    writer2.Write("(");
                    writer2.Write(GetParameterList(parameters));
                    writer2.Write("");
                    writer2.WriteLine(")");
                    writer2.WriteLine("        {");
                    writer2.Write("            if (");
                    writer2.Write(methodName);
                    //if (i > 0)
                    //{
                    //    writer2.Write("2");
                    //}
                    writer2.WriteLine(" != null)");
                    writer2.WriteLine("            {");
                    writer2.Write("                ");
                    writer2.Write(methodName);
                    //if (i > 0)
                    //{
                    //    writer2.Write("2");
                    //}
                    writer2.Write(".BeginInvoke(");
                    writer2.Write(string.Join(", ", parameters.Select(p => p.Name)));
                    writer2.WriteLine(", null, null);");
                    writer2.WriteLine("            }");
                    writer2.WriteLine("        }");

                    writer2.Close();

                    writer3.Write("        case \"");
                    writer3.Write(className);
                    writer3.Write(".");
                    writer3.Write(methodName);
                    writer3.WriteLine("\":");



                    writer3.Write("            ");
                    writer3.Write(className);
                    writer3.Write(".Raise");
                    writer3.Write(methodName);
                    writer3.WriteLine("(");
                    var first = true;
                    foreach (var paramHandler in parameters)
                    {
                        if (first)
                        {
                            first = false;
                        }
                        else
                        {
                            writer3.Write(", ");
                        }
                        writer3.Write("jObject[\"params\"][\"");
                        writer3.Write(paramHandler.OriginalName);
                        writer3.Write("\"].ToObject<");
                        //if (paramHandler.Type.Contains(methodName))
                        //{
                        //    writer3.Write("Methods.");
                        //    writer3.Write(className);
                        //    writer3.Write(".");
                        //}
                        writer3.Write(paramHandler.Type.TypeHandler.NetType);
                        writer3.WriteLine(">(Serializer)");
                    }
                    writer3.WriteLine(");");
                    writer3.WriteLine("            break;");
                }
            }

            foreach (var classFile in methodDir.GetFiles())
            {
                var writer = new StreamWriter(classFile.Open(FileMode.Append, FileAccess.Write));
                writer.WriteLine("   }");
                writer.WriteLine("}");
                writer.Close();
            }
            notificationInvoke = writer3.ToString();
            return methodDir.GetFiles().Select(f => Path.GetFileNameWithoutExtension(f.Name)).ToList();
        }

        private static void AddOverloads(ParamTypeHandler overloadParam, List<ParamTypeHandler> parameters, int indexToReplace, List<List<ParamTypeHandler>> overloads)
        {
            var multiTypeHandler = ((MultiTypeHandler)overloadParam.Type.TypeHandler);
            foreach (var type in multiTypeHandler.TypeHandlers)
            {
                if (type.TypeHandler is MultiTypeHandler)
                {
                    AddOverloads(new ParamTypeHandler(type, overloadParam.Name,overloadParam.Required,overloadParam.Description, true), parameters, indexToReplace, overloads);
                }
                else
                {
                    var overload = new List<ParamTypeHandler>(parameters);
                    overload.RemoveAt(indexToReplace);
                    overload.Insert(indexToReplace, new ParamTypeHandler(type, overloadParam.Name, overloadParam.Required, overloadParam.Description, false));
                    overloads.Add(overload);
                }
            }
        }

        private static string GetParameterList(IEnumerable<ParamTypeHandler> parameters)
        {
            // var orderedParameters = parameters; ; //.OrderByDescending(p => string.IsNullOrEmpty(p.GetDefault())).ToList();
            // return string.Join(", ", orderedParameters.Where(p => p.Type.TypeHandler.NetType != null).Select(p => p.Type.TypeHandler.NetType + " " + p.Name + p.GetDefault()));
            string Result = "";
            int i;
            var p = parameters.GetEnumerator();

            for (i = 0; i < parameters.Count(); i++)
            {
                p.MoveNext();

                if (i > 0)
                {
                    Result += ", ";
                }
                Result += (p.Current.Type.TypeHandler.NetType);
                if (p.Current.IsNullable || p.Current.Type.TypeHandler.IsEnum)
                {
                    Result += "?";
                }
                Result += " ";
                Result += p.Current.Name;
                Result += p.Current.GetDefault();
            }
            return Result;
        }

        private static IEnumerable<ParamTypeHandler> GetParams(JProperty method, string typePrefix)
        {
            List<ParamTypeHandler> paramHAndlers = new List<ParamTypeHandler>();

            var parameters = method.First["params"];
            foreach (JObject parameter in parameters)
            {
                var name = parameter["name"].ToString();

                // MAM: read and save the "required" attribute. Never generate an optional Parameter for this!
                bool req = false;
                string Description = "";

                if (parameter["required"] != null && 
                    parameter["required"].ToString().ToLower() == "true")
                {
                    req = true;
                }
                if (parameter["description"] != null)
                {
                    Description = parameter["description"].ToString();
                }

                TypeReference paramType;
                var refName = parameter["$ref"];
                if (refName != null)
                {
                    paramType = Global.TypeMap.GetOrAddType(refName.ToString());
                }
                else
                {
                    paramType = Global.TypeMap.AddAnonymousType(parameter, typePrefix + "_" + name);
                }

                paramHAndlers.Add(new ParamTypeHandler(paramType, name,req,Description,true));
            }

            return paramHAndlers;
        }


        private static TypeReference GetReturnType(JProperty method, string typePrefix)
        {
            var type = method.First["returns"]["type"];
            if (type != null)
            {
                switch (type.ToString())
                {
                    case "boolean":
                    case "integer":
                    case "number":
                    case "string":
                    case "any":
                        return Global.TypeMap.GetOrAddType(type.ToString());
                    case "object":
                    case "array":
                        return Global.TypeMap.AddAnonymousType(method.First["returns"], typePrefix + "Response");
                    default:
                        throw new NotImplementedException();
                }

            }
            var refName = method.First["returns"]["$ref"].ToString();
            return Global.TypeMap.GetOrAddType(refName);
        }


        /// <summary>
        /// Generate a Constant from the API Version we have read from Kodi
        /// </summary>
        /// <param name="version"></param>
        private static void GenVersion(string version)
        {
            var path = Global.TargetDir.FullName;
            var namesp = Global.BaseNamespace;

            var classFile = new FileInfo(Path.Combine(path, "KodiAPIVersion.cs"));
#if DEBUG
            // Console.WriteLine("Neue Datei {0}", classFile.FullName);
#endif
            if (classFile.Exists)
            {
                classFile.Delete();
            }
            var writer = new StreamWriter(classFile.Open(FileMode.Create, FileAccess.Write));

            writer.WriteLine("using System;");
            writer.WriteLine("using System.Threading.Tasks;");
            writer.WriteLine("using Newtonsoft.Json.Linq;");
            writer.WriteLine(PRAGMA);
            writer.WriteLine("");
            writer.WriteLine("namespace " + namesp);
            writer.WriteLine("{");
            writer.WriteLine("  struct Version");
            writer.WriteLine("  {");
            writer.WriteLine("       public const string KodiAPIVersion = \"" + version + "\";");
            writer.WriteLine("   }");
            writer.WriteLine("}");
            writer.Close();

        }
    }
}






