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
        //格子地图宽
        public int Width { get; }
        //格子地图高
        public int Height { get; }

        //二维数组：存储网格中每个格子的颜色状态（null 代表空）
        private readonly ConsoleColor?[,] _grid;

        public event Action<int>? OnLinesCleared;

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

        /// <summary>
        /// 检查并消除满行
        /// </summary>
        /// <returns>返回本次消除的总行数</returns>
        public int ClearFullLines()
        {
            //记录消除了几行
            int lineCleared = 0;

            //遍历从第一行（地图最底部）到最后一行
            for(int y = Height - 1; y >= 0; y--)
            {
                //如果该行格子满了
                if (IsLineFull(y))
                {
                    //消除行数自增
                    lineCleared++;

                    //整体往下移动一格（相当于消除了此行）
                    ShiftRowsDown(y);

                    //因为上方掉落下来到了当前的y行，需要重新检测一遍当前的y行
                    y++;
                }
            }

            //如果有行被消除，广播事件
            if (lineCleared > 0) OnLinesCleared?.Invoke(lineCleared);
            //返回出去消除的行数
            return lineCleared;
        }

        /// <summary>
        /// 是否满行
        /// </summary>
        /// <param name="y">y坐标</param>
        /// <returns></returns>
        private bool IsLineFull(int y)
        {
            for(int x =0; x < Width; x++)
            {
                if (_grid[x, y] == null)
                {
                    //只要有一格为空，说明还未满行，返回false
                    return false; 
                }
            }
            return true;
        }

        /// <summary>
        /// 将指定行上的所有整体下移一格
        /// </summary>
        /// <param name="targetY">指定行</param>
        private void ShiftRowsDown(int targetY)
        {
            //从被消除那一行开始，向上遍历所有格
            //y轴（不遍历最后一行）
            for(int y = targetY; y > 0; y--)
            {
                //x轴
                for(int x = 0; x < Width; x++)
                {
                    //下移一格
                    _grid[x, y] = _grid[x, y - 1];
                }
            }

            //最顶上一行已是最后一行，其上面无格子，直接清空
            for(int x = 0; x < Width; x++)
            {
                _grid[x, 0] = null;
            }
        }
    }
}
