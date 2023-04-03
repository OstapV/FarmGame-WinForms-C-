using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class Product
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public Product(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}
