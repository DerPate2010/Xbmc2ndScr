using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI.ViewManagement;
using Xbmc2S.Model;

namespace Xbmc2S.RT.PlatformServices
{
    public class LauncherWp:ILauncher
    {
        public async Task LaunchUriAsync(Uri uri)
        {
            if (uri.IsFile)
            {
                StorageFile sf = await StorageFile.GetFileFromPathAsync(uri.LocalPath);
                await Launcher.LaunchFileAsync(sf);
            }
            else
            {
                await Launcher.LaunchUriAsync(uri);    
            }
            
        }

        public async Task LaunchUriAsync(Uri uri, string mimetype)
        {
            if (!await LaunchViaM3U(uri))
            {
                await LaunchUriDirect(uri, mimetype);
            }
        }

        private async Task<bool> LaunchUriDirect(Uri uri, string mimetype)
        {
            var options = new LauncherOptions();
            options.ContentType = mimetype;
            options.DisplayApplicationPicker = false;
            ModifyOptions(options);
            return await Launcher.LaunchUriAsync(uri, options);
        }

        protected virtual void ModifyOptions(LauncherOptions options)
        {
        }

        private async Task<bool> LaunchViaM3U(Uri uri)
        {
            var file =
                await
                    ApplicationData.Current.TemporaryFolder.CreateFileAsync("file.m3u", CreationCollisionOption.ReplaceExisting);

            using (var stream = await file.OpenStreamForWriteAsync())
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    sw.WriteLine(uri.ToString());
                }
            }

            var options = new LauncherOptions();
            ModifyOptions(options);
            return await Launcher.LaunchFileAsync(file, options);
        }
    }
}
