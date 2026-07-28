using RussiaCube_V1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Scenes
{
    internal class StartScene : StartOrEndBaseScene
    {
        public StartScene(string title = "标题") : base(title)
        {
            _title = "俄罗斯方块";
            _options.Add("开始游戏");
            _options.Add("结束游戏");
        }

        public override IScene? Update()
        {
            //处理第一个选项
            Console.SetCursorPosition((GameConfig.width / 2 - _options[0].Length) - 1, 8);
            Console.ForegroundColor = _nowSelectID == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(_nowSelectID == 0 ? ">" + _options[0] : " " + _options[0]);

            //处理第二个选项
            Console.SetCursorPosition((GameConfig.width / 2 - _options[1].Length) - 1, 10);
            Console.ForegroundColor = _nowSelectID == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(_nowSelectID == 1 ? ">" + _options[1] : " " + _options[1]);

            //处理键盘输入
            _inputKey = Console.ReadKey(true).Key;
            switch (_inputKey)
            {
                case ConsoleKey.W:
                    _nowSelectID--;
                    if (_nowSelectID < 0) _nowSelectID = 0;
                    break;
                case ConsoleKey.S:
                    _nowSelectID++;
                    if (_nowSelectID > 1) _nowSelectID = 1;
                    break;
                case ConsoleKey.J:
                case ConsoleKey.Enter:
                    switch (_nowSelectID)
                    {
                        case 0:
                            return new GameScene();
                        case 1:
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }

            return null;
        }
    }
}
