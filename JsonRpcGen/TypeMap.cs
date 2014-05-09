using System.Collections.Generic;
using System.Linq;
using JsonRpcGen.TypeHandler;
using Newtonsoft.Json.Linq;

namespace JsonRpcGen
{
    class TypeMap
    {
        Dictionary<string, TypeReference> _typeMap = new Dictionary<string, TypeReference>();
        
        public TypeReference AdditionalPropertiesType { get; private set; }
        public TypeReference AnyType { get; private set; }

        public TypeMap()
        {
            AdditionalPropertiesType=AddToMap(new BuiltInTypeHandler("additionalProperties", "global::System.Collections.Generic.Dictionary<string,string>"));
            //AnyType=AddToMap(new BuiltInTypeHandler("any", "string"));
            AnyType=AddToMap(new BuiltInTypeHandler("any", "object"));
            AddBuiltInType("boolean", "bool");
            AddBuiltInType("Optional.Boolean", "bool?");
            AddBuiltInType("integer", "int");
            AddBuiltInType("Optional.Integer", "int?");
            AddBuiltInType("number", "double");
            AddBuiltInType("Optional.Number", "double?");
            AddBuiltInType("string", "string");
            AddBuiltInType("Optional.String", "string");
            AddBuiltInType("Global.String.NotEmpty", "string");
            AddBuiltInType("Notifications.Library.Audio.Type", "string");
            AddBuiltInType("Notifications.Library.Video.Type", "string");

        }

        private TypeReference AddToMap(TypeHandler.TypeHandler typeHandler)
        {
            var typeReference = new TypeReference() {Name = typeHandler.Fullname, TypeHandler = typeHandler};
            _typeMap.Add(typeReference.Name, typeReference);
            return typeReference;
        }

        private void AddBuiltInType(string typeName, string netTypeName)
        {
            AddToMap(new BuiltInTypeHandler(typeName, netTypeName));
        }

        public TypeReference GetOrAddType(JProperty type)
        {
            var typeHandler = GetTypeHandler(type);

            TypeReference typeRef;
            if (_typeMap.TryGetValue(typeHandler.Fullname, out typeRef))
            {
                if (typeRef.TypeHandler == null)
                {
                    typeRef.TypeHandler = typeHandler;
                }
                return typeRef;
            }
            return AddToMap(typeHandler);
        }
        public TypeReference GetOrAddType(string refName)
        {
            TypeReference typeRef;
            if (_typeMap.TryGetValue(refName, out typeRef))
            {
                return typeRef;
            }
            if (refName.StartsWith("["))
            {
                return AnyType;
            }
            typeRef = new TypeReference() { Name = refName };
            _typeMap.Add(refName, typeRef);
            return typeRef;
        }

        public TypeReference GetOrAddType(JToken jToken)
        {
            var jProperty = jToken as JProperty;
            if (jProperty != null)
            {
                jToken = jProperty.First;
            }
            if (jToken["$ref"] != null)
            {
                var refName = jToken["$ref"].ToString();
                return GetOrAddType(refName);
            }
            var typeName = jToken["type"].ToString();
            if (typeName.StartsWith("["))
            {
                if (jToken["type"].All(IsValueType))
                {
                    return GetOrAddType("string");
                }
                if (jToken["type"].Count() == 2 && jToken["type"].First["type"] != null
                    && jToken["type"].First["type"].ToString() == "null" && jToken["type"].Last["$ref"] != null)
                {
                    return GetOrAddType(typeName + "?");
                }
            }

            return GetOrAddType(typeName);
        }

        private bool IsValueType(JToken arg)
        {
            if (arg["type"] == null)
                return false;
            var type = arg["type"].ToString();
            switch (type)
            {
                case "boolean":
                case "integer":
                case "number":
                case "string":
                    return true;
                default:
                    return false;
            }
        }


