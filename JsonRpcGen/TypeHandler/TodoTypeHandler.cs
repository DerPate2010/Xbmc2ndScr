using System.IO;
using Newtonsoft.Json.Linq;

namespace JsonRpcGen
{
    internal class TodoTypeHandler : TypeHandler.TypeHandler
    {
        private readonly JProperty _type;

        public TodoTypeHandler(JProperty type, string fullname) : base(fullname)
        {
            _type = type;
        }

        public override void WriteDefinition(TextWriter writer)
        {
            
        }
    }
}