using SavePrincessV_2_0.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.Polymer
{
    internal class Maps : IDraw
    {
        //墙壁不会动态变多或变少，直接用数组
        private Wall[] walls;
        private int index; //记录墙壁数量

        public Maps(int width, int height)
        {
            index = 0;
            walls = new Wall[height * 2 + width / 2 * 3 - 6];
            //左右两边墙
            for(int i = 0; i < height; i++)
            {
                walls[index] = new Wall(0, i);
                index++; //每记录一个墙壁，索引+1
                walls[index] = new Wall(width - 2, i);
                index++;
            }
            //上中下墙壁
            for(int i = 2; i < width - 2; i += 2)
            {
                walls[index] = new Wall(i, 0);
                index++;
                walls[index] = new Wall(i, height - 10);
                index++;
                walls[index] = new Wall(i, height - 1);
                index++;
            }
        }

        public void Draw()
        {
            for(int i = 0; i < walls.Length; i++)
            {
                walls[i].Draw();
            }
        }
    }
}
