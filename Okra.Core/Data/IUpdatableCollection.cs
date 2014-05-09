﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okra.Data
{
    public interface IUpdatableCollection
    {
        void Update(DataListUpdate update);
    }
}
