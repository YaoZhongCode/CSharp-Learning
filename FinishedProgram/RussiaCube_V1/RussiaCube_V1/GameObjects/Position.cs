using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RussiaCube_V1.GameObjects
{
    //位置结构体
    internal struct Position
    {
        public int X;
        public int Y;
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        //重写相等方法
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if(obj is Position)
            {
                Position temp = (Position)obj;
                if(temp.X == X && temp.Y == Y)
                {
                    return true;
                }
            }
            return false;
        }

        //重写获取哈希值方法
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        //加法重载（实现方块偏移）
        public static Position operator +(Position p1, Position p2)
        {
            Position temp = new Position(p1.X + p2.X, p1.Y + p2.Y);
            return temp;
        }
    }
}
