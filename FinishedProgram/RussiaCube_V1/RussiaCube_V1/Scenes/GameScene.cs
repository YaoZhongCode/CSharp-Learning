using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Scenes
{
    internal class GameScene : IScene
    {
        public void Enter()
        {
            Console.Clear();
            Console.Write("游戏场景");
        }

        public IScene? Update()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if(key == ConsoleKey.Enter)
            {
                return new EndScene();
            }

            return null;
        }
    }
}
