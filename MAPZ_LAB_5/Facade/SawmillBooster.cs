using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class SawmillBooster
    {
        public double BoostValue { get; set; }
        public double Production { get; set; }
        public void BoostSawmill()
        {
            Production = 1;
            Production *= BoostValue;
        }

    }
}
