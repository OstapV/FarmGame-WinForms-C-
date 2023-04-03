using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    abstract class ChickenGate
    {
        public TimeSpan resourceDropTime { get; set; }
        public Image chickenImage { get; set; }

        public Timer timerChicken { get; set; }

        public int chickenCount { get; set; }
        //abstract public void Boost();

        abstract public void ChangeImage(Size size, Folder composite);
    }
}
