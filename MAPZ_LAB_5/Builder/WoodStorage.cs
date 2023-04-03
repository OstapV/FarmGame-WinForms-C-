using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class WoodStorage : StorageBuilder
    {
        public override void SetRawMaterials()
        {
            this.Storage.RawMaterials = new List<RawMaterial>
            {
                new RawMaterial("Wood", 0),
                new RawMaterial("Plank", 0)
            };
        }

        public override void SetCapacity()
        {
            this.Storage.Capacity = 300;
        }

        public override void SetProducts()
        {
        }

    }
}
