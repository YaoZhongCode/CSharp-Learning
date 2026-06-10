using FlyChessV2_0.Core;
using FlyChessV2_0.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Polymer
{
    internal class Walls
    {
        private Wall[] walls;
        private int index;
        public Walls()
        {
            index = 0;
            walls = new Wall[GameConfig.height * 2 + (GameConfig.width - 4) * 4];

            //竖墙
            for(int i = 0; i < GameConfig.height; i++)
            {
                walls[index] = new Wall(0, i);
                index++;
                walls[index] = new Wall(GameConfig.width - 2, i);
                index++;
            }

            //横墙
            for(int i = 2; i < GameConfig.width - 2; i += 2)
            {
                walls[index] = new Wall(i, 0);
                index++;
                walls[index] = new Wall(i, GameConfig.height / 2 + 4);
                index++;
                walls[index] = new Wall(i, GameConfig.height / 2 + 12);
                index++;
                walls[index] = new Wall(i, GameConfig.height - 1);
                index++;
            }
        }

        public void Draw()
        {
            for(int i = 0; i < walls.Length; i++)
            {
                if (walls[i] != null)
                {
                    walls[i].Draw();
                }
            }
        }
    }
}
