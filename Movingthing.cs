using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_tankedazhan_dev
{
    enum Direction
    {
        Up,
        Down, 
        Left, 
        Right
    }
    internal class Movingthing:GameObject
    {
        private Object _lock = new Object();//锁对象
        public Bitmap BitmapUp { get; set; }
        public Bitmap BitmapDown { get; set; }
        public Bitmap BitmapLeft { get; set; }
        public Bitmap BitmapRight { get; set; }
        
        public int Speed { get; set; }
        public Direction dir { get; set; }
        public Direction Dir { get { return dir; }
            set {
                dir = value;
                Bitmap bmp = null;
                switch (dir)
                {
                    case Direction.Up:
                        bmp = BitmapUp;
                        break;
                    case Direction.Down:
                        bmp = BitmapDown;
                        break;
                    case Direction.Left:
                        bmp = BitmapLeft;
                        break;
                    case Direction.Right:
                        bmp = BitmapRight;
                        break;
                }
                lock (_lock)
                {
                    Width = bmp.Width;
                    Height = bmp.Height;
                }
            } 
        }

        protected override Image GetImage()
        {
            Bitmap bitmap = null; 
            switch (Dir)
            {
               case Direction.Up:
                    bitmap = BitmapUp;
                    break;
                case Direction.Down: 
                    bitmap = BitmapDown;
                    break;
                case Direction.Left: 
                    bitmap = BitmapLeft;
                    break;
                case Direction.Right: 
                    bitmap = BitmapRight;
                    break;
            }
            lock (_lock)
            {
                bitmap.MakeTransparent(Color.Black);
            }
            return bitmap;
        }
        public override void DrawSelf()
        {
            lock (_lock) {
                base.DrawSelf();
            }
            
        }
    }
}
