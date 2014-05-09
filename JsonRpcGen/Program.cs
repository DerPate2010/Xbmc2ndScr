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

        static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { "http://localhost:85/jsonrpc", "xbmc", "xbmc", "XBMCRPC" };
#endif
            Global.TargetDir = new DirectoryInfo(@"..\..\..\XBMCRPC13.Portable\" + args[3]);
            if (Global.TargetDir.Exists)
            {
                Global.TargetDir.Delete(true);
            }
            Global.BaseNamespace = args[3];

            //var schemaTask = GetSchema(args[0], args[1], args[2]);
            //schemaTask.Wait();
            //var schema = schemaTask.Result;
            JObject schema = JObject.Parse(File.ReadAllText(@"..\..\xbmc13.json"));

            var types = schema["result"]["types"];
            var methods = schema["result"]["methods"];
            var notifications = schema["result"]["notifications"];

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
                    multiMethods.Add(methodName +" - " + dim);
                }
                var overloadParam = parameters.FirstOrDefault(p => p.Type.TypeHandler is MultiTypeHandler);
                if (overloadParam==null)
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
                    var writer2 = new StreamWriter(classFile.Open(FileMode.Append, FileAccess.Write));
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
                    writer2.WriteLine("            var jArgs = new JObject();");
                    foreach (var pname in overload)
                    {
                        writer2.WriteLine("             if (" + pname.Name + " != null)");
                        writer2.WriteLine("             {");
                        writer2.WriteLine("                 var jprop" + pname.Name + " = JToken.FromObject(" + pname.Name + ", _client.Serializer);");
                        writer2.WriteLine("                 jArgs.Add(new JProperty(\"" + pname.OriginalName + "\", jprop" + pname.Name + "));");
                        writer2.WriteLine("             }");
                    }
                    writer2.WriteLine("            return await _client.GetData<" + retType.TypeHandler.NetType + ">(\"" + method.Name + "\", jArgs);");
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
                    var writer2 = new StreamWriter(classFile.Open(FileMode.Append, FileAccess.Write));
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
            var multiTypeHandler = ((MultiTypeHandler) overloadParam.Type.TypeHandler);
            foreach (var type in multiTypeHandler.TypeHandlers)
            {
                if (type.TypeHandler is MultiTypeHandler)
                {
                    AddOverloads(new ParamTypeHandler(type, overloadParam.Name), parameters, indexToReplace, overloads);
                }
                else
                {
                    var overload = new List<ParamTypeHandler>(parameters);
                    overload.RemoveAt(indexToReplace);
                    overload.Insert(indexToReplace, new ParamTypeHandler(type, overloadParam.Name, false));
                    overloads.Add(overload);
                }
            }
        }

        private static string GetParameterList(IEnumerable<ParamTypeHandler> parameters)
        {
            var orderedParameters = parameters.OrderByDescending(p => string.IsNullOrEmpty(p.GetDefault())).ToList();

            return string.Join(", ", orderedParameters.Where(p => p.Type.TypeHandler.NetType != null).Select(p => p.Type.TypeHandler.NetType + " " + p.Name + p.GetDefault()));
        }

        private static IEnumerable<ParamTypeHandler> GetParams(JProperty method, string typePrefix)
        {
            List<ParamTypeHandler> paramHAndlers= new List<ParamTypeHandler>();

            var parameters = method.First["params"];
            foreach (JObject parameter in parameters)
            {
                var name = parameter["name"].ToString();

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

                paramHAndlers.Add(new ParamTypeHandler(paramType, name));
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

    }
}






