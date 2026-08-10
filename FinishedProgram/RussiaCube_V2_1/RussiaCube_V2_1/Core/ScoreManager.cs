using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Core
{
    /// <summary>
    /// 分数管理器
    /// </summary>
    internal class ScoreManager
    {
        //分数改变事件
        public event Action<int>? OnScoreChange;

        //当前分数
        public int Score { get; private set; }
        private readonly GameConfig _config;

        public ScoreManager(GameConfig config)
        {
            //拿到游戏配置引用
            _config = config;
        }

        /// <summary>
        /// 增加分数
        /// </summary>
        /// <param name="clearedRows">消除的行数</param>
        public void AddScore(int clearedRows)
        {
            
            //可以确定一次最多只能消除4行
            //所以switch分出4个分支来处理加分
            switch (clearedRows)
            {
                case 1:
                    Score += _config.OneRowScore;
                    break;
                case 2:
                    Score += _config.TwoRowScore;
                    break;
                case 3:
                    Score += _config.ThreeRowScore;
                    break;
                case 4:
                    Score += _config.FourRowScore;
                    break;
            }

            //广播：分数变了！谁关心谁处理！
            OnScoreChange?.Invoke(Score);
        }
    }
}
