using System;

namespace Xbmc2S.Model
{
    public interface IImageManager
    {
        void GetImage(string imgUri, Action<object> callback);
        object GetBlankImage();
    }
}