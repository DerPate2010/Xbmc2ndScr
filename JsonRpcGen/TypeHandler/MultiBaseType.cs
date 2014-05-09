using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JsonRpcGen.TypeHandler
{
    internal class MultiBaseType : ObjectTypeHandler
    {
        private readonly JToken _type;
        private readonly MultiBaseType _multiBaseType;
        private JToken _baseNames;
        private List<string> classes;
        private string _className;
        private string _baseInterface;
        private List<TypeReference> _baseTypes;

        public MultiBaseType(JProperty type, JToken baseNames, string fullname)
            : base(type,fullname)
        {
            _type = type;
            _baseNames = baseNames;
            _baseTypes = _baseNames.Select(GetTypeHandler).ToList();
        }

        private TypeReference GetTypeHandler(JToken arg)
        {
            return Global.TypeMap.GetOrAddType(arg.ToString());
        }

        public override void WriteDefinition(TextWriter writer)
        {
            writer.WriteLine("    using Newtonsoft.Json;");
            var converterName = Fullname.Replace(".", "") + "Converter";
            writer.Write("    [Newtonsoft.Json.JsonConverter(typeof(");
            writer.Write(converterName);
            writer.WriteLine("))]");
            base.WriteDefinition(writer);


            writer.Write("    internal class ");
            writer.Write(converterName);
            writer.Write(" : Newtonsoft.Json.Converters.CustomCreationConverter<");
            writer.Write(NetType);
            writer.WriteLine(">");
            writer.WriteLine("    {");
            writer.WriteLine("        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)");
            writer.WriteLine("        {");
            writer.WriteLine("            if (reader.TokenType == JsonToken.Null)");
            writer.WriteLine("                return null;");
            writer.WriteLine("");
            writer.WriteLine("            var jObject = (JObject)serializer.Deserialize(reader);");
            writer.WriteLine("            var localReader = new JTokenReader(jObject);");
            writer.Write("            var val = (");
            writer.Write(NetType); 
            writer.WriteLine(")base.ReadJson(localReader, objectType, existingValue, serializer);");
            writer.WriteLine("");
            foreach (var baseType in _baseTypes)
            {
                writer.WriteLine("            localReader = new JTokenReader(jObject);");
                writer.Write("            val.As");
                writer.Write(baseType.TypeHandler.Fullname.Replace(".", ""));
                writer.Write(" = serializer.Deserialize<");
                writer.Write(baseType.TypeHandler.NetType);
                writer.WriteLine(">(localReader);");
            }
            writer.WriteLine("");
            writer.WriteLine("            return val;");
            writer.WriteLine("        }");
            writer.WriteLine("");
            writer.WriteLine("		  public override bool CanConvert(Type objectType)");
            writer.WriteLine("        {");
            writer.Write("            return objectType == typeof(");
            writer.Write(NetType);
            writer.WriteLine(");");
            writer.WriteLine("        }");
            writer.WriteLine("");
            writer.Write("        public override ");
            writer.Write(NetType);
            writer.WriteLine(" Create(Type objectType)");
            writer.WriteLine("        {");
            writer.Write("            return (");
            writer.Write(NetType);
            writer.WriteLine(") Activator.CreateInstance(objectType);");
            writer.WriteLine("        }");
            writer.WriteLine("    }");
        }

        protected override void WriteProperties(TextWriter writer)
        {
            base.WriteProperties(writer);

            Debug.Assert(_baseTypes.Count() == 2);

            List<List<TypeReference>> baseHierarchies = new List<List<TypeReference>>(_baseTypes.Count());

            foreach (var baseType in _baseTypes)
            {
                List<TypeReference> baseHierarchie = new List<TypeReference>();
                CollectBaseTypes(baseType, baseHierarchie);
                baseHierarchies.Add(baseHierarchie);

                WriteBaseProperty(writer, baseType);
            }
            var baseCandidates = baseHierarchies.First();
            var otherBases = baseHierarchies.Skip(1).ToList();
            foreach (var baseCandidate in baseCandidates.ToList())
            {
                var isCommonBase = otherBases.All(b => b.Contains(baseCandidate));
                if (!isCommonBase)
                {
                    baseCandidates.Remove(baseCandidate);
                }
            }
            var commonBase = baseCandidates.FirstOrDefault();
            if (commonBase != null)
            {
                WriteBaseProperty(writer, commonBase);
                _baseTypes.Add(commonBase);
            }

            //writer.WriteLine("       private object _base; ");
        }

        private static void WriteBaseProperty(TextWriter writer, TypeReference baseType)
        {
            writer.WriteLine("       [Newtonsoft.Json.JsonIgnore]");
            writer.Write("       public ");
            writer.Write(baseType.TypeHandler.NetType);
            writer.Write(" As");
            writer.Write(baseType.TypeHandler.Fullname.Replace(".", ""));
            writer.Write(" ");
            writer.WriteLine(" { get; set; }");
            //writer.Write(" { get {return _base as ");
            //writer.Write(baseType.TypeHandler.NetType);
            //writer.WriteLine("; } set { _base = value; } }");
        }

        private static void CollectBaseTypes(TypeReference baseType, List<TypeReference> baseHierarchie)
        {
            var objType = baseType.TypeHandler as ObjectTypeHandler;
            if (objType != null)
            {
                if (objType.BaseType != null)
                {
                    baseHierarchie.Add(objType.BaseType);
                    CollectBaseTypes(objType.BaseType, baseHierarchie);
                }
            }
        }
    }
}