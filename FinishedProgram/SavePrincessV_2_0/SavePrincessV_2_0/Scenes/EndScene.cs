using SavePrincessV_2_0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.Scenes
{
    internal class EndScene : StartOrEndBaseScene
    {
        string stateTitle;
        EBattleResult result;

        public EndScene(int width, int height, string title, string endStateTitle, EBattleResult result) : base(width, height, title)
        {
            stateTitle = endStateTitle;
            this.result = result;
            firstOption = "回到主菜单";
        }

        public override void Enter()
        {
            base.Enter();
            Console.SetCursorPosition(width / 2 - 4, height / 2 - 4);
            //Continue时不会传进来，所以只可能是玩家赢或者boss赢
            Console.ForegroundColor = result == EBattleResult.Role1Win ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(stateTitle);
        }

        public override IScene? Update()
        {
            if(firstOption != null)
            {
                Console.SetCursorPosition(width / 2 - firstOption.Length, height / 2 - 1);
                Console.ForegroundColor = selectID == 0 ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.Write(firstOption);
            }
            if(secondOption != null)
            {
                Console.SetCursorPosition(width / 2 - secondOption.Length, height / 2 + 1);
                Console.ForegroundColor = selectID == 1 ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.Write(secondOption);
            }
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
                        return new StartScene(width, height);
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
