using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.Strategy
{
    class ForestBoost : IBoostable
    {
        static double BoostValue = 2;

        TimeSpan IBoostable.Boost(TimeSpan time)
        {
            if (time != null)
            {
               time /= BoostValue;
            }
            return time;
        }
    }
}
