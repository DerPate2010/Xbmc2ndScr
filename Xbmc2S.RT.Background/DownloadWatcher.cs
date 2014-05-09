using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.System.Threading;
using Xbmc2S.Model;
using Xbmc2S.Model.Download;

namespace Xbmc2S.RT.Background
{
    public sealed class DownloadWatcher:IBackgroundTask
    {
        volatile bool _cancelRequested = false;
        BackgroundTaskDeferral _deferral = null;
        ThreadPoolTimer _periodicTimer = null;
        uint _progress = 0;
        IBackgroundTaskInstance _taskInstance = null;
        private IDownloadManager _downloadManager;

        //
        // The Run method is the entry point of a background task.
        //
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            Debug.WriteLine("Background " + taskInstance.Task.Name + " Starting...");
            SmartDispatcher.Initialize(new NoDispatcher());
            //
            // Associate a cancellation handler with the background task.
            //
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

            //
            // Get the deferral object from the task instance, and take a reference to the taskInstance;
            //
            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;

            var appContext = new AppContext(new PlatformServices.PlatformServices(), new NoView());

            _downloadManager = appContext.Downloads;

            _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(PeriodicTimerCallback), TimeSpan.FromMilliseconds(500));
        }

        //
        // Handles background task cancellation.
        //
        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            //
            // Indicate that the background task is canceled.
            //
            _cancelRequested = true;

            Debug.WriteLine("Background " + sender.Task.Name + " Cancel Requested...");
        }

        //
        // Simulate the background task activity.
        //
        private void PeriodicTimerCallback(ThreadPoolTimer timer)
        {
            if ((_cancelRequested == false) && (_downloadManager.TransfersPending()))
            {
                
                //_progress += 10;
                //_taskInstance.Progress = _progress;
            }
            else
            {
                _periodicTimer.Cancel();

                //var settings = ApplicationData.Current.LocalSettings;
                //var key = _taskInstance.Task.Name;

                ////
                //// Write to LocalSettings to indicate that this background task ran.
                ////
                //settings.Values[key] = (_progress < 100) ? "Canceled" : "Completed";
                //Debug.WriteLine("Background " + _taskInstance.Task.Name + ((_progress < 100) ? "Canceled" : "Completed"));

                //
                // Indicate that the background task has completed.
                //
                _deferral.Complete();
            }
        }
    }

    class NoDispatcher : IDispatcher
    {
        public bool DesignModeEnabled { get { return false; }}
        public bool HasThreadAccess { get { return true; } }
        public void RunAsync(Action a)
        {
            a();
        }
    }

    internal class NoView : IView
    {
        public event EventHandler Suspending;
        public void GotoDownloads()
        {
            
        }

        public void GotoCurrentPlaying()
        {
            
        }


        public void GotoHome()
        {
        }

        public void GotoMovies(ItemsSourceReference itemsReference)
        {
        }

        public void GotoTvShows()
        {
        }

        public void GotoMusic()
        {
        }

        public void GotoPeople()
        {
        }

        public void GotoWatchList()
        {
            
        }

        public void GotoAllMovies()
        {
            
        }

        public CultureInfo PreferedCulture { get { return CultureInfo.CurrentCulture; } }
        public void GotoMovie(ItemsSourceReference itemsReference)
        {
            
        }

        public void GotoSeason(string itemsReference)
        {
            throw new NotImplementedException();
        }

        public void GotoEpisode(string episodeRef)
        {
            
        }

        public void GotoAlbum(int albumid)
        {
            
        }

        public void PrepareDownload(StartDownloadVm startDownloadVm)
        {
            
        }

        public void ErrorMessage(string message)
        {
            
        }

        public void GotoWelcomeWizard()
        {
            
        }

        public void PlayMedia(string uri, string mimetype)
        {
            
        }
    }
}
