using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Core;
using KODIRPC.List.Fields;
using KODIRPC.List.Item;
using Xbmc2S.RT.UPnP;
using KODIRPC.Methods;
using KODIRPC.Player;
using All = KODIRPC.List.Fields.All;
using Base = KODIRPC.Media.Details.Base;

namespace Xbmc2S.Model
{
    public class CurrentPlaybackVm:BindableBase
    {

        private readonly AppContext _appContext;

        private ICurrentPlayingItem _currentItem;
        private bool _isPlaying;
        private List<PlaylistItemVm> _playList;
        private bool _playlistEnabled;
        //private int wellKnownPlayerIdVideo = 1;

        public ICurrentPlayingItem CurrentItem
        {
            get { return _currentItem; }
            private set { _currentItem = value;  OnPropertyChanged(); 
            }
        }

        public CurrentPlaybackVm(AppContext appContext)
        {
            _appContext = appContext;

            Pause= new DelegateCommand(PauseExecuted);
            Stop= new DelegateCommand(StopExecuted);
            Skip= new DelegateCommand(SkipExecuted);
            SkipBack= new DelegateCommand(SkipBackExecuted);

            CurrentPlayingLoop();
        }

        private async void SkipBackExecuted()
        {
            try
            {
                await CurrentItem.SkipBack();
            }
            catch (Exception)
            {
            }
            CurrentItem = null;
        }

        private async void SkipExecuted()
        {
            try
            {
                await CurrentItem.Skip();
            }
            catch (Exception)
            {
            }
            CurrentItem = null;
        }

        private async void StopExecuted()
        {
            await CurrentItem.Stop();
            CurrentItem = null;

        }

        private async void PauseExecuted()
        {
            await CurrentItem.Pause();
        }

        protected CurrentPlaybackVm()
        {
        }

        PlayingXbmcItemVm CurrentItemFactory(KODIRPC.List.Item.All currentItem, int playerid)
        {
            if (currentItem.type == Base_type.song)
            {
                return new PlayingXbmcAudioVm( currentItem, playerid, _appContext);
            }
            else
            {
                return new PlayingXbmcVideoVm(currentItem, playerid, _appContext);
            }
            throw new NotSupportedException();
        }

        private CancellationTokenSource _delayCancel;

        public void RefreshNow()
        {
            _delayCancel.Cancel();
        }
        
        private async Task CurrentPlayingLoop()
        {
            while (true)
            {
                bool failed = false;
                try
                {
                    _delayCancel= new CancellationTokenSource();
                    await GetCurrentPlayingItem(_delayCancel.Token);
                }
                catch (TaskCanceledException)
                {
                }
                catch (Exception)
                {
                    failed = true;
                }
                if (failed)
                {
                    await Task.Delay(4000);
                }
            }
        }

        private async Task GetCurrentPlayingItem(CancellationToken delayCancel)
        {
            var activePlayers = await _appContext.XBMC.Player.GetActivePlayers();
            if (activePlayers.Count == 0)
            {
                bool anyUpnp = false;
                try
                {
                    foreach (var renderer in _appContext.Upnp.AvailableRenderDevices)
                    {
                        var curPlayback = await renderer.AVTransport.GetCurrentPlaybackItem();
                        Uri curUri;
                        if (Uri.TryCreate(curPlayback.PosTrackuri, UriKind.Absolute, out curUri))
                        {
                            if (curPlayback.TranspState != "STOPPED")
                            {
                                if (await _appContext.Upnp.IsXbmcHost(curUri))
                                {
                                    anyUpnp = true;
                                    IsPlaying = true;
                                    if (CurrentItem == null || CurrentItem.Id != curPlayback.PosTrackuri)
                                    {
                                        CurrentItem = CurrentItemFactory(curPlayback);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    if (Debugger.IsAttached)
                    {
                        throw;
                    }
                }
                if (!anyUpnp)
                {
                    IsPlaying = false;
                    CurrentItem = null;
                }
                await Task.Delay(TimeSpan.FromSeconds(10),delayCancel);
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
                var getCurrentItemResponse =
                    await _appContext.XBMC.Player.GetItem(activePlayer.playerid);
                if (CurrentItem == null || CurrentItem.Id != getCurrentItemResponse.item.id.ToString())
                {
                    getCurrentItemResponse = await _appContext.XBMC.Player.GetItem(activePlayer.playerid, All.AllFields());

                    var currentPlayingVideo = getCurrentItemResponse.item;
                    CurrentItem = CurrentItemFactory(currentPlayingVideo, activePlayer.playerid);
                    await GetPlaylist(activePlayer.playerid);
                }

            }
            if (CurrentItem != null)
            {
                await CurrentItem.Refresh();
                await Task.Delay(OneSecond);
            }
            if (CurrentItem != null)
            {
                CurrentItem.RefreshTime();
                await Task.Delay(OneSecond);
            }
        }

        private ICurrentPlayingItem CurrentItemFactory(CurrentUpnpPlayback curPlayback)
        {
            return new PlayingUpnpItemVm(curPlayback, _appContext);

        }

        private static TimeSpan OneSecond = TimeSpan.FromSeconds(1);

        private async Task GetPlaylist(int player)
        {
            var playlist = await _appContext.XBMC.Playlist.GetItems(player, new All(){AllItem.title});
            if (playlist.items == null)
            {
                PlayList = null;
            }
            else
            {
                PlayList = playlist.items.Select((i, pos)=>PlaylistItemFactory(i,pos, player)).ToList();
            }
        }

        public List<PlaylistItemVm> PlayList
        {
            get { return _playList; }
            private set { _playList = value; OnPropertyChanged(); }
        }

        private PlaylistItemVm PlaylistItemFactory(KODIRPC.List.Item.All arg, int pos, int player)
        {
            return new PlaylistItemVm( arg, _appContext, pos, player);
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set
            {
                if (SetProperty(ref _isPlaying, value))
                {
                    
                }
            }
        }

        public ICommand Pause { get; private set; }
        public ICommand Stop { get; private set; }
        public ICommand Skip { get; private set; }
        public ICommand SkipBack { get; private set; }


        public bool PlaylistEnabled
        {
            get { return _playlistEnabled; }
            set { _playlistEnabled = value; OnPropertyChanged(); }
        }
    }

    public class PlaylistItemVm
    {
        private readonly AppContext _appContext;
        private readonly int _pos;
        private readonly int _player;

        public PlaylistItemVm(KODIRPC.List.Item.All all, AppContext appContext, int pos, int player)
        {
            _appContext = appContext;
            _pos = pos;
            _player = player;
            Label = ((Base)all.AsMediaDetailsBase).label;
        }


        public string Label { get; private set; }

        public async Task Open()
        {
            await _appContext.XBMC.Player.Open(new Open_item1()
            {
                playlistid = _player, position = _pos
            });
        }
    }
}