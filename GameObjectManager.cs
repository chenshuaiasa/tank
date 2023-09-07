using _06_tankedazhan_dev.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _06_tankedazhan_dev
{
    internal class GameObjectManager
    {
        private static List<NotMovingthing> wallList = new List<NotMovingthing>();
        private static List<NotMovingthing> steelList = new List<NotMovingthing>();
        private static List<NotMovingthing> bosslList = new List<NotMovingthing>();
        private static List<EnemyTank> tankList = new List<EnemyTank>();
        private static List<Bulet> bulletList = new List<Bulet>();
        private static MyTank mytank;
        private static int enemyBornSpeed = 60;
        private static int enemyBorncount = 60;
        private static Point[] points = new Point[3];

        private static List<Explosion> expList = new List<Explosion>();
        public static void Start()
        {
            points[0].X = 0; points[0].Y = 0;
            points[1].X = 7*30; points[1].Y = 0;
            points[2].X = 14*30; points[2].Y = 0;
        }
        public static void Update()
        {
            foreach (NotMovingthing nm in wallList)
            {
                nm.Update();
            }
            foreach (NotMovingthing nm in steelList)
            {
                nm.Update();
            }
            foreach (NotMovingthing nm in bosslList)
            {
                nm.Update();
            }
            foreach (EnemyTank tank in tankList)
            {
                tank.Update();
            }
            CheckAndDstroyBullet();
            foreach (Bulet b in bulletList)
            {
                b.Update();
            }
            CheckAndDestroyExp();
            foreach (Explosion exp in expList)
            {
                exp.Update();
            }
            mytank.Update();
            EnemyBorn();
        }
        //public static void DrawMytank()
        //{
        //    mytank.DrawSelf();
        //}

        
        public static void CreateExplosion(int x,int y)
        {
            Explosion exp = new Explosion(x,y);
            expList.Add(exp);
        }
        public static void CreateBullet(int x,int y,Tag tag,Direction dir)
        {
            Bulet bullet = new Bulet(x,y,5,dir,tag);
            bulletList.Add(bullet);
                
        }

        public static void DstroyWall(NotMovingthing wall)
        {
            wallList.Remove(wall);
        }
        public static void DstroySteel(NotMovingthing steel)
        {
            steelList.Remove(steel);
        }
        public static void DestroyTank(EnemyTank tank)
        {
            tankList.Remove(tank);
        }
        private static void CheckAndDstroyBullet()
        {
            List<Bulet> needtoDestroy = new List<Bulet>();
            foreach (Bulet bullet in bulletList)
            {
                if (bullet.IsDestroy == true)
                {
                    needtoDestroy.Add(bullet);
                }
            }
            foreach (Bulet b in needtoDestroy)
            {
                bulletList.Remove(b);
            }

        }
        public static void CheckAndDestroyExp()
        {
            List<Explosion> needtoDestroy = new List<Explosion>();
            foreach (Explosion exp in expList)
            {
                if (exp.isNeedDestroy == true)
                {
                    needtoDestroy.Add(exp);
                }
            }
            foreach (Explosion e in needtoDestroy)
            {
                expList.Remove(e);
            }
        }
        private static void EnemyBorn()
        {
            enemyBorncount++;
            if (enemyBorncount < enemyBornSpeed) return;
            //0-2
            Random rd = new Random();
            int index = rd.Next(0, 3);
            Point position = points[index];
            int enemyType = rd.Next(1,5);
            switch (enemyType)
            {
                case 1:
                    CreateEnemyTank1(position.X, position.Y);
                    break;
                case 2:
                    CreateEnemyTank2(position.X, position.Y);
                    break;
                case 3:
                    CreateEnemyTank3(position.X, position.Y);
                    break;
                case 4:
                    CreateEnemyTank4(position.X, position.Y);
                    break;
            }
            enemyBorncount = 0;
        }

        private static void CreateEnemyTank1(int x,int y)
        {
            EnemyTank tank = new EnemyTank(x,y,2,Resources.GrayDown, Resources.GrayUp, Resources.GrayRight, Resources.GrayLeft);
            tankList.Add(tank);
            SoundManager.PlayAdd();
        }
        private static void CreateEnemyTank2(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 2, Resources.GreenDown, Resources.GreenUp, Resources.GreenRight, Resources.GreenLeft);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank3(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 4, Resources.QuickDown, Resources.QuickUp, Resources.QuickRight, Resources.QuickLeft);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank4(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 1, Resources.SlowDown, Resources.SlowUp, Resources.SlowRight, Resources.SlowLeft);
            tankList.Add(tank);
        }
        public static void CreateMyTank()
        {
            int x = 6 * 30;
            int y = 14 * 30;
            mytank = new MyTank(x,y,2);
        }
        public static void CreateMap()
        {
            CreateWall(1,1,5,Resources.wall,wallList);
            CreateWall(3, 1, 5, Resources.wall, wallList);
            CreateWall(5, 1, 4, Resources.wall, wallList);
            CreateWall(7, 1, 3, Resources.wall, wallList);
            CreateWall(9, 1, 5, Resources.wall, wallList);
            CreateWall(11, 1, 5, Resources.wall, wallList);
            CreateWall(13, 1, 4, Resources.wall, wallList);

            CreateWall(6, 3, 1, Resources.steel, steelList);



            //CreateWall(1, 9, 5, Resources.wall, steelList);

            CreateWall(2, 7, 1, Resources.wall, wallList);
            CreateWall(3, 7, 1, Resources.wall, wallList);
            CreateWall(4, 7, 1, Resources.wall, wallList);

            CreateWall(6, 6, 1, Resources.wall, wallList);
            CreateWall(7, 5, 1, Resources.steel, steelList);
            CreateWall(7, 6, 1, Resources.wall, wallList);
            CreateWall(8, 6, 1, Resources.wall, wallList);

            CreateWall(11, 7, 1, Resources.wall, wallList);
            CreateWall(12, 7, 1, Resources.wall, wallList);
            CreateWall(13, 7, 1, Resources.wall, wallList);


            CreateWall(1,9 ,5, Resources.wall, wallList);
            CreateWall(3,9 ,5, Resources.wall, wallList);
            CreateWall(5,9 ,5, Resources.wall, wallList);
            CreateWall(7,8,4, Resources.wall, wallList);
            CreateWall(8, 9, 1, Resources.wall, wallList);
            CreateWall(9,8,4, Resources.wall, wallList);
            CreateWall(11,9,5, Resources.wall, wallList);
            CreateWall(13,9, 5, Resources.wall, wallList);

            CreateWall(0, 7, 1, Resources.steel, steelList);
            CreateWall(14, 7, 1, Resources.steel, steelList);

            CreateWallhalf(14, 27, 3, Resources.wall, wallList);
            CreateWallhalf(15, 27, 1, Resources.wall, wallList);
            CreateWallhalf(16, 27, 1, Resources.wall, wallList);
            CreateWallhalf(17, 27, 1, Resources.wall, wallList);
            CreateWallhalf(18, 27, 1, Resources.wall, wallList);
            CreateWallhalf(18, 28, 2, Resources.wall, wallList);

            CreateWallhalf(15, 28, 1, Resources.Boss, bosslList);

        }
        private static void CreateWall(int x,int y,int count,Image img ,List<NotMovingthing> wallList)
        {
            //List<NotMovingthing> wallList = new List<NotMovingthing>();
            int xPostion = x * 30;
            int yPostion = y * 30;
            for(int i = yPostion; i < yPostion + count * 30; i += 15)
            {
                //i xPosition i xPosition+15
                NotMovingthing wall1 = new NotMovingthing(xPostion, i,img);
                NotMovingthing wall2 = new NotMovingthing(xPostion+15,i,img);
                wallList.Add(wall1);
                wallList.Add(wall2);
            }
        }
        private static void CreateWallhalf(int x, int y, int count, Image img, List<NotMovingthing> wallList)
        {
            //List<NotMovingthing> wallList = new List<NotMovingthing>();
            int xPostion = x * 15;
            int yPostion = y * 15;
            for (int i = yPostion; i < yPostion + count * 15; i += 15)
            {
                //i xPosition i xPosition+15
                NotMovingthing wall1 = new NotMovingthing(xPostion, i, img);
                //NotMovingthing wall2 = new NotMovingthing(xPostion + 15, i, img);
                wallList.Add(wall1);
                //wallList.Add(wall2);
            }
        }
        public static void KeyDown(KeyEventArgs e)
        {
            mytank.KeyDown(e);
        }
        public static void KeyUp(KeyEventArgs e)
        {
            mytank.KeyUp(e);
        }


        public static NotMovingthing IsCollidedWall(Rectangle rt)
        {
            foreach(NotMovingthing wall in wallList)
            {
                if (wall.GetRectangle().IntersectsWith(rt))
                {
                    return wall;
                }
            }
            return null;
        }
        public static NotMovingthing IsCollidedSteel(Rectangle rt)
        {
            foreach (NotMovingthing stell in steelList)
            {
                if (stell.GetRectangle().IntersectsWith(rt))
                {
                    return stell;
                }
            }
            return null;
        }
        public static EnemyTank IsCollidedenEnemyTank(Rectangle rt)
        {
            foreach(EnemyTank e in tankList)
            {
                if (e.GetRectangle().IntersectsWith(rt))
                {
                    return e;
                }
            }
            return null;
        }
        public static MyTank IsCollidedMytank(Rectangle rt)
        {
            if(mytank.GetRectangle().IntersectsWith(rt))
            {
                return mytank;
            }
            return null;
        }
        public static NotMovingthing IsCollidedBoss(Rectangle rt)
        {
            foreach (NotMovingthing boss in bosslList)
            {
                if (boss.GetRectangle().IntersectsWith(rt))
                {
                    return boss;
                }
            }
            return null;
        }
    }
}
