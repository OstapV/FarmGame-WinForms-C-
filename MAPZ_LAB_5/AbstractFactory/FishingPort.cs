using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    abstract class FishingPort
    {
        public TimeSpan fishDropTime { get; set; }

        public Image portImage { get; set; }

        abstract public void ChangeImage(Size size, Folder composite);

        //abstract public void Boost();

    }
}
