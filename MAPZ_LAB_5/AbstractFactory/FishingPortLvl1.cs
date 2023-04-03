using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MAPZ_LAB_5
{
    class FishingPortLvl1 : FishingPort
    {
        //static private double boostNumber = 1;
        override public void ChangeImage(Size size, Folder composite)
        {
           portImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "fishing"), size));
        }

        //override public void Boost()
        //{
        //    fishDropTime /= boostNumber;
        //}
    }
}
