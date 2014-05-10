using System;
using Windows.Storage.Streams;
using Xbmc2S.Model;

namespace Xbmc2S.RT.SampleDataModel
{
    internal class ImageManSample:IImageManager
    {
        public bool first=true;

        public async void GetImage(string imgUri, Action<IRandomAccessStream> callback)
        {
        }

        public void GetImage(string imgUri, Action callback)
        {
            throw new NotImplementedException();
        }

        public void GetImage(string imgUri, Action<object> callback)
        {
            throw new NotImplementedException();
        }

        public object GetBlankImage()
        {
            return null;
        }
    }
}