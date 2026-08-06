using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Core
{
    /// <summary>
    /// 坐标位置
    /// </summary>
    internal readonly struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        //重载+法运算符
        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }
    }
}
