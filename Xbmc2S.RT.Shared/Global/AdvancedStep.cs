using System;

namespace Xbmc2S.RT
{
    class AdvancedStep
    {
        public string Header { get; set; }
        public Action Execute { get; set; }
        public string Type { get; set; }
    }
}