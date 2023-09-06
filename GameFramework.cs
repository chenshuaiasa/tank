using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_tankedazhan_dev
{
    internal class GameFramework
    {
        public static Graphics g;

        public GameFramework()
        {
        }

        public static void Start()
        {
            GameObjectManager.Start();
            GameObjectManager.CreateMap();
            GameObjectManager.CreateMyTank();
        }
        public static void Update()
        {//FPS
            //GameObjectManager.DrawMap();
            //GameObjectManager.DrawMytank();
            GameObjectManager.Update();
        }

        //消息中间站
        public static void KeyDown(KeyEventArgs e)
        {

        }
        public static void KeyUp(KeyEventArgs e)
        {

        }
    }
}
