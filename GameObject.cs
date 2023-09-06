using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_tankedazhan_dev
{
    abstract internal class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        //public int ss = 0;
        //private int X;
        //public int X{get{return x;} set{value=x;}}
        protected abstract Image GetImage();

        public virtual void DrawSelf()
        {
            Graphics g = GameFramework.g;
            g.DrawImage(GetImage(),X,Y);
        }
        public virtual void Update()
        {
            DrawSelf();
        }
        public Rectangle GetRectangle()
        {
            Rectangle rectangle = new Rectangle(X,Y,Width,Height);
            return rectangle;
        }
    }
}
