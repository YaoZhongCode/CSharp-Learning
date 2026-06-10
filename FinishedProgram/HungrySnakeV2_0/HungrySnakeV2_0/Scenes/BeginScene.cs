using HungrySnakeV2_0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnakeV2_0.Scenes
{
    internal class BeginScene : IScene
    {
        SceneManager sceneManager;
        private int selectID = 0;
        public BeginScene(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
            Console.SetCursorPosition(45, 8);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("☆贪吃蛇☆");
        }
        public void Update()
        {
            Console.SetCursorPosition(46, 10);
            Console.ForegroundColor = selectID == 0 ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write("开始游戏");

            Console.SetCursorPosition(48, 12);
            Console.ForegroundColor = selectID == 1 ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write("退出");
            Console.ForegroundColor = ConsoleColor.White;

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    selectID = Math.Max(0, --selectID);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    selectID = Math.Min(1, ++selectID);
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.J:
                    //测试用，是否有触发对应按键，后续会注释掉
                    Console.SetCursorPosition(0, 15);
                    Console.Write("                                                                                                                             ");
                    string temp = selectID == 0 ? "触发了开始游戏" : "触发了退出";
                    Console.SetCursorPosition(100 / 2 - temp.Length, 15);
                    Console.Write(temp);
                    break;
            }
        }
    }
}
