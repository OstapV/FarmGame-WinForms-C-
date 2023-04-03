using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class ChickenGateBooster
    {
        public double BoostValue { get; set; }
        public TimeSpan CurrentDropTime { get; set; }
        public void BoostChickenGate()
        {
            if (CurrentDropTime != null)
            {
                CurrentDropTime /= BoostValue;
            }
        }

    }
}
