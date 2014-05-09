using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using StreamClient.VLM;
using StreamingClient.StreamManagment;

namespace Xbmc2S.Model.Download
{
    [DataContract]
    public class VlmJob:BindableBase
    {
        private VlcAccess _vlc;
        private Task _monitoringTask;
        private byte _progress;
        private VlmStatus _status;
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public VlmStatus Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        [DataMember]
        public byte Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }

        private bool IsDetached { get; set; }

        public VlmJob()
        {
            IsDetached = true;
        }

        public void Attach(VlcAccess vlc)
        {
            _vlc = vlc;
            _monitoringTask = MonitorState();
        }

        public VlmJob(VlcAccess vlc)
        {
            _vlc = vlc;
            Status= VlmStatus.Unknown;
            Name = Guid.NewGuid().ToString("N");
        }
        
        private async Task MonitorState()
        {
            await Task.Delay(5000);
            while (true)
            {
                await UpdateState();
                if (IsFinalState(Status))
                {
                    break;
                }
                await Task.Delay(5000);
            }
        }

        private bool IsFinalState(VlmStatus status)
        {
            switch (status)
            {
                case VlmStatus.None:
                case VlmStatus.Stopped:
                    return true;
            }
            return false;
        }

        private async Task UpdateState()
        {
            Status = await _vlc.GetStatus(Name);
            var pos = await _vlc.GetPosition(Name);
            Progress = (byte)(pos * 100);
        }

        public async Task Transcode(string source, string destination, int aTrack, int sTrack)
        {
            await _vlc.Transcode(Name, source, destination, aTrack, sTrack);
            _monitoringTask = MonitorState();
        }

        public Task Play()
        {
            return _vlc.PlayStream(Name);
        }

        public Task Pause()
        {
            return _vlc.PauseStream(Name);
        }

        public Task Abort()
        {
            return _vlc.StopStreaming(Name);
        }
    }
}