using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbmc2S.RT
{
    public partial class HubPage
    {

        private void AddAdvancedStepsPF(List<AdvancedStep> advancedSteps)
        {
            advancedSteps.Add(new AdvancedStep() { Header = "Settings", Execute = ShowSettings });
        }
    }
}
