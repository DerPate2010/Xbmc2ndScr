using Okra.Core;
using Xbmc2S.Model;

namespace Xbmc2S.RT
{
    public  class  BackupSettingsVm:BindableBase
    {
        private ISettingsManager _settingsMan;
        private bool? _isEnabled;

        public BackupSettingsVm()
        {
            _settingsMan = App.PlatformServices.SettingsManager;
            Enable = new DelegateCommand(EnableExecuted,EnableCanExecute);
            Disable = new DelegateCommand(DisableExecuted, DisableCanExecute);
        }

        private bool DisableCanExecute()
        {
            return _settingsMan.BackupEnabled;
        }

        private void DisableExecuted()
        {
            _settingsMan.DisableBackup();
            UpdateState();
        }

        private bool EnableCanExecute()
        {
            return !_settingsMan.BackupEnabled;
        }

        private async void EnableExecuted()
        {
            await _settingsMan.EnableBackup();
            UpdateState();
        }

        private void UpdateState()
        {
            IsEnabled = _settingsMan.BackupEnabled;
            Enable.NotifyCanExecuteChanged();
            Disable.NotifyCanExecuteChanged();
        }

        public bool IsEnabled
        {
            get
            {
                if (_isEnabled == null)
                {
                    _isEnabled = _settingsMan.BackupEnabled;
                }
                return _isEnabled.GetValueOrDefault();
            }
            private set { SetProperty(ref _isEnabled, value); }
        }

        public DelegateCommand Enable { get; private set; }
        public DelegateCommand Disable { get; private set; }
    }
}