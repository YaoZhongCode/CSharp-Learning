using HungrySnakeV2_0.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnakeV2_0.Core
{
    internal class Game
    {
        SceneManager sceneManager;

        public Game()
        {
            Console.Clear();
            sceneManager = new SceneManager();
            sceneManager.ChangeScene(new BeginScene(sceneManager));
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 30);
        }
        public void Run()
        {
            while (true)
            {
                sceneManager.Update();
                Thread.Sleep(100);
            }
        }

        //private void Update()
        //{
        //    Console.SetCursorPosition(45, 15);
        //    Console.Write("游戏运行中");
        //}
    }
}
