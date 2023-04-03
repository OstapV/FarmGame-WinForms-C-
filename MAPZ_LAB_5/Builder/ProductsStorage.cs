using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class ProductsStorage : StorageBuilder
    {
        public override void SetProducts()
        {
            this.Storage.Products = new List<Product>
            {
                new Product("Wheat", 0),
                new Product("Pumpkin", 0),
                new Product("Eggs", 0),
                new Product("Fish", 0)
            };
        }

        public override void SetCapacity()
        {
            this.Storage.Capacity = 1000;
        }

        public override void SetRawMaterials()
        {
        }

    }
}
