using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okra.Helpers;

namespace Okra.Data
{
    public struct DataListUpdate
    {
        // *** Fields ***

        private readonly DataListUpdateAction action;
        private readonly int index;
        private readonly int count;

        // *** Constructors ***

        public DataListUpdate(DataListUpdateAction action)
        {
            // Validate Parameters

            if (action != DataListUpdateAction.Reset)
                throw new InvalidOperationException(string.Format(ResourceHelper.GetErrorResource("Exception_InvalidOperation_ConstructorNotSupportedForAction"), action));

            // Set Fields

            this.action = action;
            this.index = 0;
            this.count = 0;
        }

        public DataListUpdate(DataListUpdateAction action, int index, int count)
        {
            // Validate Parameters

            if (action != DataListUpdateAction.Add && action != DataListUpdateAction.Remove)
                throw new InvalidOperationException(string.Format(ResourceHelper.GetErrorResource("Exception_InvalidOperation_ConstructorNotSupportedForAction"), action));

            if (index < 0)
                throw new ArgumentOutOfRangeException("count", ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ParameterMustBeZeroOrPositive"));

            if (count <= 0)
                throw new ArgumentOutOfRangeException("count", ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ParameterMustBePositive"));

            // Set Fields

            this.action = action;
            this.index = index;
            this.count = count;
        }

        // *** Properties ***

        public DataListUpdateAction Action
        {
            get
            {
                return action;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }
        }
    }
}
