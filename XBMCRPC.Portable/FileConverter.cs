using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace XBMCRPC
{
    internal class FileConverter : CustomCreationConverter<XBMCRPC.List.Item.File>
    {
        private readonly string _multipleInheritanceKey;

        public FileConverter(string multipleInheritanceKey)
        {
            _multipleInheritanceKey = multipleInheritanceKey;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            XBMCRPC.List.Item.File value ;
            var jObject=(JObject)serializer.Deserialize(reader);
            if (jObject[_multipleInheritanceKey] == null)
            {
                value = jObject.ToObject<XBMCRPC.List.Item.FileBaseFile>();
            }
            else
            {
                value = jObject.ToObject<XBMCRPC.List.Item.FileBaseMedia>();
            }

            return value;
        }

		public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(XBMCRPC.List.Item.File);
        }

        public override XBMCRPC.List.Item.File Create(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}