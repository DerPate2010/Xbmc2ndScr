using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Xbmc2S.Model;

namespace Xbmc2S.RT.PlatformServices
{
    internal class SettingsManager :BindableBase, ISettingsManager
    {
        //private BackupManager _backupManager;
        //private bool? _backupEnabled;
        //public bool BackupEnabled
        //{
        //    get
        //    {
        //        if (_backupEnabled == null)
        //        {
        //            _backupEnabled = GetSetting("SettingsManager_BackupEnabled", false, true);
        //        }
        //        return _backupEnabled.GetValueOrDefault();
        //    }
        //    private set
        //    {
        //        if (SetProperty(ref _backupEnabled, value))
        //        {
        //            SetSetting("SettingsManager_BackupEnabled", value, true);
        //        }
        //    }
        //}

        //public async Task EnableBackup()
        //{
        //    if (await BackupManager.SignInSkydrive())
        //    {
        //        BackupEnabled = true;
        //    }
        //}

        //public void DisableBackup()
        //{
        //    BackupEnabled = false;
        //}

        //private BackupManager BackupManager
        //{
        //    get
        //    {
        //        if (_backupManager == null)
        //        {
        //            _backupManager= new BackupManager();
        //        }
        //        return _backupManager;
        //    }
        //}

        public T GetSetting<T>(string key, T defaultValue, bool remote)
        {
            object value;
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue(key, out value))
            {
                return (T) value;
            }

            return defaultValue;

        }

        public void SetSetting<T>(string propertyName, T value, bool remote)
        {
            ApplicationData.Current.LocalSettings.Values[propertyName] = value;
        }

        public Task SaveData<T>(string filename, T data, bool remote = false)
        {
            var savetask = SaveDataInternal(filename, data);
            //if (remote && BackupEnabled)
            //{
            //    BackupManager.Backup(filename);
            //}
            return savetask;
        }

        public async Task SaveDataInternal<T>(string filename, T data)
        {
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                using (IRandomAccessStream raStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    using (IOutputStream outStream = raStream.GetOutputStreamAt(0))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(data.GetType());
                        serializer.WriteObject(outStream.AsStreamForWrite(), data);
                        await outStream.FlushAsync();
                    }
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public async Task<T> LoadData<T>(string filename, Func<T> makeDefault, bool remote = false)
        {
            //if (remote && BackupEnabled)
            //{
            //    await BackupManager.Restore(filename);
            //}
            return await LoadDataInternal<T>(filename, makeDefault);
        }

        public async Task<T> LoadDataInternal<T>(string filename, Func<T> makeDefault)
        {

            T data;
            StorageFile file;
            try
            {
                var files = (await ApplicationData.Current.LocalFolder.GetFilesAsync()).Select(f=>f.Name).ToList();
                var exists=files.Contains(filename);
                if (!exists)
                {
                    if (makeDefault != null)
                    {
                        return makeDefault();
                    }
                    return default(T);
                }
                file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                using (IInputStream inStream = await file.OpenSequentialReadAsync())
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    data = (T)serializer.ReadObject(inStream.AsStreamForRead());
                    return data;
                }
            }
            catch (Exception ex)
            {
                if (makeDefault != null)
                {
                    return makeDefault();
                }
                return default(T);
            }
        }
    }

    
}