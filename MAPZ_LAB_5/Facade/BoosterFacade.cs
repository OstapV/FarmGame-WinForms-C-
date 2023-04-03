using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class BoosterFacade
    {
        ChickenGateBooster ChickenGateBooster { get; set; }
        FishingPortBooster FishingPortBooster { get; set;}
        ForestBooster ForestBooster { get; set; }
        SawmillBooster SawmillBooster { get; set; }
        GardenBooster GardenBooster { get; set; }

        public BoosterFacade(ChickenGateBooster _chickenGateBooster, FishingPortBooster _fishingPortBooster, ForestBooster _forestBooster,
             SawmillBooster _sawmillBooster, GardenBooster _gardenBooster)
        {
            ChickenGateBooster = _chickenGateBooster;
            FishingPortBooster = _fishingPortBooster;
            ForestBooster = _forestBooster;
            SawmillBooster = _sawmillBooster;
            GardenBooster = _gardenBooster;
        }

        public void CreateBoost()
        {
            ChickenGateBooster.BoostChickenGate();
            FishingPortBooster.BoostFishing();
            ForestBooster.BoostForest();
            SawmillBooster.BoostSawmill();
            GardenBooster.BoostGarden();
        }
    }
}
