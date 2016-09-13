using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Core;
using KODIRPC.Application;
using KODIRPC.Application.Property;
using KODIRPC.Global;

namespace Xbmc2S.Model
{
    public class RemoteVm:BindableBase
    {
        private readonly IAppContext _appContext;
        private int _volumeLevel;
        private bool _volumeEnabled;
        public ICommand Select { get; private set; }
        public ICommand Up { get; private set; }
        public ICommand Down { get; private set; }
        public ICommand Right { get; private set; }
        public ICommand Left { get; private set; }
        public ICommand Home { get; private set; }
        public ICommand Info { get; private set; }
        public ICommand OSD { get; private set; }
        public ICommand Eject { get; private set; }
        public ICommand Back { get; private set; }
        public ICommand ContextMenu { get; private set; }

        public int VolumeLevel
        {
            get { return _volumeLevel; }
            set
            {
                SetProperty(ref _volumeLevel, value);
                SendVolumeChange();
            }
        }

        private async Task SendVolumeChange()
        {
            await _appContext.XBMC.Application.SetVolume(VolumeLevel);
        }

        public bool VolumeEnabled
        {
            get { return _volumeEnabled; }
            private set { SetProperty(ref _volumeEnabled, value); }
        }

        public ICommand Mute { get; private set; }
        public ICommand UnMute { get; private set; }

        public RemoteVm(IAppContext appContext)
        {
            _appContext = appContext;
            Select = new RcCommand(appContext.XBMC.Input.Select);
            Up = new RcCommand(appContext.XBMC.Input.Up);
            Down = new RcCommand(appContext.XBMC.Input.Down);
            Left = new RcCommand(appContext.XBMC.Input.Left);
            Right = new RcCommand(appContext.XBMC.Input.Right);
            Home = new RcCommand(appContext.XBMC.Input.Home);
            Info = new RcCommand(appContext.XBMC.Input.Info);
            OSD = new RcCommand(appContext.XBMC.Input.ShowOSD);
            Eject = new RcCommand(appContext.XBMC.System.EjectOpticalDrive);
            Back = new RcCommand(appContext.XBMC.Input.Back);
            ContextMenu = new RcCommand(appContext.XBMC.Input.ContextMenu);

            Mute = new DelegateCommand(MuteExecuted);
            UnMute = new DelegateCommand(UnMuteExecuted);
        }

        private async void UnMuteExecuted()
        {
            await _appContext.XBMC.Application.SetMute(false);
            await Refresh();
        }

        private async void MuteExecuted()
        {
            await _appContext.XBMC.Application.SetMute(true);
            await Refresh();
        }

        public async void SendText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                await _appContext.XBMC.Input.SendText(text);
            }
        }

        public async Task Refresh()
        {
            var props = await _appContext.XBMC.Application.GetProperties(new GetProperties_properties()
            {
                Name.muted,
                Name.volume
            });

            SetProperty(ref _volumeLevel, props.volume, "VolumeLevel");
            VolumeEnabled = !props.muted;
        }
    }

    public class RcCommand : ICommand
    {
        private readonly Func<Task> _command;

        public RcCommand(Func<Task> command)
        {
            _command = command;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await _command();
        }

        public event EventHandler CanExecuteChanged;
    }
}
