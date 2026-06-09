using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.GameObjects
{
    internal abstract class GameObject : IDraw
    {
        protected string icon;

        protected ConsoleColor color;

        public GameObject(string icon, ConsoleColor color, int x, int y)
        {
            this.icon = icon;
            this.color = color;
            pos = new Position(x, y);
        }

        protected Position pos;
        public Position Pos { get { return pos; } }
        public abstract void Draw();


    }
}
