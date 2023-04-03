using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    abstract class AbstractFarm
    {
        public abstract Garden CreateGarden();
        public abstract Forest CreateForest();
        public abstract Sawmill CreateSawmill();
        public abstract FishingPort CreateFishingPort();
        public abstract ChickenGate CreateChickenGate();

    }
}
