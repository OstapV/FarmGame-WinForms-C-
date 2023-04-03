using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class Client
    {
        public Forest Forest { get; set; }
        public Sawmill Sawmill { get; set; }
        public Garden Garden { get; set; }
        public ChickenGate ChickenGate { get; set; }
        public FishingPort FishingPort { get; set; }

        public Client(AbstractFarm abstractFarm)
        {
            Forest = abstractFarm.CreateForest();
            Sawmill = abstractFarm.CreateSawmill();
            Garden = abstractFarm.CreateGarden();
            ChickenGate = abstractFarm.CreateChickenGate();
            FishingPort = abstractFarm.CreateFishingPort();
        }


    }
}
