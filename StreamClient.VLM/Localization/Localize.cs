using System;
using StreamClient.VLM.Localization;

namespace StreamingClient.Localization
{
    public class Localize
    {
        private static Res localizedresources = new Res();

        public Res Res { get { return localizedresources; } }


        public static string GetString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                return Res.ResourceManager.GetString(value.ToString());
            }
            catch (Exception)
            {
                return value.ToString();
            }
        }
    }
}
