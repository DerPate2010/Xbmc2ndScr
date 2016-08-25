using System.Collections.Generic;

namespace JsonRpcGen
{
    class TypeReference
    {
        private TypeHandler.TypeHandler _typeHandler;
        public string Name { get; set; }

        public TypeHandler.TypeHandler TypeHandler
        {
            get { return _typeHandler; }
            set
            {
                _typeHandler = value;
                foreach (var interfaceType in _interfaces)
                {
                    _typeHandler.AddInterface(interfaceType);
                }
            }
        }

        private List<TypeHandler.TypeHandler> _interfaces= new List<TypeHandler.TypeHandler>(); 

        public void AddInterface(TypeHandler.TypeHandler interfaceType)
        {
            _interfaces.Add(interfaceType);
            if (_typeHandler != null)
            {
                _typeHandler.AddInterface(interfaceType);
            }
        }
    }
}