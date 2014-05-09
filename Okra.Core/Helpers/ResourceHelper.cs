//using Windows.ApplicationModel.Resources;

namespace Okra.Helpers
{
    internal static class ResourceHelper
    {
        // *** Static Fields ***

        //private static ResourceLoader errorResourceLoader;

        // *** Methods ***

        public static string GetErrorResource(string resourceName)
        {
            //if (errorResourceLoader == null)
            //    errorResourceLoader = new ResourceLoader("Okra.Core/Errors");

            //return errorResourceLoader.GetString(resourceName);
            return "error";
        }
    }
}
