using System.Windows.Input;
using Okra.Core;
using XBMCRPC.Audio.Details;
using Base = XBMCRPC.Video.Details.Base;

namespace Xbmc2S.RT.Model
{
    internal abstract class PlayableItemVm:BaseVM
    {

        protected PlayableItemVm(Base baseDetails, IServerInfo server) : base(baseDetails, server)
        {
            WatchedCheck = baseDetails.playcount > 0;
            Play= new DelegateCommand(PlayExecute);
        }        
        
        protected PlayableItemVm(Song baseDetails, IServerInfo server) : base(baseDetails.thumbnail, server)
        {
            WatchedCheck = baseDetails.playcount > 0;
            Play= new DelegateCommand(PlayExecute);
        }
        protected PlayableItemVm(Album baseDetails, IServerInfo server) : base(baseDetails.thumbnail, server)
        {
            WatchedCheck = baseDetails.playcount > 0;
            Play= new DelegateCommand(PlayExecute);
        }

        protected abstract void PlayExecute();

        private bool _watchedCheck;
        public bool WatchedCheck
        {
            get { return _watchedCheck; }
            set { _watchedCheck = value; OnPropertyChanged(); }
        }

        public bool IsWatched
        {
            get
            {
                return WatchedCheck;
            }
            set
            {
                if (SetProperty(ref _watchedCheck, value))
                {
                    SetWatched(value);
                }
            }
        }

        public ICommand Play { get; private set; }

        protected abstract void SetWatched(bool value);
    }
}