using FlyChessV2_0.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Core
{
    internal class Game
    {
        SceneManager sceneManager;

        public Game()
        {
            sceneManager = new SceneManager();
            sceneManager.SwitchScene(new StartScene());
        }

        /// <summary>
        /// 启动游戏
        /// </summary>
        public void Run()
        {
            Console.CursorVisible = false;

            while (true)
            {
                sceneManager.Update();
            }
        }
    }
}
