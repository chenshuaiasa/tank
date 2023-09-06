using _06_tankedazhan_dev.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_tankedazhan_dev
{
    internal class MyTank:Movingthing
    {
        //public bool IsMoving { get; set; }  
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
        //GameMainThread KeyDown冲突
        // 1 2 解决资源冲突，加锁

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
                case Keys.Space://发射子弹
                    Attack();
                    break;
            }
        }
        private void Attack()
        {
            //发射子弹
            int x = this.X;
            int y = this.Y;
            switch (Dir)
            {
                case Direction.Up:
                    x = x + Width/2;
                    break; 
                case Direction.Down:
                    x = x + Width/2;
                    y = y + Height;
                    break;
                case Direction.Left:
                    y = y + Height/2;
                    break;
                case Direction.Right:
                    y = y + Height/2;
                    x = x + Width;
                    break;
            }
            GameObjectManager.CreateBullet(x, y, Tag.Mytank, Dir);
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
            #region//1检查有没有超过窗体边界
            if (Dir == Direction.Up)
            {
                if(Y -Speed < 0)
                {
                    IsMoving = false;return;
                }
            }else if(Dir == Direction.Down)
            {
                if(Y+Speed+Height > 450) { 
                    IsMoving = false;
                    return;
                }
            }else if(Dir == Direction.Left) 
            { 
                if(X-Speed <0) { 
                    IsMoving = false;
                    return;
                } 
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed+Width>450)
                {
                    IsMoving = false;
                    return;
                }
            }
            #endregion
            //2检查有没有和其他元素发生碰撞
            Rectangle rtnow = new Rectangle(X,Y,Width,Height);
            switch (Dir)
            {
                case Direction.Up:
                    rtnow.Y -= Speed;
                    break;
                case Direction.Down:
                    rtnow.Y += Speed;
                    break;
                case Direction.Left:
                    rtnow.X -= Speed;
                    break;
                case Direction.Right:
                    rtnow.X += Speed;
                    break;
            }
            if (GameObjectManager.IsCollidedWall(rtnow) != null)
            {
                IsMoving = false;
            }
            if (GameObjectManager.IsCollidedSteel(rtnow) != null)
            {
                IsMoving = false;
            }
            if (GameObjectManager.IsCollidedBoss(rtnow) != null)
            {
                IsMoving = false;
            }
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
