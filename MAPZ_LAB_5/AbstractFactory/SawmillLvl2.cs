using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Drawing;

namespace MAPZ_LAB_5
{
    class SawmillLvl2 : Sawmill
    {
        //private static double boostNumber = 3;
        //override public void Boost()
        //{
        //    productionIncrease = 1;
        //    productionIncrease *= boostNumber;
        //}

        public override void ChangeImage(Size size, Folder composite)
        {
            //new Bitmap(Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\sawmill2.png")
            sawmillImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "sawmill2"), size));
        }

    }
}
