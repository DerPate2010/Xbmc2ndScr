using System;
using KODIRPC.Video.Details;

namespace Xbmc2S.Model
{
    public class VideoImages:BindableBase
    {
        private readonly IAppContext _appContext;
        private string _imagePath;
        private string _fanartPath;
        private string _bannerPath;
        private bool _imageLoaded;
        private bool _bannerLoaded;
        private object _image = new Uri("ms-appx:///Assets/DarkGray.png");
        private object _fanArt;
        private object _banner = new Uri("ms-appx:///Assets/DarkGray.png");

        public VideoImages(IAppContext appContext, Base baseDetails)
        {
            _appContext = appContext;
            _imagePath = baseDetails.art.poster;
            if (_imagePath == null)
            {
                _imagePath = baseDetails.thumbnail;
            }
            _fanartPath = baseDetails.art.fanart;
            if (_fanartPath == null)
            {
                _fanartPath = baseDetails.fanart;
            }

            _bannerPath = baseDetails.art.banner;
        }

        public VideoImages(IAppContext appContext)
        {
            _appContext = appContext;
            _image = _appContext.ImageManager.GetBlankImage();
        }

        public VideoImages(IAppContext appContext, KODIRPC.Media.Details.Base baseDetails)
        {
            _appContext = appContext;
            _imagePath = baseDetails.thumbnail;

            _fanartPath = baseDetails.fanart;

        }

        public VideoImages(IAppContext appContext, string thumb)
        {
            _appContext = appContext;
            _imagePath = thumb;
        }

        public VideoImages(Uri uri)
        {
            _imageLoaded = true;
            Image = uri;
        }

        public VideoImages(Uri image, Uri fanart)
        {
            _imageLoaded = true;
            Image = image;
            FanArt = fanart;
        }

        public object Image
        {
            get
            {
                if (!_imageLoaded)
                {
                    _appContext.ImageManager.GetImage(_imagePath, SetImage);
                }
                return this._image;
            }

            private set { _image = value; OnPropertyChanged(); }
        }
        private void SetImage(object randomAccessStream)
        {
            _imageLoaded = true;
            Image = randomAccessStream;
        }


        public object FanArt
        {
            get
            {
                if (_fanArt == null)
                {
                    _appContext.ImageManager.GetImage(_fanartPath, SetFanArt);
                }
                return this._fanArt;
            }
            private set { _fanArt = value; OnPropertyChanged(); }
        }

        private void SetFanArt(object obj)
        {
            FanArt = obj;
        }

        public object Banner
        {
            get
            {
                if (!_bannerLoaded)
                {
                    _appContext.ImageManager.GetImage(_bannerPath, SetBanner);
                }
                return this._banner;
            }
            private set { _banner = value; OnPropertyChanged(); }
        }

        private void SetBanner(object obj)
        {
            _bannerLoaded = true;
            Banner = obj;
        }

        public void SetImages(KODIRPC.Media.Details.Base baseDetails)
        {
            _imageLoaded = false;
            _fanArt = null;
            _image = null;
            _imagePath = baseDetails.thumbnail;
            _fanartPath = baseDetails.fanart;
            OnPropertyChanged("Image");
            OnPropertyChanged("FanArtImage");
        }
    }
}