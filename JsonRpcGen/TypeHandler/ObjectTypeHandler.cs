using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace JsonRpcGen.TypeHandler
{
    class PropertyInfo
    {
        private readonly JProperty _prop;
        private readonly string _containingTypeName;

        public PropertyInfo(JProperty prop, string containingTypeName)
        {
            _prop = prop;
            _containingTypeName = containingTypeName;

            Type = GetTypeHandler(prop);
            Name = _prop.Name;

        }

        public TypeReference Type { get; set; }

        private TypeReference GetTypeHandler(JProperty prop)
        {
            // string typeName; // MAM??? Variable never used, maybe for debuggin only?

            string propertyType = prop.First["type"] != null ? prop.First["type"].ToString() : null;
            var typeNameForAnonymousType = _containingTypeName + "_" + prop.Name;

            if (propertyType == "object")
            {
                return Global.TypeMap.AddAnonymousType(prop,typeNameForAnonymousType);
            }

            else if (propertyType == "array")
            {
                return Global.TypeMap.AddAnonymousType(prop, typeNameForAnonymousType);
            }
            else if (prop.First["enums"] != null && propertyType == "string")
            {
                return Global.TypeMap.AddAnonymousType(prop, typeNameForAnonymousType);
            }
            else if (prop.First["additionalProperties"] != null && prop.First["additionalProperties"].ToString() != "false")
            {
                return Global.TypeMap.AdditionalPropertiesType;
                
            }
            else
            {
                return Global.TypeMap.GetOrAddType((JToken) prop);
            }
        }

        public void WriteProperty(TextWriter writer)
        {
            var propName = Name;
            if (Global.IsReservedName(propName))
            {
                writer.WriteLine("       [Newtonsoft.Json.JsonProperty(\"" + propName + "\")]");
                propName = Global.MakeFirstUpper(propName);
            }

            writer.WriteLine("       " + "public" +  " " + Type.TypeHandler.NetType + " " + propName + " { get; set; }");

        }

        public string Name { get; private set; }
    }

    internal class ObjectTypeHandler : TypeHandler
    {
        private readonly JToken _anonymousType;
        private readonly JProperty _type;

        private readonly JToken _jsonProperties;
        private List<PropertyInfo> _properties;
        private List<TypeHandler> _interfaces= new List<TypeHandler>();
        public TypeReference BaseType { get; private set; }


        void AnalyzeProperties()
        {
            if (_jsonProperties != null)
            {
                _properties= new List<PropertyInfo>();
                foreach (JProperty prop in _jsonProperties)
                {
                    _properties.Add(new PropertyInfo(prop, Fullname));
                }
            }
        }
        
        public ObjectTypeHandler(JToken anonymousType, string fullname)
            : base(fullname)
        {
            _anonymousType = anonymousType;
            _jsonProperties = anonymousType["properties"];
            if (_jsonProperties == null)
            {
                throw new ArgumentNullException();
            }

            AnalyzeProperties();
        }

        public override void AddInterface(TypeHandler interfaceType)
        {
            _interfaces.Add(interfaceType);
        }


        public ObjectTypeHandler(JProperty type, string fullname)
            : base(fullname)
        {
            _type = type;
            _jsonProperties = type.First["properties"];
            AnalyzeProperties();
        }

        public ObjectTypeHandler(JProperty type, string baseName, string fullname):this(type, fullname)
        {
            BaseType = Global.TypeMap.GetOrAddType(baseName);
        }

        public override void WriteDefinition(TextWriter writer)
        {
            writer.Write("   public class " + Name);
            WriteBody(writer);

            WriteNestedClasses(writer, Fullname);

            writer.WriteLine("    }");
        }

        public static void WriteNestedClasses(TextWriter writer, string fullname)
        {
            var nestedTypes = Global.TypeMap.GetTypesWithNamespace(fullname);

            foreach (var nestedType in nestedTypes)
            {
                if (!nestedType.TypeHandler.IsBuiltIn)
                {
                    nestedType.TypeHandler.WriteDefinition(writer);
                }
            }
        }

        private void WriteBody(TextWriter writer)
        {
            //if (_baseName != null)
            //{
            //    var baseName = Global.BaseNamespace + "." + _baseName;
            //    baseName = baseName.Replace(Global.BaseNamespace + "." + Global.BaseNamespace + ".",
            //                                  Global.BaseNamespace + ".");
            //    writer.Write(" : " + baseName);
            //}

            if (BaseType != null)
            {
                
                _interfaces.Insert(0,BaseType.TypeHandler);
            }

            _interfaces = _interfaces.Where(i=>!IsSelfOrBuiltIn(i)).ToList();


            if (_interfaces.Count() > 1)
            {
                //TODO
                _interfaces = _interfaces.Take(1).ToList();
            }

            if (_interfaces.Any())
            {
                var delimiter = " : ";
                foreach (var interfaceType in _interfaces)
                {
                    writer.Write(delimiter);
                    delimiter = ", ";
                    writer.Write(interfaceType.NetType);
                }
            }

            writer.WriteLine();

            writer.WriteLine("   {");
            WriteProperties(writer);
        }

        private bool IsSelfOrBuiltIn(TypeHandler type)
        {
            if (type.IsBuiltIn) return true;
            if (type == this) return true;
            var multiType = type as MultiTypeHandler;
            if (multiType != null)
            {
                return multiType.TypeHandlers.All(t=>IsSelfOrBuiltIn(t.TypeHandler));
            }
            return false;
        }

        protected virtual void WriteProperties(TextWriter writer)
        {
            if (_properties != null)
            {
                foreach (var propertyInfo in _properties)
                {
                    propertyInfo.WriteProperty(writer);
                }
            }
        }

    }
}