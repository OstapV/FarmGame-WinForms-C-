using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    class GardenLvl1 : Garden
    {
        //static private double boostNumber = 1;
        //override public void Boost()
        //{
        //    wheatDropTime /= boostNumber;
        //    pumpkinDropTime /= boostNumber;
        //}

        override public void ChangeImage(Size size, Folder composite)
        {
            if (isWheatClicked)
            {
                wheatImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "felledTree"), size));
            }
            else if (!isWheatClicked)
            {
                wheatImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "psenizia"), size));
            }

            if (isPumpkinClicked)
            {
                pumpkinImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "felledTree"), size));
            }
            else if (!isPumpkinClicked)
            {
                pumpkinImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "garbuz"), size));
            }
        }

      
    }
}
