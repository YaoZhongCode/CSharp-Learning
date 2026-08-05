using RussiaCube_V2.Core;
using RussiaCube_V2.Managers;
using RussiaCube_V2.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Scenes
{
    /// <summary>
    /// 游戏场景
    /// </summary>
    internal class GameScene : IScene
    {
        private GridMap _map;
        private TetrominoController _controller;
        private InputManager _inputManager;
        private ScoreManager _scoreManager;
        private DateTime _lastDropTime;

        public GameScene()
        {
            _map = new GridMap(10, 20);
            _controller = new TetrominoController();
            _inputManager = new InputManager();
            _scoreManager = new ScoreManager();
        }


        public void Enter()
        {
            Console.Clear();

            //订阅事件
            _inputManager.OnKeyPressed += OnKeyPress;
            _map.OnLinesCleared += OnLinesCleared;

            //启动按键监听
            _inputManager.StartListening();

            //生成首个方块
            SpawnNewTetromino();
            _lastDropTime = DateTime.Now;
        }

        public void Exit()
        {
            //解绑事件和停止监听
            _inputManager.OnKeyPressed -= OnKeyPress;
            _map.OnLinesCleared -= OnLinesCleared;
            _inputManager.StopListening();
        }

        public void Render()
        {
            //绘制地图里的固定格子
            for(int y = 0;  y < _map.Height; y++)
            {
                for(int x = 0; x < _map.Width; x++)
                {
                    Position pos = new Position(x, y);
                    ConsoleColor? color = _map.GetColor(pos);

                    if (color.HasValue)
                    {
                        ConsoleRenderer.DrawSquare(pos, color.Value);
                    }
                    else
                    {
                        ConsoleRenderer.ClearSquare(pos);
                    }
                }
            }

            //绘制当前下落的方块
            foreach (var pos in _controller.GetWorldPositions())
            {
                ConsoleRenderer.DrawSquare(pos, _controller.Color);
            }

            //显示UI
            ConsoleRenderer.DrawText(25, 2, $"当前得分：{_scoreManager.Score}");
        }

        public void Update()
        {
            //处理方块自动下落（每 500ms 掉落一格）
            if ((DateTime.Now - _lastDropTime).TotalMilliseconds >= 500)
            {
                _lastDropTime = DateTime.Now;

                //尝试下落，如果无法下落说明触底
                if(!_controller.TryMove(new Position(0, 1), _map))
                {
                    //固定方块并生成新方块
                    LockTetrominoAndSpawnNext();
                }
            }
        }

        /// <summary>
        /// 按下键盘
        /// </summary>
        /// <param name="key">按下的键</param>
        private void OnKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                //try to move to left side
                case ConsoleKey.A:
                    _controller.TryMove(new Position(-1, 0), _map);
                    break;
                    //try to move to right side
                case ConsoleKey.D:
                    _controller.TryMove(new Position(1, 0), _map);
                    break;
                    //加快下落
                case ConsoleKey.S:
                    _controller.TryMove(new Position(0, 1), _map);
                    break;
                    //逆时针旋转
                case ConsoleKey.LeftArrow:
                    _controller.TryRotate(false, _map);
                    break;
                    //顺时针旋转
                case ConsoleKey.RightArrow:
                    _controller.TryRotate(true, _map);
                    break;

            }
        }

        /// <summary>
        /// 消除行数
        /// </summary>
        /// <param name="count">消除的次数</param>
        private void OnLinesCleared(int count)
        {
            _scoreManager.AddScore(count * 10);
        }

        /// <summary>
        /// 固定方块并生成新方块
        /// </summary>
        private void LockTetrominoAndSpawnNext()
        {
            //将当前小方块固定到地图中
            foreach(var pos in _controller.GetWorldPositions())
            {
                _map.PlaceTile(pos, _controller.Color);
            }

            _map.ClearFullLines();

            SpawnNewTetromino();
        }

        /// <summary>
        /// 生成新方块
        /// </summary>
        private void SpawnNewTetromino()
        {
            //获取随机类型的方块
            TetrominoType randomType = (TetrominoType)Random.Shared.Next(0, 7);
            //初始地点
            Position startPos = new Position(_map.Width / 2 - 1, 0);

            _controller.Spawn(randomType, startPos, ConsoleColor.Yellow);

        }

    }
}
