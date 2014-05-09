namespace JsonRpcGen.ParameterHandler
{
    class ParamTypeHandler
    {
        private readonly bool _printDefault;

        public ParamTypeHandler(TypeReference paramHandler, string name, bool printDefault=true)
        {
            _printDefault = printDefault;
            Type = paramHandler;
            OriginalName = Name = name;
            if (Global.IsReservedName(Name))
            {
                Name = Name + "_arg";
            }
        }

        public TypeReference Type { get; private set; }
        public string Name { get; private set; }
        public string OriginalName { get; private set; }

        public string GetDefault()
        {
            if (_printDefault)
            {
                return "=" + Type.TypeHandler.GetDefault();
            }
            else
            {
                return "";
            }
        }
    }
}