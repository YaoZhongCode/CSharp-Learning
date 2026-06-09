using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.GameObjects
{
    internal struct Position
    {
        public int X;
        public int Y;
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void RenewPos(Position pos)
        {
            X = pos.X;
            Y = pos.Y;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if(obj is Position)
            {
                Position p = (Position)obj;
                return X == p.X && Y == p.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        /// <summary>
        /// 检查是否在周围
        /// </summary>
        /// <param name="p">要检查的位置</param>
        /// <returns></returns>
        public bool IsAround(Position p)
        {
            if(X == p.X && Y == p.Y+1 ||
                X == p.X && Y == p.Y-1 ||
                Y == p.Y && X == p.X - 2 ||
                Y == p.Y && X == p.X + 2)
            {
                return true;
            }

            return false;
        }

    }
}
