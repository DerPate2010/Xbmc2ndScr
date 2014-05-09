using System;
using System.Threading.Tasks;

namespace Xbmc2S.Model
{
    public interface ICurrentPlayingItem
    {
        string Id { get; }
        double Percentage { get; }
        TimeSpan TotalTime { get; }
        TimeSpan Time { get; }
        Task Pause();
        Task Stop();
        Task Skip();
        Task SkipBack();
        Task Refresh();
        Task Seek(double percent);
        void RefreshTime();
        void GotoDetails();
    }
}