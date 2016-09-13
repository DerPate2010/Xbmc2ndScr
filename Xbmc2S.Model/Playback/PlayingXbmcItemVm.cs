using System;
using System.Threading.Tasks;
using KODIRPC;
using KODIRPC.Global;
using KODIRPC.List.Item;
using KODIRPC.Methods;
using KODIRPC.Player;
using KODIRPC.Player.Property;
using Base = KODIRPC.Video.Details.Base;

namespace Xbmc2S.Model
{
    public abstract class PlayingXbmcItemVm:BaseVM, ICurrentPlayingItem
    {
        private double _percentage;
        private Value _properties;
        private TimeSpan _totalTime;
        private TimeSpan _time;

        protected PlayingXbmcItemVm(Base baseDetails, int playerid, IAppContext appContext)
            : base(baseDetails, appContext)
        {
            Player = playerid;
        }

        protected PlayingXbmcItemVm(KODIRPC.Media.Details.Base baseDetails, int playerid, IAppContext server)
            : base(baseDetails, server)
        {
            Player = playerid;
        }


        public int Player { get; set; }


        public abstract string Id { get; }


        public async Task Pause()
        {
            await _appContext.XBMC.Player.PlayPause(Player, Toggle2.toggle);
        }

        public async Task Stop()
        {
            await _appContext.XBMC.Player.Stop(Player);
        }

        public async Task Skip()
        {
            await _appContext.XBMC.Player.Open( new Open_item1(){
                
                    playlistid = Properties.playlistid,
                    position = Properties.position + 1
                 });

        }

        public async Task SkipBack()
        {
            await _appContext.XBMC.Player.Open(new Open_item1()
                {
                    playlistid = Properties.playlistid,
                    position = Properties.position - 1
                });

        }
        private TimeSpan ToDateTime(Time time)
        {
            return new TimeSpan(0, time.hours, time.minutes, time.seconds, 0);
        }


        public async Task Refresh()
        {
            Properties = await _appContext.XBMC.Player.GetProperties(Player,GetProperties_properties.AllFields());
            Time = ToDateTime(Properties.time);
            TotalTime = ToDateTime(Properties.totaltime);
            //Percentage = Properties.percentage;
            Percentage = ((double)Time.Ticks * 100 / TotalTime.Ticks);

        }

        public async Task Seek(double percent)
        {
            await _appContext.XBMC.Player.Seek(Player, percent);
        }

        public void RefreshTime()
        {
            Time = Time.Add(TimeSpan.FromSeconds(Properties.speed));
            Percentage = ((double)Time.Ticks*100/TotalTime.Ticks);
        }

        public abstract void GotoDetails();

        public double Percentage
        {
            get { return _percentage; }
            private set { SetProperty(ref _percentage, value); }
        }

        public TimeSpan TotalTime
        {
            get { return _totalTime; }
            private set { SetProperty(ref _totalTime, value); }
        }

        public TimeSpan Time
        {
            get { return _time; }
            private set { SetProperty(ref _time, value); }
        }
        public Value Properties
        {
            get { return _properties; }
            private set { _properties = value; OnPropertyChanged(); }
        }
    }
}