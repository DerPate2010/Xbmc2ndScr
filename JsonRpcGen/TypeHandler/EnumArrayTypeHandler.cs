using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JsonRpcGen.TypeHandler
{
    internal class EnumArrayTypeHandler : TypeHandler
    {
        private readonly JToken _enums;

        public EnumArrayTypeHandler(JToken enums, string fullname)
            : base(fullname)
        {
            _enums = enums;
        }

        public override void WriteDefinition(TextWriter writer)
        {
            writer.WriteLine("   public enum " + Name + "Item");

            writer.WriteLine("   {");
            foreach (var eval in _enums)
            {
                var name = eval.ToString();
                if (Global.IsReservedName(name))
                {
                    writer.WriteLine("       [global::System.Runtime.Serialization.EnumMember(Value=\"" + name + "\")]");
                    name = Global.MakeFirstUpper(name);
                }

                // MAM: stupid KODI Name "Visualization-library" illegal for Enum, so we change "-" to "_"
                writer.WriteLine("       " + Global.ChangeDotsAndDashesToUnderscores(name) + ",");

            }
            writer.WriteLine("   }");
            writer.WriteLine("   public class " + Name + " : List<" + Name + "Item>");

            writer.WriteLine("   {");
            writer.WriteLine("         public static " + Name + " AllFields()");
            writer.WriteLine("         {");
            writer.WriteLine("             var items = Enum.GetValues(typeof (" + Name + "Item));");
            writer.WriteLine("             var list = new " + Name + "();");
            writer.WriteLine("             list.AddRange(items.Cast<" + Name + "Item>());");
            writer.WriteLine("             return list;");
            writer.WriteLine("         }");
            writer.WriteLine("   }");
        }
    }
}