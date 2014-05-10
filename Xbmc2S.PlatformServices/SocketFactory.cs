using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using XBMCRPC;

namespace Xbmc2S.RT.PlatformServices
{
    public class SocketFactory: ISocketFactory
    {
        public ISocket GetSocket()
        {
            return new SocketWrapper( new StreamSocket());
        }

        public async Task<string[]> ResolveHostname(string hostname)
        {
            IReadOnlyList<EndpointPair> data = await DatagramSocket.GetEndpointPairsAsync(new HostName(hostname), "0");

            return data.Select(ep=>ep.RemoteHostName.DisplayName).ToArray();
        }
    }
}