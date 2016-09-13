using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using KODIRPC;

namespace Xbmc2S.RT.PlatformServices
{
    public class SocketWrapper : ISocket
    {
        private readonly StreamSocket _streamSocket;

        public SocketWrapper(StreamSocket streamSocket)
        {
            _streamSocket = streamSocket;
        }

        public void Dispose()
        {
            _streamSocket.Dispose();
        }

        public async Task ConnectAsync(string hostName, int port)
        {
            await _streamSocket.ConnectAsync(new HostName(hostName), port.ToString());
        }

        public Stream GetInputStream()
        {
            return _streamSocket.InputStream.AsStreamForRead();
        }
    }
}