using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace MAPZ_LAB_5
{
    class ForestLvl2 : Forest
    {
        //static private double boostNumber = 2;
        //public override void Boost()
        //{
        //    resourceDropTime /= boostNumber;
        //}

        public override void ChangeImage(Size size, Folder composite)
        {
            //(Image)(new Bitmap(Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\tree.png"), size));
            //(Image)(new Bitmap(Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\treeFelled.png"), size));
            
            TreeImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "tree"), size));


            FelledTree = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "treeFelled"), size));

        }
       
    }
}
