using System;
using System.Collections.Generic;
using Xbmc2S.Model;
using XBMCRPC;

namespace Xbmc2S.RT.PlatformServices
{
    class ImageManagerUri : IImageManager
    {


        private readonly Client _xbmc;

        public ImageManagerUri(Client xbmc)
        {
            _xbmc = xbmc;
        }

        public async void GetImage(string imgUri, Action<object> callback)
        {
            if (string.IsNullOrEmpty(imgUri))
            {
                callback(GetBlankImage());
            }
            else
            {
                try
                {
                    var uri = await _xbmc.GetImageUri(imgUri);
                    callback(uri);

                }
                catch (Exception)
                {
                    callback(GetBlankImage());
                }
            }

        }
        private static Uri _baseUri = new Uri("ms-appx:///");

        public object GetBlankImage()
        {
            return new Uri(_baseUri, "Assets/DarkGray.png");
        }
    }
}