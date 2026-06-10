using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnakeV2_0.GameObjects
{
    internal abstract class GameObject : IDraw
    {
        public Position position;

        public abstract void Draw();
    }
}
