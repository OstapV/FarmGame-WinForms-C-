using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    class ForestLvl1 : Forest
    {
        //static private double boostNumber = 1;
        //public override void Boost()
        //{
        //    resourceDropTime /= boostNumber;
        //}

        public override void ChangeImage(Size size, Folder composite)
        {

            TreeImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "tree"), size));


            FelledTree = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "treeFelled"), size));
        }

    }
}
