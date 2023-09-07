using _06_tankedazhan_dev.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _06_tankedazhan_dev
{
    internal class EnemyTank:Movingthing
    {
        public int AttackSpeed { get; set; }
        private int attackCount = 0;
        public int changeDirSpeed { get; set; }
        private int changeDirCount = 0;
        private Random r = new Random();
        public EnemyTank(int x, int y, int speed,Bitmap bmpDpwn,Bitmap bmpUp,Bitmap bmpRight,Bitmap bmpLeft)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;

            BitmapDown = bmpDpwn;
            BitmapUp = bmpUp;
            BitmapLeft = bmpLeft;
            BitmapRight = bmpRight;
            AttackSpeed = 60;
            changeDirSpeed = 70;
            this.Dir = Direction.Down;
        }
        public override void Update()
        {
            MoveCheck();//移动检查
            Move();
            AttackCheck();
            AutoChangeDirction();
            base.Update();
        }
        private void MoveCheck()
        {
            #region//1检查有没有超过窗体边界
            if (Dir == Direction.Up)
            {
                if (Y - Speed < 0)
                {
                    ChangeDirction(); return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Speed + Height > 450)
                {
                    ChangeDirction();
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    ChangeDirction();
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed + Width > 450)
                {
                    ChangeDirction();
                    return;
                }
            }
            #endregion
            //2检查有没有和其他元素发生碰撞
            Rectangle rtnow = new Rectangle(X, Y, Width, Height);
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
                ChangeDirction();
            }
            if (GameObjectManager.IsCollidedSteel(rtnow) != null)
            {
                ChangeDirction();
            }
            if (GameObjectManager.IsCollidedBoss(rtnow) != null)
            {
                ChangeDirction();
            }
        }
        private void Move()
        {
            switch (Dir)
            {
                case Direction.Up:
                    Y -= Speed; break;
                case Direction.Down:
                    Y += Speed; break;
                case Direction.Left:
                    X -= Speed; break;
                case Direction.Right:
                    X += Speed; break;
            }
        }
        private void AutoChangeDirction()
        {
            changeDirCount++;
            if(changeDirCount < changeDirSpeed)
            {
                return;
            }
            ChangeDirction();
            changeDirCount = 0;
        }
        private void ChangeDirction()
        {
            //随机生成4个方向,r为种子
            while (true)
            {
                Direction dir = (Direction)r.Next(0, 4);
                if (dir == Dir)
                {
                    continue;
                }
                {
                    Dir = dir;
                    break;
                }
            }
            MoveCheck();
        }
        private void AttackCheck()
        {
            attackCount++;
            if (attackCount < AttackSpeed) return;
            Attack();
            attackCount = 0;
        }
        private void Attack()
        {
            //发射子弹
            int x = this.X;
            int y = this.Y;
            switch (Dir)
            {
                case Direction.Up:
                    x = x + Width / 2;
                    break;
                case Direction.Down:
                    x = x + Width / 2;
                    y = y + Height;
                    break;
                case Direction.Left:
                    y = y + Height / 2;
                    break;
                case Direction.Right:
                    y = y + Height / 2;
                    x = x + Width;
                    break;
            }
            GameObjectManager.CreateBullet(x, y, Tag.Enemytank, Dir);
        }
    }
}
