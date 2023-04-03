using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5
{
    class RawMaterial
    {
        
        public string Name { get; set; }

        public int Count { get; set; }

        public RawMaterial(string name, int count)
        {
            Name = name;
            Count = count;
        }

    }
}
