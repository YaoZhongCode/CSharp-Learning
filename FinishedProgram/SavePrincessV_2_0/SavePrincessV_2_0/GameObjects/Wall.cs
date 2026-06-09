using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.GameObjects
{
    internal class Wall : GameObject
    {
        public Wall(int x, int y,string icon = "■", ConsoleColor color = ConsoleColor.DarkGray) : base(icon, color, x, y)
        {
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.ForegroundColor = color;
            Console.Write(icon);
        }
    }
}
