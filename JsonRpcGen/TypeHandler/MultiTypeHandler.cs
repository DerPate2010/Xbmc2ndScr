using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JsonRpcGen.TypeHandler
{
    internal class MultiTypeHandler :TypeHandler
    {
        private readonly JToken _types;
        public List<TypeReference> TypeHandlers { get; private set; }

        

        public MultiTypeHandler(JToken types, string fullname) : base(fullname)
        {
            IsBuiltIn = true;
            NetType = "object";

            _types = types;

            int counter = 1;
            TypeHandlers= new List<TypeReference>();
            foreach (var type in _types)
            {
                var refType = type["$ref"];
                if (refType != null)
                {
                    var refTypeHandler = Global.TypeMap.GetOrAddType(refType.ToString());
                    refTypeHandler.AddInterface(this);
                    TypeHandlers.Add(refTypeHandler);
                }
                else
                {
                    var p = type["properties"];
                    string postfix;
                    if (p != null && p.Count() == 1)
                    {
                        postfix = ((JProperty) p.First).Name;
                        postfix = Global.MakeFirstUpper(postfix);
                    }
                    else
                    {
                        postfix = counter.ToString();
                        counter++;
                    }

                    var typeHandler = Global.TypeMap.AddAnonymousType(type, fullname + postfix);

                    TypeHandlers.Add(typeHandler);

                }
            }
        }

        public override void WriteDefinition(TextWriter writer)
        {
            //writer.Write("   public class " + Name + ": JObject {");
            //ObjectTypeHandler.WriteNestedClasses(writer,Fullname);            
            //writer.WriteLine("    }");
            return;

            bool handleBaseAsInterface = false;

            foreach (var type in _types)
            {
                var refType = type["$ref"];
                if (refType != null)
                {
                    handleBaseAsInterface = true;
                }
                else
                {
                    if (handleBaseAsInterface)
                    {
                        writer.Write("   public class " + Name + ": JObject {");
                        writer.WriteLine("    }");
                        return;
                    }
                }
            }

            writer.Write("   public ");
            if (handleBaseAsInterface)
            {
                writer.Write("interface");
            }
            else
            {
                writer.Write("class");
            }
            writer.WriteLine(" " + Name);
            writer.WriteLine("   {");
            writer.WriteLine("   }");
            
        }
    }
}