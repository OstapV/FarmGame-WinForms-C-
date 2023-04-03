using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.Strategy
{
    class FishingPortBoost : IBoostable
    {
        static double BoostValue = 1.6;

        TimeSpan IBoostable.Boost(TimeSpan time)
        {
            if (time != null)
            {
               time /= (BoostValue + 0.15);
            }
            return time;
        }
    }
}
