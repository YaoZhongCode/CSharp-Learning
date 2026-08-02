using RussiaCube_V1.Core;
using RussiaCube_V1.Polymer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Scenes
{
    internal class GameScene : IScene
    {
        //创建地图
        Map _map;
        CubeManager _cubeManager;
        public GameScene()
        {
            _map = new Map();
            _cubeManager = new CubeManager();
        }
        public void Enter()
        {
            Console.Clear();
            _map.DrawDeadWall(); //画出不变的墙壁
        }

        public IScene? Update()
        {
            _cubeManager.Draw();
            Input();

            return null;
        }

        /// <summary>
        /// 输入系统
        /// </summary>
        private void Input()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    _cubeManager.SwitchShape(E_SwitchDirection.Left, _map);
                    Console.SetCursorPosition(2, GameConfig.height - 6);
                    Console.Write("按下了左箭头");
                    break;
                case ConsoleKey.RightArrow:
                    _cubeManager.SwitchShape(E_SwitchDirection.Right, _map);
                    Console.SetCursorPosition(2, GameConfig.height - 6);
                    Console.Write("按下了右箭头");
                    break;
                case ConsoleKey.A:
                    _cubeManager.MoveLeftOrRight(E_MoveDirection.Left);
                    break;
                case ConsoleKey.D:
                    _cubeManager.MoveLeftOrRight(E_MoveDirection.Right);
                    break;
            }
        }
    }
}
