using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.Strategy
{
    class Boost
    {
        public TimeSpan CurrentDropTime { get; private set; }
        public IBoostable Boostable { get; set; }

        public Boost(TimeSpan CurrentDropTime, IBoostable Boostable)
        {
            this.CurrentDropTime = CurrentDropTime;
            this.Boostable = Boostable;
        }

        public void MakeBoost()
        {
            CurrentDropTime = Boostable.Boost(CurrentDropTime);
        }
    }
}
