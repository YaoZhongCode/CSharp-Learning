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

        //分数管理
        private readonly ScoreManager _scoreManager;

        //记录上次掉落时间
        private DateTime _lastFallTime;

        //掉落间隔
        private TimeSpan _fallInterval;

        //游戏配置信息
        private readonly GameConfig _config;

        //速度等级
        private int _speedLevel;

        public GameScene()
        {
            _config = new GameConfig();
            //初始化地图和方块管理器
            _map = new Map(_config.MapWidth, _config.MapHeight);
            _tetrominoManager = new TetrominoManager(_map);
            _scoreManager = new ScoreManager(_config);
            _fallInterval = TimeSpan.FromMilliseconds(_config.FallIntervalMilliseconds);
            _speedLevel = 0;
        }

        public void Enter()
        {
            //生成方块
            _tetrominoManager.Spawn();

            _lastFallTime = DateTime.Now;

            //订阅分数改变事件
            _scoreManager.OnScoreChange += CheckSpeed;
        }

        
        public void Update()
        {
            HandleInput();

            //隔一段时间自动下落
            if(DateTime.Now - _lastFallTime >= _fallInterval)
            {
                HandleFall();
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
                        HandleFall();
                        break;
                    case ConsoleKey.J:
                        _tetrominoManager.Rotate();
                        break;
                }
            }
        }

        /// <summary>
        /// 处理下落检测消除行数加分逻辑
        /// </summary>
        private void HandleFall()
        {
            bool fallSuccess = _tetrominoManager.Fall();

            //如果下落失败并且消除行数大于0
            if (!fallSuccess && _tetrominoManager.LastClearedRows > 0)
            {
                //更新分数
                _scoreManager.AddScore(_tetrominoManager.LastClearedRows);
            }
        }

        public void Exit()
        {
            //解绑分数改变事件
            _scoreManager.OnScoreChange -= CheckSpeed;
        }

        /// <summary>
        /// 检查分数，达到条件就加快掉落速度
        /// </summary>
        /// <param name="score">当前分数</param>
        private void CheckSpeed(int score)
        {
            //如果分数达到设定的条件，就加快方块下落速度，否则不做任何处理
            //同时限制最低下落速度，以免降到0
            if(score / _config.CheckScore > _speedLevel && _fallInterval >= TimeSpan.FromMilliseconds(_config.MinimumFallIntervalMilliseconds))
            {
                //更新等级，等待下次超过这个等级时再次加速
                //由于不可能一次性消除获得3000分，所以不会存在需要加速两次却只加速一次的问题
                _speedLevel = score / _config.CheckScore;
                _fallInterval -= TimeSpan.FromMilliseconds(50);
            }
        }
    }
}
