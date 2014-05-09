using System;
using System.Diagnostics;

namespace Xbmc2S.RT.UPnP
{
    public class NullProgress:IProgress<string>
    {
        public void Report(string value)
        {
#if DEBUG
            //Debug.WriteLine(value);
#endif
        }

    }
}