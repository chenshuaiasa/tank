using _06_tankedazhan_dev.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_tankedazhan_dev
{
    internal class GameObjectManager
    {
        private static List<NotMovingthing> wallList = new List<NotMovingthing>();
        private static List<NotMovingthing> steelList = new List<NotMovingthing>();

        public static void DrawMap()
        {
            foreach (NotMovingthing nm in wallList) { 
                nm.DrawSelf();
            }
            foreach (NotMovingthing nm in steelList)
            {
                nm.DrawSelf();
            }
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
    }
}
