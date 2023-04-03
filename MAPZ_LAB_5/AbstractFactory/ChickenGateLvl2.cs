using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    class ChickenGateLvl2 : ChickenGate
    {
        //private static double boostNumber = 2;

       // public override void Boost()
       // {
       //     resourceDropTime /= boostNumber;
       // }

        public override void ChangeImage(Size size, Folder composite)
        {
            //(Image)(new Bitmap(Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\chickenGreen.png"), size));
             
            chickenImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "chickenGreen"), size));
        }


    }
}
