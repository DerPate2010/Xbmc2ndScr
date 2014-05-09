using System;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using XBMCRPC.Video.Details;
using Xbmc2S.RT.Common;

namespace Xbmc2S.RT.Model
{
    internal abstract class BaseVM:BindableBase
    {
        private readonly Base _baseDetails;
        private IServerInfo _server;
        private static Uri _baseUri = new Uri("ms-appx:///");
        private ImageSource _image = new BitmapImage(new Uri(_baseUri, "Assets/DarkGray.png"));
        private string _label;
        private string _secondLabel;
        protected string _imagePath;
        private bool _imageLoaded;


        public BaseVM(XBMCRPC.Video.Details.Base baseDetails, IServerInfo server)
        {
            _baseDetails = baseDetails;
            _imagePath = _baseDetails.art.poster;
            if (_imagePath == null)
            {
                _imagePath = _baseDetails.thumbnail;
            }
            _fanart = _baseDetails.art.fanart;
            if (_fanart == null)
            {
                _fanart = _baseDetails.fanart;
            }
            _server = server;
        }       
        public BaseVM(string thumb, IServerInfo server)
        {
            _server = server;
            _imagePath = thumb;
        }
        public BaseVM(string thumb,string bg , IServerInfo server)
        {
            _server = server;
            _imagePath = thumb;
            _fanart = bg;
        }

        public ImageSource Image
        {
            get
            {
                if(!_imageLoaded)
                {
                    //this._image = new BitmapImage(new Uri(SampleDataCommon._baseUri, this._imagePath));
                    _server.ImageManager.GetImage(_imagePath,SetImage);
                }
                return this._image;
            }

            private set { _image = value; OnPropertyChanged(); }
        }

        public string Label
        {
            get { return _label; }
            protected set { _label = value; OnPropertyChanged();}
        }       
        
        public string SecondLabel
        {
            get { return _secondLabel; }
            protected set { _secondLabel = value; OnPropertyChanged(); }
        }



        private void SetImage(IRandomAccessStream randomAccessStream)
        {
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, () =>
                    {
                        _imageLoaded = true;
                        var bi = new BitmapImage();
                        bi.SetSource(randomAccessStream);
                        Image = bi;

                    });
        }
        
        private ImageSource _fanArtImage = null;
        private string _fanart;

        public ImageSource FanArtImage
        {
            get
            {
                if (_fanArtImage == null)
                {
                    _server.ImageManager.GetImage(_fanart, SetFanArt);
                }
                return this._fanArtImage;
            }
        }

        private void SetFanArt(IRandomAccessStream obj)
        {
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, () =>
                {
                    var bi = new BitmapImage();
                    bi.SetSource(obj);
                    _fanArtImage = bi;
                    this.OnPropertyChanged("FanArtImage");

                });
        }


        public virtual void NavigateToDetails(Frame frame){}
    }
}