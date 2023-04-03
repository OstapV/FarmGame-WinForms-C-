using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class GardenBooster
    {
        public double BoostValue { get; set; }
        public TimeSpan CurrentDropTimePumpkin { get; set; }
        public TimeSpan CurrentDropTimeWheat { get; set; }
        public void BoostGarden()
        {
            if (CurrentDropTimePumpkin != null && CurrentDropTimeWheat != null)
            {
                CurrentDropTimeWheat /= BoostValue;
                CurrentDropTimePumpkin /= BoostValue;
            }
        }
    
    }
}
