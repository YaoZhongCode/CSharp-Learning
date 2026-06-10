using FlyChessV2_0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Scene
{
    internal class StartScene : StartOrEndBaseScene
    {
        public StartScene() : base()
        {
            options.Add("开始游戏");
            options.Add("退出游戏");
        }
        public override IScene? Update()
        {
            Console.SetCursorPosition(GameConfig.width / 2 - options[0].Length, GameConfig.height / 2 - 5);
            Console.ForegroundColor = selectID == 0 ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write(selectID == 0 ? ">" + options[0] : " " + options[0]);

            Console.SetCursorPosition(GameConfig.width / 2 - options[1].Length, GameConfig.height / 2 - 3);
            Console.ForegroundColor = selectID == 1 ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write(selectID == 1 ? ">" + options[1] : " " + options[1]);

            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.W:
                    selectID--;
                    if (selectID < 0) selectID = 0;
                    break;
                case ConsoleKey.S:
                    selectID++;
                    if (selectID > 1) selectID = 1;
                    break;
                case ConsoleKey.J:
                case ConsoleKey.Enter:
                    if(selectID == 0)
                    {
                        return new GameScene();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                    break;
            }


            return null;
        }
    }
}
