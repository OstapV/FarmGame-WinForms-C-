using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    abstract class Garden
    {
        public TimeSpan wheatDropTime { get; set; }

        public TimeSpan pumpkinDropTime { get; set; }
        public Image wheatImage { get; set; }

        public Image pumpkinImage { get;set; }

        public bool isWheatClicked { get; set; }

        public bool isPumpkinClicked { get; set; }
      
        //abstract public void Boost();

        abstract public void ChangeImage(Size size, Folder composite);

    
    }
}
