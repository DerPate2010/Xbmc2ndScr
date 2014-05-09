using System;
using System.Threading.Tasks;

namespace Xbmc2S.Model
{
    public interface ILauncher
    {
        Task LaunchUriAsync(Uri uri);
        Task LaunchUriAsync(Uri uri, string mimetype);
    }
}