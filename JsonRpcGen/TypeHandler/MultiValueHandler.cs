using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JsonRpcGen.TypeHandler
{
    internal class MultiValueHandler : TypeHandler
    {
        private readonly JToken _types;

        public MultiValueHandler(JToken types, string fullname)
            : base(fullname)
        {
            _types = types;
            foreach (var type in _types)
            {
                switch (type["type"].ToString())
                {
                    case "boolean":
                    case "string":
                    case "integer":
                        break;
                    default:
                        IsBuiltIn = true;
                        NetType = Global.TypeMap.AnyType.TypeHandler.NetType;
                        break;
                }
            }
        }

        public override string GetDefault()
        {
            foreach (var type in _types)
            {
                switch (type["type"].ToString())
                {
                    case "boolean":
                    case "string":
                    case "integer":
                        break;
                    default:
                        return "null";
                }
            }

            return "0";
        }

        public override void WriteDefinition(TextWriter writer)
        {
            foreach (var type in _types)
            {
                switch (type["type"].ToString())
                {
                    case "boolean":
                    case "string":
                    case "integer":
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }

            writer.WriteLine("   public enum " + Name);
            writer.WriteLine("   {");

            foreach (var type in _types)
            {
                switch (type["type"].ToString())
                {
                    case "boolean":

                        writer.WriteLine("   [EnumMember(Value=\"true\")]");
                        writer.WriteLine("   True,");
                        writer.WriteLine("   [EnumMember(Value=\"false\")]");
                        writer.WriteLine("   False,");
                        break;
                    case "integer":
                        for (int i = 0; i <= 10; i++)
                        {
                            writer.WriteLine("   [EnumMember(Value=\"" + i + "\")]");
                            writer.WriteLine("   Int" + i + ",");
                        }
                        break;
                    case "string":
                        var vals = type["enums"];
                        if (vals == null)
                        {
                            //TODO
                            break;
                        }
                        foreach (var val in vals)
                        {
                            writer.WriteLine("   " + val.ToString() + ",");
                        }

                        break;
                    default:
                        throw new NotSupportedException();
                }
            }

            writer.WriteLine("   }");
        }
    }
}