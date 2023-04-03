using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MAPZ_LAB_5
{
    class ImageChangerProxy : IChanger
    {
        private ImageChanger ImageChanger = new ImageChanger();

        public Size ChangeSize(int x, int y)
        {
            return ImageChanger.ChangeSize(x, y);
        }
    }
}
