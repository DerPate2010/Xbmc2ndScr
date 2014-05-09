using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using StreamClient.VLM;
using StreamingClient.StreamManagment;

namespace Xbmc2S.Model.Download
{
    [DataContract]
    public class DownloadItem:BindableBase
    {
        [DataMember]
        protected readonly DownloadDefinition DownloadDefinition;
        protected IAppContext _appContext;
        private byte _progress;
        private DownloadStatus _status;
        private string _ref;
        private string _label;
        private string _filename;
        private Uri _url;
        private TransferInfo _transfer;
        private string _errorMessage;

        public event EventHandler StatusChanged;

        private static VlcAccess _vlc;

        [DataMember]
        public VlmJob TranscodeJob { get; set; }
        
        [DataMember]
        public string Lores { get; set; }

        private VlcAccess Vlc
        {
            get
            {
                if (_vlc == null)
                {
                    var settings = _appContext.Settings.GetVlcSettings();
                    _vlc = new VlcAccess(settings);
                }
                return _vlc;
            }
        }

        public DownloadItem(DownloadDefinition downloadDefinition, IAppContext appContext)
        {
            DownloadDefinition = downloadDefinition;
            _appContext = appContext;
            Url = downloadDefinition.Source;
            Filename = downloadDefinition.Filename;
            Label = downloadDefinition.Label;
        }
        public DownloadItem()
        {
            IsDetached = true;
        }

        public bool IsDetached { get; set; }

        private async Task PrepareDownload()
        {
            Transfer = await _appContext.PlatformServices.BackgroundTransfer.AddTransfer(DownloadDefinition);
            Transfer.PropertyChanged += Transfer_PropertyChanged;
            Status = DownloadStatus.Downloading;
        }

        public virtual async Task Start()
        {
            Debug.Assert(Status==DownloadStatus.NotStarted);
            try
            {
                if (DownloadDefinition.Transcode)
                {
                    await PrepareTranscoding();
                }
                else
                {
                    var source = await _appContext.XBMC.PrepareDownload(DownloadDefinition.Path);
                    DownloadDefinition.Source = source;
                    await PrepareDownload();
                }
            }
            catch (Exception ex)
            {
                Status = DownloadStatus.Error;
                ErrorMessage = ex.Message;
            }
        }

        private async Task PrepareTranscoding()
        {
            TranscodeJob = new VlmJob(Vlc);
            var sourceDir = System.IO.Path.GetDirectoryName(DownloadDefinition.Path);
            var sourceFilename = System.IO.Path.GetFileNameWithoutExtension(DownloadDefinition.Path);
            var sourceExtension = System.IO.Path.GetExtension(DownloadDefinition.Path);
            Lores = System.IO.Path.Combine(sourceDir, sourceFilename + "_lores.mp4");
            var loresMissing= await PlayableItemVm.CalcAvailability(_appContext, Lores);
            if (loresMissing)
            {
                var sourceUri = new Uri(DownloadDefinition.Path);
                TranscodeJob.PropertyChanged += TranscodeJobPropertyChanged;
                try
                {
                    await
                        TranscodeJob.Transcode(sourceUri.ToString(), Lores, DownloadDefinition.AudioTrack,
                                               DownloadDefinition.SubtitleTrack);

                }
                catch (WebException wex)
                {
                    if (wex.Response!=null &&((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.Forbidden)
                    {
                        _appContext.View.ErrorMessage("The VLC rejected the request. Please check the tutorial. (see the chapter \"Access control\")");
                    }
                    Status=DownloadStatus.Error;
                    ErrorMessage = wex.Message;
                    return;
                }
                Status = DownloadStatus.Transcoding;
            }
            else
            {
                await PrepareLoresDownload();
            }
        }

        void TranscodeJobPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CalcTranscodeProperties();
        }

        private async Task CalcTranscodeProperties()
        {
            Progress = CalcTranscodeProgress(TranscodeJob.Progress);
            
            if (IsFinalTranscodingState(TranscodeJob.Status))
            {
                TranscodeJob.PropertyChanged -= TranscodeJobPropertyChanged;
                await TranscodeJob.Abort();
                if (Status == DownloadStatus.Transcoding)
                {
                    await PrepareLoresDownload();
                }
            }
        }

        private async Task PrepareLoresDownload()
        {
            Uri dlInfo;
            try
            {
                var hiresMissing = await PlayableItemVm.CalcAvailability(_appContext, DownloadDefinition.Path);
                dlInfo = await _appContext.XBMC.PrepareDownload(Lores);
            }
            catch (Exception ex)
            {
                Status= DownloadStatus.Error;

                ErrorMessage = ex.Message;
                return;
            }

            DownloadDefinition.Source = dlInfo;
            DownloadDefinition.Filename = System.IO.Path.ChangeExtension(DownloadDefinition.Filename, "mp4");
            await PrepareDownload();
        }

        [DataMember]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value;  OnPropertyChanged();}
        }


