using System;

namespace Xbmc2S.RT.UPnP
{
    public class MyTuple:Tuple<Uri, string>
    {
        public MyTuple(Uri item1, string item2) : base(item1, item2)
        {
        }

        public string soapSchema;
        public string soapVerb;
    }
}