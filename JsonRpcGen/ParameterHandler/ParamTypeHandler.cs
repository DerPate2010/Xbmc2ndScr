namespace JsonRpcGen.ParameterHandler
{
    class ParamTypeHandler
    {
        private readonly bool _printDefault;

        /// <summary>
        /// Stores Data about a Parameter
        /// </summary>
        /// <param name="paramHandler"> Type of Handler </param>
        /// <param name="name"> Name of Parameter</param>
        /// <param name="required"> is this Parameter required or optional? </param>
        /// <param name="Desc"> Helptext of the Parameter (read from Kodi)</param>
        /// <param name="printDefault"> show Defaultvalue or not </param>
        public ParamTypeHandler(TypeReference paramHandler, string name, bool required, string Desc, bool printDefault)
        {
            _printDefault = printDefault;

            // MAM: Save additional attributes Required and Description for each Parameter
            Required = required;

            // MAM: start with not nullable
            IsNullable = false;

            if (Desc != null)
            {
                Description = Desc;
            }
            else
            {
                Description = "";
            }

            Type = paramHandler;

            OriginalName = Name = name;
            if (Global.IsReservedName(Name))
            {
                Name = Name + "_arg";
            }

            string p;
            p = Type.TypeHandler.NetType.ToString();
            switch (p)
            {
                case "bool":
                case "integer":
                case "double":
                    IsNullable = true;
                    break;
            }

        }

        public TypeReference Type { get; private set; }
        public string Name { get; private set; }
        public string OriginalName { get; private set; }


        /// <summary>
        /// MAM: remember the required state, never make this on an optional parameter
        /// </summary>
        public bool Required { get; private set; }

        /// <summary>
        /// MAM: remember an optional description for the parameter. put it into the comment list on method entry
        /// </summary>
        public string Description { get; private set; }

        // MAM: remember if this type is an Enum or a Class
        public bool IsEnum { get; private set; }

        // MAM: did we make this one nullable?
        public bool IsNullable { get; private set; }

        /// <summary>
        /// Produce sane Default for given Parameter. 
        /// Don't produce ANY Default if this Parameter is marked "required"!
        /// </summary>
        /// <returns></returns>
        public string GetDefault()
        {
            // MAM: Shortcut: dont step through overloaded virtual functions if the 
            // result is clear right from the beginning
            if (IsNullable == true)
            {
                return "=null";
            }

            //if (_printDefault && Required == false)
            if (_printDefault && Required == false)
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