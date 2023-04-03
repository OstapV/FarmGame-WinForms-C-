using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    abstract class StorageBuilder
    {
        public Storage Storage { get; private set; }

        public void CreateStorage()
        {
            Storage = new Storage();
        }

        public abstract void SetProducts();
        public abstract void SetCapacity();
        public abstract void SetRawMaterials();

    }
}
