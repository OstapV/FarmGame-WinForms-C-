using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.Strategy
{
    interface IBoostable
    {
        TimeSpan Boost(TimeSpan time);
    }
}