        private byte CalcTranscodeProgress(byte progress)
        {
            return (byte)(progress / 2);
        }

        private bool IsFinalTranscodingState(VlmStatus status)
        {
            return status == VlmStatus.Stopped || status == VlmStatus.None;
        }


        public async virtual Task Attach(IAppContext appContext)
        {
            _appContext=appContext;
            switch (Status)
            {
                case DownloadStatus.Transcoding:
                    TranscodeJob.PropertyChanged += TranscodeJobPropertyChanged;
                    TranscodeJob.Attach(Vlc);
                    break;
                case DownloadStatus.Downloading:
                    Transfer = await _appContext.PlatformServices.BackgroundTransfer.GetTransfer(Transfer.TransferId);
                    Transfer.PropertyChanged += Transfer_PropertyChanged;
                    CalcProperties();
                    break;
            }
        }


        public async Task Stop()
        {
            try
            {
                switch (Status)
                {
                    case DownloadStatus.Transcoding:
                        await TranscodeJob.Abort();
                        break;
                    case DownloadStatus.Downloading:
                        _appContext.PlatformServices.BackgroundTransfer.StopTransfer(Transfer.TransferId);
                        break;
                }
                Status = DownloadStatus.Canceled;
            }
            catch (Exception ex)
            {
                Status = DownloadStatus.Error;

                ErrorMessage = ex.Message;
            }
        }

        void Transfer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CalcProperties();
        }

        private void CalcProperties()
        {
            Progress = CalcProgress(Transfer.Progress);
            if (Progress == 100)
            {
                Status=DownloadStatus.Finished;
            }
            if (DownloadManager.IsFinalState(Status))
            {
                Transfer.PropertyChanged -= Transfer_PropertyChanged;
            }
        }

        byte CalcProgress(byte progress)
        {
            if (DownloadDefinition.Transcode)
            {
                return (byte)((progress / 2) + 50);
            }
            return progress;
        }

        [DataMember]
        public Uri Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        [DataMember]
        public string Filename
        {
            get { return _filename; }
            set { SetProperty(ref _filename, value); }
        }

        [DataMember]
        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }

        [DataMember]
        public string Ref
        {
            get { return _ref; }
            set { SetProperty(ref _ref, value); }
        }

        [DataMember]
        public DownloadStatus Status
        {
            get { return _status; }
            set
            {
                if (SetProperty(ref _status, value))
                {
                    EventHandler temp = StatusChanged;
                    if (temp != null)
                    {
                        temp(this, new EventArgs());
                    }
                }
            }
        }

        [DataMember]
        public byte Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }

        [DataMember]
        public TransferInfo Transfer
        {
            get { return _transfer; }
            set { SetProperty(ref _transfer, value); }
        }

        public async void Play()
        {
            await _appContext.PlatformServices.Launcher.LaunchUriAsync(new Uri(Transfer.TargetFile));
        }
    }
}