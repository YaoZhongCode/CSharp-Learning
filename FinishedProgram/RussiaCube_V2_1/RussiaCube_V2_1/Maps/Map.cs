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

        /// <summary>
        /// 清理满行的地图
        /// </summary>
        /// <returns>返回消除的行数</returns>
        public int ClearFullRows()
        {
            //记录消除的行数
            int rowsCleared = 0;

            //从最地下一行开始往上遍历
            for(int y = Height - 1; y >= 0; y--)
            {
                //如果某一行满了
                if (IsRowFull(y))
                {
                    //整体下移
                    ShiftRowDown(y);
                    //计数消除行数
                    rowsCleared++;

                    //因为消除了这一行，它上面的格子落下来，需要重新检测一遍这一行
                    y++;
                }
            }
            return rowsCleared;
        }

        /// <summary>
        /// 检查指定行是否满格
        /// </summary>
        /// <param name="y">指定的高度</param>
        /// <returns></returns>
        private bool IsRowFull(int y)
        {
            for(int x = 0; x < Width; x++)
            {
                //如果该高度里有任一一格空，不满行，返回false
                if (_blocks[x, y] == null)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 将指定行之上的所有格子数据往下移动
        /// </summary>
        /// <param name="targetY">指定高度</param>
        private void ShiftRowDown(int targetY)
        {
            //将指定行之后的每一行都下移
            for(int y = targetY; y > 0; y--)
            {
                for(int x = 0; x < Width; x++)
                {
                    _blocks[x, y] = _blocks[x, y - 1];
                }
            }

            //置空最上面一行
            //（它的上面已没有方块可以下移，它本身的数据已下移，所以需要清空）
            for(int x = 0; x < Width; x++)
            {
                _blocks[x, 0] = null;
            }
        }
    }
}
