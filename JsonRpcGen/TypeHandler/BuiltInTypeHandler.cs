using System;
using System.IO;

namespace JsonRpcGen.TypeHandler
{
    class BuiltInTypeHandler : TypeHandler
    {


        public BuiltInTypeHandler(string fullname, string netType):base(fullname)
        {
            NetType = netType;
            IsBuiltIn = true;
        }

        public override void WriteDefinition(TextWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void AddInterface(TypeHandler interfaceType)
        {
            //TODO
        }

        public override string GetDefault()
        {
            switch (NetType)
            {
                case "bool" : return "false";
                case "int" : return "0";
                case "double" : return "0";
                default: return base.GetDefault();        
            }
            
        }
    }
}