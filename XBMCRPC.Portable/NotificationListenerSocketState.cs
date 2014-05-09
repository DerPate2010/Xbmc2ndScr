using System.Text;

namespace XBMCRPC
{
    class NotificationListenerSocketState
    {
        public const int BufferSize = 1024;
        public byte[] Buffer = new byte[BufferSize];
        public StringBuilder Builder = new StringBuilder();
    }
}
