using RussiaCube_V1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Scenes
{
    //开始或结束基类
    internal abstract class StartOrEndBaseScene : IScene
    {
        protected string _title;
        protected List<string> _options;
        protected int _nowSelectID;
        protected ConsoleKey _inputKey;
        public StartOrEndBaseScene(string title = "标题")
        {
            _title = title;
            _options = new List<string>();
            _nowSelectID = 0;
        }

        //允许子类重写
        public virtual void Enter()
        {
            Console.Clear();
            Console.SetCursorPosition(GameConfig.width / 2 - _title.Length, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(_title);
        }

        public abstract IScene? Update();
    }
}
