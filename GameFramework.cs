using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_tankedazhan_dev
{
    enum GameState
    {
        Runing,
        GameOver
    }
    internal class GameFramework
    {
        public static Graphics g;
        private static GameState gameState = GameState.Runing;

        public GameFramework()
        {
        }

        public static void Start()
        {
            GameObjectManager.Start();
            GameObjectManager.CreateMap();
            GameObjectManager.CreateMyTank();
            SoundManager.InitSound();
            SoundManager.PlayStart();
        }
        public static void Update()
        {//FPS
            //GameObjectManager.DrawMap();
            //GameObjectManager.DrawMytank();
            if(gameState == GameState.Runing)
            {
                GameObjectManager.Update();
            }
            else if(gameState == GameState.GameOver)
            {
                GameOverUpdate();
            }
            
        }
        private static void GameOverUpdate()
        {
            int x = 450/2 - Properties.Resources.GameOver.Width/2;
            int y = 450/2 - Properties.Resources.GameOver.Height/2;
            g.DrawImage(Properties.Resources.GameOver,x,y);
        }
        public static void ChangeToGameOver()
        {
            gameState = GameState.GameOver;
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
