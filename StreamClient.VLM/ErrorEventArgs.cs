using System;

namespace StreamingClient.Player
{
    public class ErrorEventArgs:EventArgs
    {
        public ErrorCode Error { get; set; }
        public Exception Exception { get; set; }

        public ErrorEventArgs(ErrorCode error, Exception exception)
        {
            Error = error;
            Exception = exception;
        }
    }
}