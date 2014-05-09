using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace XBMCRPC
{
    internal class AllConverter : CustomCreationConverter<XBMCRPC.List.Item.All>
    {
        private readonly string _multipleInheritanceKey;

        public AllConverter(string multipleInheritanceKey)
        {
            _multipleInheritanceKey = multipleInheritanceKey;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            XBMCRPC.List.Item.All value ;
            var jObject=(JObject)serializer.Deserialize(reader);
            if (jObject[_multipleInheritanceKey] == null)
            {
                value = jObject.ToObject<XBMCRPC.List.Item.AllFile>();
            }
            else
            {
                value = jObject.ToObject<XBMCRPC.List.Item.AllMedia>();
            }

            return value;
        }

		public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(XBMCRPC.List.Item.All);
        }

        public override XBMCRPC.List.Item.All Create(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}