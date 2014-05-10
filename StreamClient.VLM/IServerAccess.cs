using System;
using System.Threading.Tasks;
using StreamingClient.Player;

namespace StreamingClient.StreamManagment
{
    public delegate void WarningDelegate(string message);
    public interface IServerAccess
    {
        Task<string> StartStreaming(string source);
        Task StopStreaming();
        Task Seek(double pos);
        Task<double> UpdatePos(Action<double> callback);
        
        event EventHandler<StreamingEventArgs> StreamingStarted;
        event EventHandler<ErrorEventArgs> CommunicationFailed;
        event WarningDelegate CommunicationWarning;
    }
}