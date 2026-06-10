using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.GameObjects
{
    internal abstract class GameObject
    {
        protected Position pos;
        public Position Pos => pos;
        protected string? icon;
        protected ConsoleColor color;
        public ConsoleColor Color => color;
        public GameObject(int x, int y)
        {
            pos = new Position(x, y);
        }

        public abstract void Draw();
            
    }
}
