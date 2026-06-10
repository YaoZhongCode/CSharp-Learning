using FlyChessV2_0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Scene
{
    internal class EndScene : StartOrEndBaseScene
    {
        private string secondTitle;
        private bool state;
        public EndScene(bool state) : base()
        {
            title = "游戏结束";
            this.state = state;
            secondTitle = state == true ? "！胜利！" : "！失败！";
            options.Add("回到主菜单");
            options.Add("退出游戏");
        }
        public override void Enter()
        {
            base.Enter();
            Console.SetCursorPosition(GameConfig.width / 2 - secondTitle.Length, GameConfig.height / 2 - 9);
            Console.ForegroundColor = state == true ? ConsoleColor.Green : ConsoleColor.DarkRed;
            Console.Write(" " + secondTitle);
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
                        return new StartScene();
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
