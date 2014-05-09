using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonRpcGen.TypeHandler
{
    abstract class TypeHandler
    {
        private string _netType;

        public TypeHandler(string fullname)
        {
            Fullname = fullname;
            _netType = Global.BaseNamespace + "."  + fullname;
        }

        public virtual void WriteDefinition(TextWriter writer)
        {
            throw new NotImplementedException();
        }

        public virtual string NetType
        {
            get { return _netType; }
            set { _netType = value; }
        }

        public string Fullname { get; private set; }

        public string  Name
        {
            get
            {
                var parts = Fullname.Split('.');
                return parts.Last();
            }
        }

        public string Namespace
        {
            get
            {
                var parts = Fullname.Split('.');
                var namesp = Global.BaseNamespace + "." + string.Join(".", parts.Take(parts.Length - 1));
                namesp = namesp.TrimEnd('.');
                return namesp;
            }
        }

        public string LocalNamespace
        {
            get
            {
                var parts = Fullname.Split('.');
                var namesp = string.Join(".", parts.Take(parts.Length - 1));
                namesp = namesp.TrimEnd('.');
                return namesp;
            }
        }

        public bool IsBuiltIn { get; protected set; }

        public bool IsNestedClass
        {
            get { return Global.TypeMap.ContainsType(this.LocalNamespace); }
        }

        public virtual void AddInterface(TypeHandler interfaceType)
        {
            //throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Fullname;
        }

        public virtual string GetDefault()
        {
            return "null";
        }
    }
}