using FlyChessV2_0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Scene
{
    internal abstract class StartOrEndBaseScene : IScene
    {
        protected string title;
        protected List<string> options;
        protected int selectID;
        protected ConsoleKey key;
        public StartOrEndBaseScene()
        {
            options = new List<string>();
            selectID = 0;
            title = "☆飞行棋☆";
        }

        public virtual void Enter()
        {
            Console.Clear();
            Console.SetCursorPosition((GameConfig.width / 2 - title.Length) + 1, GameConfig.height / 2 - 10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(title);
        }

        public abstract IScene? Update();
    }
}
