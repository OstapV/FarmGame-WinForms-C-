using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class WarehouseMan
    {
        public Storage Service(StorageBuilder storageBuilder)
        {
            storageBuilder.CreateStorage();
            storageBuilder.SetCapacity();
            storageBuilder.SetProducts();
            storageBuilder.SetRawMaterials();

            return storageBuilder.Storage;
        }
    }
}
