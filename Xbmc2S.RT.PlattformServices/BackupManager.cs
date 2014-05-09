using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Live;
using Windows.Storage;

namespace Xbmc2S.RT.PlatformServices
{
    internal class BackupManager
    {
        private LiveAuthClient _authClient;
        private LiveConnectClient _liveClient;
        private readonly IEnumerable<string> scopes = new string[] { "wl.signin"
            //,"wl.basic"
            ,"wl.skydrive_update" };

        private LiveConnectSession _session;
        private string _skyDriveFolderId;

        private readonly ConcurrentQueue<string> _filesToBackup = new ConcurrentQueue<string>();
        private DateTime _timeForBackup;
        private Task _backupTask;

        private static readonly TimeSpan HoldBackTime= TimeSpan.FromSeconds(30);

        public async Task Backup(string filename)
        {
            if (!_filesToBackup.Contains(filename))
            {
                _filesToBackup.Enqueue(filename);
            }
            _timeForBackup = DateTime.Now.Add(HoldBackTime);
            StartBackupIfNecessary();
        }

        private void StartBackupIfNecessary()
        {
            if (_backupTask == null || _backupTask.IsCompleted)
            {
                _backupTask = DoBackup();
            }
        }

        private async Task DoBackup()
        {
            while (DateTime.Now<_timeForBackup)
            {
                await Task.Delay(HoldBackTime);
            }
            string filename;
            while (_filesToBackup.TryDequeue(out filename)) 
            {
                await DoBackup(filename);
            }
        }

        private async Task DoBackup(string filename)
        {
            if (await SignInSkydrive())
            {
                await LoadData();

                StorageFile backupFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                if (backupFile != null && _skyDriveFolderId != null)
                {
                    LiveConnectClient client = new LiveConnectClient(_session);
                    LiveOperationResult operationResult =
                        await
                        client.BackgroundUploadAsync(_skyDriveFolderId, filename, backupFile,
                                                     OverwriteOption.Overwrite);
                    dynamic result = operationResult.Result;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public async Task Restore(string filename)
        {
            if (await SignInSkydrive())
            {
                await LoadData();

                try
                {
                    StorageFile restoreFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                    LiveConnectClient client = new LiveConnectClient(_session);
                    LiveOperationResult liveOpResult2 = await client.GetAsync(_skyDriveFolderId + "/files");
                    dynamic result = liveOpResult2.Result;
                    string backupFileID = null;
                    foreach (var item in result.data)
                    {
                        if (item.name == filename)
                        {
                            backupFileID = item.id;
                            break;
                        }
                    }
                    if (backupFileID != null)
                    {
                        LiveDownloadOperationResult operationResult = await client.BackgroundDownloadAsync(backupFileID + "/content", restoreFile);
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception("Error during restore: " + exception.Message);
                }
            }
        }

        private async Task LoadData()
        {
            const string folderName = "Xbmc2ndScr";
            const string appDataName = "Application Data";
            const string rootFolder = "me/skydrive";

            LiveConnectClient client = new LiveConnectClient(_session);
            var appDataFolder = await GetFolder(client, rootFolder, appDataName);
            _skyDriveFolderId = await GetFolder(client, appDataFolder, folderName);
        }

        private static async Task<string> GetFolder(LiveConnectClient client, string parentFolder, string folderName)
        {
            string skyDriveFolderId=null;
            LiveOperationResult liveOpResult = await client.GetAsync(parentFolder + "/files?filter=folders");

            dynamic appResult = liveOpResult.Result;

            List<object> folderData = appResult.data;
            foreach (dynamic folder in folderData)
            {
                string name = folder.name;
                if (name == folderName)
                {
                    skyDriveFolderId = folder.id;
                }
            }

            //Create your Folder on SkyDrive if does not exist
            if (string.IsNullOrEmpty(skyDriveFolderId))
            {
                var skyDriveFolderData = new Dictionary<string, object>();
                skyDriveFolderData.Add("name", folderName);
                LiveOperationResult operationResult = await client.PostAsync(parentFolder, skyDriveFolderData);
                dynamic result = operationResult.Result;
                skyDriveFolderId = result.id;
            }
            return skyDriveFolderId;
        }

        public async Task<bool> SignInSkydrive()
        {

            try
            {

                _authClient = new LiveAuthClient();
                LiveLoginResult loginResult = await this._authClient.LoginAsync(scopes);
                if (loginResult.Status == LiveConnectSessionStatus.Connected)
                {
                    _liveClient = new LiveConnectClient(loginResult.Session);
                    _session = loginResult.Session;
                    return true;
                }
            }
            catch (LiveAuthException authExp)
            {
            }
            return false;
        }
    }
}