using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JsonRpcGen.TypeHandler
{
    internal class EnumTypeHandler : TypeHandler
    {
        private readonly JArray _enums;

        public EnumTypeHandler(JToken enums, string fullname)
            : base(fullname)
        {
            _enums = (JArray)enums;
        }

        public override void WriteDefinition(TextWriter writer)
        {
            writer.WriteLine("   public enum " + Name);

            writer.WriteLine("   {");
            foreach (var eval in _enums)
            {
                var name = eval.ToString();
                if (Global.IsReservedName(name))
                {
                    writer.WriteLine("       [global::System.Runtime.Serialization.EnumMember(Value=\"" + name + "\")]");
                    name = Global.MakeFirstUpper(name);
                }
                name = name.Replace('.', '_');
                writer.WriteLine("       " + name + ",");
            }
            writer.WriteLine("   }");
        }

        public override string GetDefault()
        {
            return "0";
        }
    }
}