using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TmdbWrapper;


namespace TmdbWrapper.Utilities
{
    internal static class Extensions
    {
        #region private constants
        private const string baseImageUri = @"http://cf2.imgobject.com/t/p/";
        #endregion

        #region string extensions
        internal static string EscapeString(this string s)
        {
            return Regex.Replace(s, "[" + Regex.Escape(new String(Path.GetInvalidFileNameChars())) + "]", "-");
        }
        #endregion

        #region jsonValue extensions
        internal static string GetSafeString(this JObject jsonObject, string valueName)
        {
            try
            {
                JToken value;
                if (jsonObject.TryGetValue(valueName,out value))
                {
                    return value.ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        internal static Uri GetSafeUri(this JObject jsonObject, string valueName)
        {
            try
            {
                var value = GetSafeString(jsonObject, valueName);
                Uri uri;
                if (Uri.TryCreate(value, UriKind.Absolute, out uri))
                {
                    return uri;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        internal static bool GetSafeBoolean(this JObject jsonObject, string valueName, bool defaultValue = false)
        {
            try
            {
                return jsonObject[valueName].ToObject<bool>();
            }
            catch
            {
                return defaultValue;
            }
        }

        internal static double GetSafeNumber(this JObject jsonObject, string valueName)
        {
            try
            {
                return jsonObject[valueName].ToObject<double>();
            }
            catch
            { 
                return 0.0;
            }
        }

        internal static JObject GetSafeObject(this JObject jsonObject, string valueName)
        {
            try
            {
                return jsonObject[valueName].ToObject<JObject>();
            }
            catch
            {
                return null;
            }
        }

        internal static T ProcessObject<T>(this JObject jsonObject, string valueName) where T : ITmdbObject, new()
        {
            try
            {
                var obj = new T();
                obj.ProcessJson(jsonObject[valueName].ToObject<JObject>());
                return obj;
            }
            catch
            {
                return default(T);
            }
        }

        internal static IReadOnlyList<T> ProcessArray<T>(this JObject jsonObject, string valueName) where T : ITmdbObject, new()
        {
            List<T> results = new List<T>();
            var jsonValue = jsonObject[valueName] as JArray;
            if ((jsonValue != null))
            {
                foreach(var subObject in jsonValue)
                {
                    try
                    {
                        var obj = new T();
                        obj.ProcessJson(subObject.ToObject<JObject>());
                        results.Add(obj);
                    }
                    catch
                    { }
                }
            }
            return results;
        }
        #endregion

        #region image uri methods
        internal static Uri MakeImageUri(string size, string path)
        {
            return new Uri(string.Format("{0}{1}{2}", baseImageUri, size, path));
        }
        #endregion
    }
}
