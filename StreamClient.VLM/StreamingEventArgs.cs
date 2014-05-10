using System;

namespace StreamingClient.StreamManagment
{
    public class StreamingEventArgs : EventArgs
    {


        public string StreamUri { get; private set; }

        public StreamingEventArgs(string streamUri)
        {
            StreamUri = streamUri;
        }
    }
}