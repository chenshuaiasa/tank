using _06_tankedazhan_dev.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_tankedazhan_dev
{
    internal class MyTank:Movingthing
    {
        public bool IsMoving { get; set; }  
        public MyTank(int x,int y,int speed) { 
            IsMoving = false;
            this.X = x;
            this.Y = y; 
            this.Speed = speed;
            
            BitmapDown = Resources.MyTankDown;
            BitmapUp = Resources.MyTankUp;
            BitmapLeft = Resources.MyTankLeft;
            BitmapRight = Resources.MyTankRight;
            this.Dir = Direction.Up;
        }
        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Dir = Direction.Up;
                    IsMoving = true;
                    break;
                case Keys.S:
                    Dir = Direction.Down;
                    IsMoving = true;
                    break;
                case Keys.A:
                    Dir = Direction.Left;
                    IsMoving = true;
                    break; 
                case Keys.D:
                    Dir = Direction.Right;
                    IsMoving = true;
                    break;
            }
        }
        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    IsMoving = false;
                    break;
                case Keys.S:
                    IsMoving = false;
                    break;
                case Keys.A:
                    IsMoving = false;
                    break;
                case Keys.D:
                    IsMoving = false;
                    break;
            }
        }

        public override void Update()
        {
            MoveCheck();//移动检查
            Move();
            base.Update();
        }
        private void MoveCheck()
        {
            //1检查有没有超过窗体边界
            if(Dir == Direction.Up)
            {
                if(Y -Speed < 0)
                {
                    IsMoving = false;return;
                }
            }else if(Dir == Direction.Down)
            {
                if(Y-26+Speed > 450) { 
                IsMoving = false;return;}
            }
            //2检查有没有和其他元素发生碰撞
        }
        private void Move()
        {
            if (IsMoving == false) return;

            switch (Dir)
            {
                case Direction.Up:
                    Y -=Speed; break;
                case Direction.Down:
                    Y +=Speed; break;
                case Direction.Left:
                    X -=Speed; break;
                case Direction.Right:
                    X +=Speed; break;
            }
        }
    }
}
