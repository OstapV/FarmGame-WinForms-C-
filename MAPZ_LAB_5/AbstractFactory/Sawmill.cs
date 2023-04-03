using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    abstract class Sawmill
    {
        public TimeSpan resourceDropTime { get; set; }

        public Image sawmillImage { get; set; }

        public Timer timerPlanks { get; set; }

        public double productionIncrease { get;set; }

        //abstract public void Boost();

        abstract public void ChangeImage(Size size, Folder composite);

    }
}
