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
        //地图宽度
        public int MapWidth { get; } = 11;

        //地图高度
        public int MapHeight { get; } = 20;

        //下落间隔
        public int FallIntervalMilliseconds { get; } = 500;

        public int MinimumFallIntervalMilliseconds { get; } = 50;

        //每当达到一次这个分数，加快下落速度
        public int CheckScore { get; } = 3000;

        //一次性消除行数的得分规则
        public int OneRowScore { get; } = 100;
        public int TwoRowScore { get; } = 300;
        public int ThreeRowScore { get; } = 500;
        public int FourRowScore { get; } = 800;
    }
}
