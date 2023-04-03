using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    class SawmillLvl1 : Sawmill
    {
        //private static double boostNumber = 2;
        //override public void Boost()
        //{
        //    productionIncrease = 1;
        //    productionIncrease *= boostNumber;
       // }

        override public void ChangeImage(Size size, Folder composite)
        {
            //Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\sawmill.png")
            sawmillImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "sawmill"), size));
        }

    }
}
