using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_tankedazhan_dev
{
    /*
     * 不可异动的物体
     */
    internal class NotMovingthing:GameObject
    {

        public Image Img { get; set; }

        protected override Image GetImage()
        {
            return Img;
        }

        public NotMovingthing()
        {
        }

        public NotMovingthing(int x, int y,Image img)
        {
            this.X = x;
            this.Y = y;
            this.Img = img;
        }
    }
}
