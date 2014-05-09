using Xbmc2S.RT.Common;

namespace Xbmc2S.RT.Model
{
    class Settings:BindableBase
    {
        private static Settings _current;
        private bool _showWatched=true;
        public bool ShowWatched
        {
            get { return _showWatched; }
            set { _showWatched = value; OnPropertyChanged();}
        }

        public static Settings Current
        {
            get
            {
                if (_current==null)
                {
                    _current= new Settings();
                }
                return _current;
            }
        }
    }
}
