using _06_tankedazhan_dev.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_tankedazhan_dev
{
    enum Tag
    {
        Mytank,
        Enemytank
    }
    internal class Bulet:Movingthing
    {
        public Tag Tag { get; set; }
        public bool IsDestroy { get; set; }
        public Bulet(int x, int y, int speed,Direction dir,Tag tag)
        {
            //IsMoving = false;
            IsDestroy = false;
            this.X = x;
            this.Y = y;
            this.Speed = speed;

            BitmapDown = Resources.BulletDown;
            BitmapUp = Resources.BulletUp;
            BitmapLeft = Resources.BulletLeft;
            BitmapRight = Resources.BulletRight;
            this.Dir = dir;
            this.Tag = tag;
            this.X -= Width / 2;
            this.Y -= Height / 2;
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
                if (Y +Height/2 +3 < 0)
                {
                    IsDestroy = true; return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Height / 2 -3 >450)
                {
                    IsDestroy = true; return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X +Width/2+3 <0)
                {
                    IsDestroy = true; return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X - Width / 2 - 3 >450)
                {
                    IsDestroy = true; return;
                }
            }
            #endregion
            //2检查有没有和其他元素发生碰撞
            Rectangle rtnow = new Rectangle();
            rtnow.X = X+Width/2;
            rtnow.Y = Y+Height/2-3;
            rtnow.Height = 3;
            rtnow.Width = 3;
            //1 wall 2 steel 3 Tank
            NotMovingthing wall = null;
            NotMovingthing stell = null;
            int xExplosion = this.X+Width/2;
            int yExplosion = this.Y+Height/2;
            if((wall = GameObjectManager.IsCollidedWall(rtnow)) != null)
            {
                IsDestroy = true;
                GameObjectManager.DstroyWall(wall);
                GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                SoundManager.PlayBlast();
                return;
            }
            //2
            if ((stell = GameObjectManager.IsCollidedSteel(rtnow)) != null)
            {
                IsDestroy = true;
                //GameObjectManager.DstroyWall(stell);
                GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                return;
            }
            //3
            if(Tag == Tag.Mytank)
            {
                EnemyTank tank = null;
                if ((tank = GameObjectManager.IsCollidedenEnemyTank(rtnow)) != null)
                {
                    IsDestroy = true;
                    GameObjectManager.DestroyTank(tank);
                    GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                    SoundManager.PlayBlast();
                    return;
                }
            }
            //4 敌人打我
            else if(Tag == Tag.Enemytank)
            {
                MyTank tank = null;
                if((tank = GameObjectManager.IsCollidedMytank(rtnow)) != null)
                {
                    IsDestroy = true;
                    GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                    tank.TakeDamege();
                    return;
                }

            }
            if (GameObjectManager.IsCollidedBoss(rtnow) != null)
            {
                IsDestroy = true;
                GameFramework.ChangeToGameOver();
                SoundManager.PlayBlast();
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
    }
}
