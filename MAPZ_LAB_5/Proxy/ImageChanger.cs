using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MAPZ_LAB_5
{
    class ImageChanger : IChanger
    {
        public Size ChangeSize(int x, int y)
        {
            return new Size(x, y);
        }
    }
}
