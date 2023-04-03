using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class FishingPortBooster
    {
        public double BoostValue { get; set; }
        public TimeSpan CurrentDropTime { get; set; }
        public void BoostFishing()
        {
            if (CurrentDropTime != null)
            {
                CurrentDropTime /= BoostValue;
            }
        }

    }
}
