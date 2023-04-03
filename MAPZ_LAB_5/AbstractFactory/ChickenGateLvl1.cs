using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    class ChickenGateLvl1 : ChickenGate
    {
       // private static double boostNumber = 1;

       // public override void Boost()
       // {
        //    resourceDropTime /= boostNumber;
       // }

        public override void ChangeImage(Size size, Folder composite)
        {
            chickenImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "chickenGreen"), size));
        }

    }
}
