using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class ConcreteFarmLvl2 : AbstractFarm
    {
        public override Garden CreateGarden()
        {
            return new GardenLvl2();
        }
        public override Forest CreateForest()
        {
            return new ForestLvl2();
        }
        public override Sawmill CreateSawmill()
        {
            return new SawmillLvl2();
        }
        public override FishingPort CreateFishingPort()
        {
            return new FishingPortLvl2();
        }
        public override ChickenGate CreateChickenGate()
        {
            return new ChickenGateLvl2();
        }
       
    }
}
