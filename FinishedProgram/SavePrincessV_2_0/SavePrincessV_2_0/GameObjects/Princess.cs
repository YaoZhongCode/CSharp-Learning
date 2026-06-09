using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.GameObjects
{
    /// <summary>
    /// 公主不用战斗，所以直接这样就好
    /// 不用给攻击力，不用给血量，甚至连名字都不用给
    /// </summary>
    internal class Princess : GameObject
    {
        public Princess(string icon, ConsoleColor color, int x, int y) : base(icon, color, x, y)
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
