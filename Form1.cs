using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_tankedazhan_dev
{
    public partial class Form1 : Form
    {
        private Thread t;
        private static Graphics WindowG;

        private static Bitmap tempBmp;
        public Form1()
        {
            InitializeComponent();

            WindowG = this.CreateGraphics();
            //GameFramework.g = g;

            tempBmp = new Bitmap(450,450);
            Graphics bmpG =  Graphics.FromImage(tempBmp);
            GameFramework.g = bmpG;

            this.StartPosition = FormStartPosition.CenterParent;
            //阻塞
            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();
        }

        //创建线程，必须要调用一个静态方法，因为可以通过类来调用；普通方法需要通过对象调用
        private static void GameMainThread()
        {
            
            //GameFramework 游戏框架
            GameFramework.Start();
            int sleepTime = 1000 / 60;
            //每秒调用约60次
            while (true)
            {
                GameFramework.g.Clear(Color.Black);
                GameFramework.Update();//60
                WindowG.DrawImage(tempBmp, 0, 0);
                Thread.Sleep(sleepTime);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
        }
    }
}
