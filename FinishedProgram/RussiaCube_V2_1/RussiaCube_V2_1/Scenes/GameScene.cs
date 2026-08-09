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

        //记录上次掉落时间
        private DateTime _lastFallTime;

        //掉落间隔
        private readonly TimeSpan _fallInterval;

        public GameScene()
        {
            //初始化地图和方块管理器
            _map = new Map(10, 20);
            _tetrominoManager = new TetrominoManager(_map);
            _lastFallTime = DateTime.Now;
            _fallInterval = TimeSpan.FromMilliseconds(500);
        }

        public void Enter()
        {
            //生成方块
            _tetrominoManager.Spawn();
        }

        
        public void Update()
        {
            HandleInput();
            if(DateTime.Now - _lastFallTime >= _fallInterval)
            {
                _tetrominoManager.Fall();
                _lastFallTime = DateTime.Now;
            }

        }

        /// <summary>
        /// 输入管理
        /// </summary>
        private void HandleInput()
        {
            //有键盘按下时才进入逻辑
            if (Console.KeyAvailable)
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
}
