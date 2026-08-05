using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RussiaCube_V2.GameObjects
{
    internal struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        // 重载 + 运算符：实现坐标直接相加
        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        // 重写 Equals 判定坐标相等
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if(obj is Position other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
