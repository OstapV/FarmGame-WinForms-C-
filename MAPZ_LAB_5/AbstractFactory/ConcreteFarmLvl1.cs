using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class ConcreteFarmLvl1 : AbstractFarm
    {
        public override Garden CreateGarden()
        {
            return new GardenLvl1();
        }
        public override Forest CreateForest()
        {
            return new ForestLvl1();
        }
        public override Sawmill CreateSawmill()
        {
            return new SawmillLvl1();
        }
        public override FishingPort CreateFishingPort()
        {
            return new FishingPortLvl1();
        }
        public override ChickenGate CreateChickenGate()
        {
            return new ChickenGateLvl1();
        }
      
    }
}
