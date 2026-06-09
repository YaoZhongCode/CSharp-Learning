using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.GameObjects
{
    internal class Player : Role
    {
        public Player(string icon, ConsoleColor color, int x, int y, int HP, int minAtk, int maxAtk, string name) : base(icon, color, x, y, HP, minAtk, maxAtk, name)
        {
        }

        public void Move(ConsoleKey key,Position otherPos, int width, int height, bool otherIsDead)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    pos.Y--;
                    if (pos.Y < 1 || pos.Equals(otherPos) && !otherIsDead) pos.Y++;
                    break;
                case ConsoleKey.S:
                    pos.Y++;
                    if (pos.Y > height - 11 || pos.Equals(otherPos) && !otherIsDead) pos.Y--;
                    break;
                case ConsoleKey.A:
                    pos.X -= 2;
                    if (pos.X < 2 || pos.Equals(otherPos) && !otherIsDead) pos.X += 2;
                    break;
                case ConsoleKey.D:
                    pos.X += 2;
                    if (pos.X > width - 4 || pos.Equals(otherPos) && !otherIsDead) pos.X -= 2;
                    break;
            }
        }
    }
}
