using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    enum Price
    {
        Wheat = 5,
        Pumpkin = 20,
        Egg = 10,
        Fish = 25,
        Chickens = 100,

        Sawmill = 400,
        FishingPort = 600,
        Garden = 200,
        Forest = 150,
        ChickenGate = 450
    }
    public interface IBuyer
    {
        void Buy(string itemName);
    }
}
