using RussiaCube_V2_1.Core;
using RussiaCube_V2_1.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Maps
{
    /// <summary>
    /// 游戏地图（棋盘）
    /// </summary>
    internal class Map
    {
        //用一个二维数组表示地图（元素允许为 null）
        private readonly Block?[,] _blocks;

        //索引器
        public Block? this[int x, int y] => _blocks[x, y];

        //宽
        public int Width { get; }

        //高
        public int Height { get; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            _blocks = new Block?[width, height];
        }

        /// <summary>
        /// 检查是否位于地图内
        /// </summary>
        /// <param name="pos">要检查的坐标</param>
        /// <returns>true=在地图内, false=不在地图内</returns>
        public bool IsInside(Position pos)
        {
            //X 轴需要大于等于0且小于宽度
            //Y 轴需要大于等于0且小于高度
            // 都符合说明在地图内 返回true
            //都不符合说明不在地图内 返回false
            return pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height;
        }

        /// <summary>
        /// 检查该位置是否已经被占用
        /// </summary>
        /// <param name="pos">要检查的坐标</param>
        /// <returns>true=被占用, false=该位置空</returns>
        public bool IsOccupied(Position pos)
        {
            //如果棋盘的该位置不为空，说明有东西存在，返回true(被占用)
            if (_blocks[pos.X, pos.Y] != null) return true;

            //如果为空，返回false(未被占用)
            return false;
        }
    }
}
