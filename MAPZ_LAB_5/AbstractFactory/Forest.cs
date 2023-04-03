using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    abstract class Forest
    {
        public TimeSpan resourceDropTime;

        public Image TreeImage { get; set; }

        public Image FelledTree { get; set; }

        public bool IsFelled { get; set; }
        //abstract public void Boost();

        abstract public void ChangeImage(Size size, Folder composite);
    }
}