        public static TypeHandler.TypeHandler GetTypeHandler(JProperty type, string fullname = null)
        {
            if (fullname == null)
            {
                fullname = type.Name;
            }
            var baseName = type.First["extends"];
            if (baseName != null)
            {
                if (baseName.ToString() == "Item.Fields.Base")
                {
                    return new EnumArrayTypeHandler(type.First["items"]["enums"], fullname);
                }
                if (baseName.ToString().StartsWith("["))
                {

                    var typeHandler = new MultiBaseType(type, baseName, fullname);
                    Global.MultiBaseTypes.Add(fullname, typeHandler);
                    return typeHandler;
                }
                //if (Global.MultiBaseTypes.ContainsKey(baseName.ToString()))
                //{
                //    var typeHandler = new MultiBaseType(type, Global.MultiBaseTypes[baseName.ToString()], fullname);
                //    Global.MultiBaseTypes.Add(fullname, typeHandler);
                //    return typeHandler;
                //}
                return new ObjectTypeHandler(type, baseName.ToString(), fullname);
            }
            var typeName = type.First["type"].ToString();
            switch (typeName)
            {
                case "string":
                    if (type.First["enums"] != null)
                    {
                        return new EnumTypeHandler(type.First["enums"], fullname);
                    }
                    return new BuiltInTypeHandler(fullname, "string");
                case "array":
                    return new ArrayTypeHandler(type.First["items"], fullname);
                case "object":
                    return new ObjectTypeHandler(type, fullname);
                case "integer":
                    return new BuiltInTypeHandler(fullname, "int");
                case "number":
                    return new BuiltInTypeHandler(fullname, "double");
                case "boolean":
                    return new BuiltInTypeHandler(fullname, "bool");
                case "any":
                    return new BuiltInTypeHandler(fullname, Global.TypeMap.AnyType.TypeHandler.NetType);
                case "null":
                    return new BuiltInTypeHandler(fullname, "object");
                default:
                    if (typeName.StartsWith("[") && !fullname.StartsWith("Optional."))
                    {
                        var types = type.First["type"];
                        //if (types.All(Global.IsValueType))
                        //{
                        //    return new MultiValueHandler(types, fullname);

                        //}
                        //else
                        {
                            if (types.Count() == 2)
                            {
                                var containsNull = types.Any(t => t["type"] != null && t["type"].ToString() == "null");
                                var containsRef = types.FirstOrDefault(t => t["$ref"] != null);
                                if (containsNull && containsRef != null)
                                {
                                    return Global.TypeMap.GetOrAddType(containsRef.ToString()).TypeHandler;
                                }
                            }

                            return new MultiTypeHandler(types, fullname);

                        }
                    }

                    return new TodoTypeHandler(type,fullname);
            }
        }


        public IEnumerable<TypeReference> GetEnumerable()
        {
            return _typeMap.Values.ToList();
        }

        public TypeReference AddAnonymousType(JToken items, string fullname)
        {
            var types = items["type"];
            if (types != null && types.Count() == 2)
            {
                var containsNull = types.Any(t => t["type"] != null && t["type"].ToString() == "null");
                var containsRef = types.FirstOrDefault(t => t["$ref"] != null);
                if (containsNull && containsRef != null)
                {
                    return Global.TypeMap.GetOrAddType(containsRef["$ref"].ToString());
                }
            }

            var prop = new JProperty(fullname, items);
            var typeHandler2 = GetTypeHandler(prop, fullname);

            return AddToMap(typeHandler2);
        }

        public TypeReference AddAnonymousType(JProperty type, string fullname)
        {
            var typeHandler2 = GetTypeHandler(type, fullname);
            //var typeHandler = new ObjectTypeHandler(type, fullname);
            return AddToMap(typeHandler2);
        }

        public List<TypeReference> GetTypesWithNamespace(string localNamespace)
        {
            return _typeMap.Values.Where(t => t.TypeHandler.LocalNamespace == localNamespace).ToList();
        }

        public bool ContainsType(string localNamespace)
        {
            return _typeMap.Values.Any(t => t.Name==localNamespace && t.TypeHandler.IsBuiltIn==false);
        }
    }
}