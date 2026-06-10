using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnakeV2_0.GameObjects
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
    }
}
