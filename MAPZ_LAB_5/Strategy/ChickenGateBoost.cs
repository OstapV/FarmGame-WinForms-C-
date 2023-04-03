using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.Strategy
{
    class ChickenGateBoost : IBoostable
    {
        static double BoostValue = 2;

        TimeSpan IBoostable.Boost(TimeSpan time)
        {
            if (time != null)
            {
                if (BoostValue > 2)
                {
                    BoostValue -= 0.15;
                }
                else
                {
                    BoostValue += 0.15;
                }

                time /= BoostValue;
            }
            return time;
        }
    }
}
