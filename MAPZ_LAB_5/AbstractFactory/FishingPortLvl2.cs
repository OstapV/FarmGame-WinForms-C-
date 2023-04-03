using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MAPZ_LAB_5
{
    class FishingPortLvl2 : FishingPort
    {
        //static private double boostNumber = 2;
        public override void ChangeImage(Size size, Folder composite)
        {
            //(Image)(new Bitmap(Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\fishing2.png"), size));
            
            portImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "fishing2"), size));
        }

        //public override void Boost()
        //{
        //    fishDropTime /= boostNumber;
        //}
    }
}
