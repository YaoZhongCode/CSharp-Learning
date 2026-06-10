using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnakeV2_0.GameObjects
{
    enum ECubeType
    {
        Head,
        Body
    }

    internal class SnakeCube : GameObject
    {
        public ECubeType cubeType;
        public SnakeCube(ECubeType cubeType, int x, int y)
        {
            position = new Position(x, y);
            this.cubeType = cubeType;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = cubeType == ECubeType.Head ? ConsoleColor.Blue : ConsoleColor.Cyan;
            Console.Write(cubeType == ECubeType.Head ? "◎" : "○");
        }
    }
}
