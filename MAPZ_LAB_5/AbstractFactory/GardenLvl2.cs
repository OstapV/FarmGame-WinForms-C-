using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Drawing;

namespace MAPZ_LAB_5
{
    class GardenLvl2 : Garden
    {
        //static private double boostNumber = 2;
       // override public void Boost()
        //{
        //    wheatDropTime /= boostNumber;
        //    pumpkinDropTime /= boostNumber;
       // }

        public override void ChangeImage(Size size, Folder composite)
        {
            //(Image)(new Bitmap(Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\felledTree.png"), size));
            //(Image)(new Bitmap(Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\psenizia.png"), size));
            //(Image)(new Bitmap(Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\felledTree.png"), size));
            //(Image)(new Bitmap(Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\garbuz.png"), size));
            
            if (isWheatClicked)
            {
                wheatImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "treeFelled"), size));
            }
            else if (!isWheatClicked)
            {
                wheatImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "psenizia"), size));
            }

            if (isPumpkinClicked)
            {
                pumpkinImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "treeFelled"), size));
            }
            else if (!isPumpkinClicked)
            {
                pumpkinImage = (Image)(new Bitmap(composite.GetFolderLeaf(composite, "garbuz"), size));
            }
        }

      
    }
}
