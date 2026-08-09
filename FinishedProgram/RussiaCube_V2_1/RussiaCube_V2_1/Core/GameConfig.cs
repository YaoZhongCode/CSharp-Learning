using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Core
{
    /// <summary>
    /// 游戏配置
    /// </summary>
    internal class GameConfig
    {
        //一次性消除行数的得分规则
        public int OneRowScore { get; } = 100;
        public int TwoRowScore { get; } = 300;
        public int ThreeRowScore { get; } = 500;
        public int FourRowScore { get; } = 800;
    }
}
