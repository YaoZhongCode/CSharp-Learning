using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Managers
{
    /// <summary>
    /// 分数管理器
    /// </summary>
    internal class ScoreManager
    {
        private int _score;
        // 只读属性：外部只能读取分数
        public int Score => _score;
        // 分数改变事件：当分数发生变动时通知订阅者，传递当前最新的分数
        public event Action<int>? OnScoreChanged;

        public ScoreManager()
        {
            _score = 0;
        }

        /// <summary>
        /// 增加分数方法
        /// </summary>
        /// <param name="amount">怎加的分数值</param>
        public void AddScore(int amount)
        {
            if (amount <= 0) return;

            _score += amount;

            // 触发事件：通知所有关心分数变动的地方
            OnScoreChanged?.Invoke(_score);
        }

        /// <summary>
        /// 重置分数
        /// </summary>
        public void Reset()
        {
            _score = 0;

            //触发事件
            OnScoreChanged?.Invoke(_score);
        }
    }
}
