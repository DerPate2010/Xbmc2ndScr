using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace XBMCRPC
{
    internal class BaseConverter : CustomCreationConverter<XBMCRPC.List.Item.Base>
    {
        private readonly string _multipleInheritanceKey;

        public BaseConverter(string multipleInheritanceKey)
        {
            _multipleInheritanceKey = multipleInheritanceKey;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            XBMCRPC.List.Item.Base value ;
            var jObject=(JObject)serializer.Deserialize(reader);
            if (jObject[_multipleInheritanceKey] == null)
            {
                value = jObject.ToObject<XBMCRPC.List.Item.BaseFile>();
            }
            else
            {
                value = jObject.ToObject<XBMCRPC.List.Item.BaseMedia>();
            }

            return value;
        }

		public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(XBMCRPC.List.Item.Base);
        }

        public override XBMCRPC.List.Item.Base Create(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}