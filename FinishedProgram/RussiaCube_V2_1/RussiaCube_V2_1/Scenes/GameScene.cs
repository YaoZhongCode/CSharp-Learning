using RussiaCube_V2_1.Core;
using RussiaCube_V2_1.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Scenes
{
    /// <summary>
    /// 游戏场景
    /// </summary>
    internal class GameScene : IScene
    {
        //地图
        private readonly Map _map;
        //方块管理
        private readonly TetrominoManager _tetrominoManager;

        public GameScene()
        {
            //初始化地图和方块管理器
            _map = new Map(10, 20);
            _tetrominoManager = new TetrominoManager(_map);
        }

        public void Enter()
        {
            //生成方块
            _tetrominoManager.Spawn();
        }


        public void Update()
        {

        }

        private void HandleInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    _tetrominoManager.Move(new Position(-1, 0));
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    _tetrominoManager.Move(new Position(1, 0));
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    _tetrominoManager.Fall();
                    break;
                case ConsoleKey.J:
                    _tetrominoManager.Rotate();
                    break;
            }

        }
    }
}
