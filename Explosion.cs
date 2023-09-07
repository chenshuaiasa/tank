using _06_tankedazhan_dev.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _06_tankedazhan_dev
{
    internal class Explosion : GameObject
    {
        private int playSpeed = 1;
        private int playCount = 0;
        private int index = 0;
        public bool isNeedDestroy;
        //public bool isDestroy { get; set; }
        private Bitmap[] bitmapArray = new Bitmap[]
        {
            Resources.EXP1,
            Resources.EXP2,
            Resources.EXP3,
            Resources.EXP4,
            Resources.EXP5
        };
        public Explosion(int x,int y ) { 
            foreach(Bitmap bmp in bitmapArray)
            {
                bmp.MakeTransparent(Color.Black);
            }
            isNeedDestroy = false;
            this.X = x - bitmapArray[0].Width / 2;
            this.Y = y - bitmapArray[0].Height / 2;

        }
        protected override Image GetImage()
        {
            //throw new NotImplementedException();
            if (index > 4)
            {
                isNeedDestroy = true;
                return bitmapArray[4];
            }
            return bitmapArray[index];
        }

        public override void Update()
        {
            playCount++;
            index = (playCount - playSpeed) / playSpeed;
            base.Update();
        }
    }
}
