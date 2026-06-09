using SavePrincessV_2_0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.Scenes
{
    /// <summary>
    /// 抽象基类-开始或结束页面
    /// </summary>
    internal abstract class StartOrEndBaseScene : IScene
    {
        protected int width;
        protected int height;
        protected int selectID;

        protected string? title;

        protected string? firstOption;

        protected string? secondOption;

        protected ConsoleKey key;

        public StartOrEndBaseScene(int width, int height, string title)
        {
            this.width = width;
            this.height = height;
            this.title = title;
            secondOption = "退出游戏";
            selectID = 0;
        }

        public virtual void Enter()
        {
            Console.Clear(); //进来先清理屏幕
            Console.SetCursorPosition(width / 2 - title!.Length, height / 2 - 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(title);

        }
        public abstract IScene? Update();
    }
}
