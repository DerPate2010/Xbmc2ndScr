using System;
using System.Threading.Tasks;

namespace Xbmc2S.Model
{
    public interface ISettingsManager
    {
        T GetSetting<T>(string key, T defaultValue, bool remote);
        void SetSetting<T>(string propertyName, T value, bool remote);
        Task SaveData<T>(string filename, T data, bool remote = false);
        Task<T> LoadData<T>(string filename, Func<T> makeDefault, bool remote = false);
        //bool BackupEnabled { get; }
        //Task EnableBackup();
        //void DisableBackup();
    }
}