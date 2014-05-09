using System.Runtime.Serialization;

namespace Xbmc2S.Model.Download
{
    [DataContract]
    public class TransferInfo : BindableBase
    {
        private byte _progress;
        private TransferStatus _status;
        private ulong _size;
        private string _targetFile;

        [DataMember]
        public byte Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }

        [DataMember]
        public string TransferId { get; set; }

        [DataMember]
        public TransferStatus Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        [DataMember]
        public ulong Size
        {
            get { return _size; }
            set { SetProperty(ref _size, value); }
        }

        [DataMember]
        public string TargetFile
        {
            get { return _targetFile; }
            set { SetProperty(ref _targetFile, value); }
        }
    }
}