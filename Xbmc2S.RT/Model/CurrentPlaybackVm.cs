using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Core;
using Windows.UI.Xaml.Controls;
using XBMCRPC;
using XBMCRPC.Global;
using XBMCRPC.List.Item;
using XBMCRPC.Methods;
using XBMCRPC.Player.Property;
using Xbmc2S.RT.Common;
using All = XBMCRPC.List.Fields.All;
using Base = XBMCRPC.Video.Details.Base;

namespace Xbmc2S.RT.Model
{
    abstract class CurrentPlayingItemVm:BaseVM
    {
        protected CurrentPlayingItemVm(Base baseDetails, int playerid, IServerInfo server)
            : base(baseDetails, server)
        {
            Player = playerid;
        }

        protected CurrentPlayingItemVm(string thumb, string bg, int playerid, IServerInfo server)
            : base(thumb, bg, server)
        {
            Player = playerid;
        }

        public int Player { get; set; }


    }
    class CurrentPlayingVideoVm : CurrentPlayingItemVm
    {
        private readonly AllFile _baseDetails;

        public CurrentPlayingVideoVm(XBMCRPC.List.Item.AllFile baseDetails, int playerid, IServerInfo server)
            : base(baseDetails, playerid, server)
        {
            _baseDetails = baseDetails;
            Label = baseDetails.title;
        }

        public override void NavigateToDetails(Frame frame)
        {
            MainVm.Current.DirectToMovie(_baseDetails.id);
            frame.Navigate(typeof(MovieDetailPage));
        }
    }
    class CurrentPlayingAudioVm : CurrentPlayingItemVm
    {
        private readonly AllMedia _baseDetails;

        public CurrentPlayingAudioVm(XBMCRPC.List.Item.AllMedia baseDetails, int playerid, IServerInfo server)
            : base(baseDetails.thumbnail,baseDetails.fanart, playerid, server)
        {
            _baseDetails = baseDetails;
            Label = baseDetails.title;
        }

        public override void NavigateToDetails(Frame frame)
        {
            frame.Navigate(typeof(AlbumPage), _baseDetails.albumid);
        }
    }

    internal class CurrentPlaybackVm:BindableBase
    {
        private readonly ServerInfo _server;

        private double _percentage;
        private CurrentPlayingItemVm _currentItem;
        private Value _properties;
        private TimeSpan _totalTime;
        private TimeSpan _time;
        private bool _isPlaying;
        //private int wellKnownPlayerIdVideo = 1;

        public CurrentPlayingItemVm CurrentItem
        {
            get { return _currentItem; }
            set { _currentItem = value;  OnPropertyChanged(); }
        }

        public CurrentPlaybackVm(ServerInfo server)
        {
            _server = server;

            Pause= new DelegateCommand(PauseExecuted,PauseCanExecute);
            Stop= new DelegateCommand(StopExecuted);
            Skip= new DelegateCommand(SkipExecuted);
            SkipBack= new DelegateCommand(SkipBackExecuted);

            GetCurrentPlayingItem();
        }

        private async void SkipBackExecuted()
        {
            await _server.XBMC.Player.Open2(new Player.Openitem1()
            {
                playlistid = Properties.playlistid,
                position = Properties.position + 1
            });
            CurrentItem = null;
        }

        private async void SkipExecuted()
        {
            await _server.XBMC.Player.Open2(new Player.Openitem1()
                {
                    playlistid = Properties.playlistid,
                    position = Properties.position + 1
                });
            CurrentItem = null;
        }

        private async void StopExecuted()
        {
            await _server.XBMC.Player.Stop(CurrentItem.Player);
            CurrentItem = null;

        }

        private bool PauseCanExecute()
        {
            return true;
            return Properties != null && !Properties.live;
        }

        private async void PauseExecuted()
        {
            await _server.XBMC.Player.PlayPause(CurrentItem.Player, Toggle.toggle);
        }

        protected CurrentPlaybackVm()
        {
        }

        CurrentPlayingItemVm CurrentItemFactory(XBMCRPC.List.Item.All currentItem, int playerid)
        {
            if (currentItem is AllFile)
            {
                return new CurrentPlayingVideoVm((AllFile) currentItem, playerid,_server);
            }
            if (currentItem is AllMedia)
            {
                return new CurrentPlayingAudioVm((AllMedia) currentItem, playerid, _server);
            }
            throw new NotSupportedException();
        }

        private async Task GetCurrentPlayingItem()
        {

            while (true)
            {
                var activePlayers = await _server.XBMC.Player.GetActivePlayers();
                if (activePlayers.Length == 0)
                {
                    IsPlaying = false;
                    CurrentItem = null;
                    await Task.Delay(TimeSpan.FromSeconds(10));
                }
                else
                {
                    var activePlayer = activePlayers[0];
                    //switch (activePlayer.type)
                    //{
                    //    case Type.audio:
                    //        break;
                    //    case Type.video:
                    //        break;
                    //    case Type.picture:
                    //        break;
                    //}

                    IsPlaying = true;
                    if (CurrentItem == null)
                    {
                        var getCurrentItemResponse =
                            await _server.XBMC.Player.GetItem(activePlayer.playerid, All.AllFields());
                        var currentPlayingVideo = getCurrentItemResponse.item;
                        CurrentItem = CurrentItemFactory(currentPlayingVideo, activePlayer.playerid);
                    }

                    Properties = await _server.XBMC.Player.GetProperties(activePlayer.playerid, Client.AllValues<Name>());
                    Percentage = Properties.percentage;
                    Time = ToDateTime(Properties.time);
                    TotalTime = ToDateTime(Properties.totaltime);
                    await Task.Delay(OneSecond);
                    Time = Time.Add(TimeSpan.FromSeconds(Properties.speed));
                    await Task.Delay(OneSecond);
                }
            }
        }

        private static TimeSpan OneSecond = TimeSpan.FromSeconds(1);

        private TimeSpan ToDateTime(Time time)
        {
            return new TimeSpan(0,time.hours,time.minutes, time.seconds,0);
        }

        public Value Properties
        {
            get { return _properties; }
            set { _properties = value; OnPropertyChanged(); }
        }

        public double Percentage
        {
            get { return _percentage; }
            set { _percentage = value; OnPropertyChanged(); }
        }

        public TimeSpan TotalTime
        {
            get { return _totalTime; }
            set { _totalTime = value; OnPropertyChanged();}
        }

        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; OnPropertyChanged();}
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { _isPlaying = value; OnPropertyChanged();}
        }

        public ICommand Pause { get; set; }
        public ICommand Stop { get; set; }
        public ICommand Skip { get; set; }
        public ICommand SkipBack { get; set; }
    }
}