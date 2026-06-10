using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.GameObjects
{
    internal class Wall : GameObject
    {

        public Wall(int x, int y) : base(x, y)
        {
            icon = "■";
            color = ConsoleColor.DarkGray;
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.ForegroundColor = color;
            Console.Write(icon);
        }
    }
}
