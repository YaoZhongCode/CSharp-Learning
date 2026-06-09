using SavePrincessV_2_0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.Scenes
{
    internal class StartScene : StartOrEndBaseScene
    {
        public StartScene(int width, int height) : base(width, height, "耀中大人拯救公主")
        {
            firstOption = "开始游戏";
            
        }

        public override IScene? Update()
        {
            Console.SetCursorPosition(width / 2 - firstOption!.Length, height / 2 - 2);
            Console.ForegroundColor = selectID == 0 ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write(firstOption);

            Console.SetCursorPosition(width / 2 - firstOption.Length, height / 2);
            Console.ForegroundColor = selectID == 1 ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write(secondOption);

            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    selectID--;
                    if (selectID < 0) selectID = 0;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    selectID++;
                    if (selectID > 1) selectID = 1;
                    break;
                case ConsoleKey.J:
                case ConsoleKey.Enter:
                    if(selectID == 0)
                    {
                        return new GameScene(width, height);
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
