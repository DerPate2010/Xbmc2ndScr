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
    public class LauncherRT:LauncherWp
    {
        protected override void ModifyOptions(LauncherOptions options)
        {
            base.ModifyOptions(options);
            options.DesiredRemainingView = ViewSizePreference.UseNone;
        }
    }
}
