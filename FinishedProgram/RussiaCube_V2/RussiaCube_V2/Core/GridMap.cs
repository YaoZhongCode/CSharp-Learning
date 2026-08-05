using RussiaCube_V2.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Core
{
    /// <summary>
    /// 方块地图，这次改用二维数组来做矩阵
    /// </summary>
    internal class GridMap
    {
        public int Width { get; }
        public int Height { get; }

        //二维数组：存储网格中每个格子的颜色状态（null 代表空）
        private readonly ConsoleColor?[,] _grid;

        public GridMap(int width, int height)
        {
            Width = width;
            Height = height;
            _grid = new ConsoleColor?[width, height];
        }

        /// <summary>
        /// 判断坐标是否在地图范围内（不含上边界，因为方块是从顶部屏幕外 -Y 掉落进来的）
        /// </summary>
        /// <param name="pos">要判断的坐标</param>
        /// <returns></returns>
        public bool IsInsideBounds(Position pos)
        {
            //X 必须在 [0, Width - 1] 之间，Y 必须小于 Height
            return pos.X >= 0 && pos.X < Width && pos.Y < Height;
        }

        /// <summary>
        /// 判断某个坐标是否已经被占用（超出边界 或 已有方块）
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool IsOccupied(Position pos)
        {
            //如果Y小于0，说明方块还在地图上方外面，不认为被阻挡
            if (pos.Y < 0) return false;

            //如果超出了左右边界或底边界，视为阻挡
            if (pos.X < 0 || pos.X >= Width || pos.Y >= Height)
            {
                return true;
            }

            //检查格子上是否已经有固定的方块
            return _grid[pos.X, pos.Y] != null;
        }

        /// <summary>
        /// 放置固定方块
        /// </summary>
        /// <param name="pos">位置</param>
        /// <param name="color">颜色</param>
        public void PlaceTile(Position pos, ConsoleColor color)
        {
            //检测是否在地图内
            if(pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height)
            {
                _grid[pos.X, pos.Y] = color;
            }
        }

        /// <summary>
        /// 获取指定位置格子的颜色（供渲染使用）
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public ConsoleColor? GetColor(Position pos)
        {
            //检测是否在地图内
            if (pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height)
            {
                return _grid[pos.X, pos.Y];
            }

                return null;
        }
    }
}
