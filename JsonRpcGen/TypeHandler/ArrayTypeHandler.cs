using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JsonRpcGen.TypeHandler
{
    internal class ArrayTypeHandler : TypeHandler
    {
        private readonly JToken _items;
        private TypeReference _itemTypeHandler;

        public ArrayTypeHandler(JToken items, string fullname):base( fullname)
        {
            _items = items;
            if (_items["properties"]!=null)
            {
                _itemTypeHandler=Global.TypeMap.AddAnonymousType(_items,fullname + "Item");
            }
            else if (_items["$ref"] != null)
            {
                if (_itemTypeHandler != null)
                {
                    throw new NotImplementedException();
                }
                _itemTypeHandler = Global.TypeMap.GetOrAddType(_items["$ref"].ToString());

            }
            else if (_items["type"] != null)
            {
                _itemTypeHandler = Global.TypeMap.GetOrAddType(_items["type"].ToString());
            }
        }

        public override string NetType
        {
            get
            {
                if (!(_itemTypeHandler.TypeHandler is EnumTypeHandler))
                {
                    base.NetType = "global::System.Collections.Generic.List<" + _itemTypeHandler.TypeHandler.NetType + ">";
                }
                return base.NetType;
            }
            set { base.NetType = value; }
        }

        public override void WriteDefinition(TextWriter writer)
        {
            if (_itemTypeHandler.TypeHandler is EnumTypeHandler)
            {

            }
            else
            {
                NetType = "global::System.Collections.Generic.List<" + _itemTypeHandler.TypeHandler.NetType + ">";
                IsBuiltIn = true;
                return;
            }

            writer.Write("   public class " + Name + " : global::System.Collections.Generic.List<" + _itemTypeHandler.TypeHandler.NetType + ">");
            writer.WriteLine();

            writer.WriteLine("   {");
            writer.WriteLine("         public static " + Name + " AllFields()");
            writer.WriteLine("         {");
            writer.WriteLine("             var items = Enum.GetValues(typeof (" + _itemTypeHandler.TypeHandler.NetType + "));");
            writer.WriteLine("             var list = new " + Name + "();");
            writer.WriteLine("             list.AddRange(items.Cast<" + _itemTypeHandler.TypeHandler.NetType + ">());");
            writer.WriteLine("             return list;");
            writer.WriteLine("         }");
            writer.WriteLine("   }");
        }

        public override void AddInterface(TypeHandler interfaceType)
        {
            //TODO
        }
    }
}