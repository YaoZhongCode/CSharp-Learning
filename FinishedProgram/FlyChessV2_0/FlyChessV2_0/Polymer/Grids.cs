using FlyChessV2_0.Core;
using FlyChessV2_0.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Polymer
{
    internal class Grids
    {
        private List<Grid> grids;
        public int Length => grids.Count;
        private int gapeX;
        private int gapeY;
        private int turn;

        public Grid this[int index]
        {
            get
            {
                return grids[index];
            }
        }

        public Grids(int x, int y, int num)
        {
            grids = new List<Grid>();

            turn = 1;
            gapeX = 0;
            gapeY = 0;

            for(int i = 0; i < num; i++)
            {
                
                int random = RandomHelper.r.Next(1, 101);

               
                if (random < 86 || i == 0 || i == num - 1)
                {
                    grids.Add(new Grid(x, y, EGridType.Normal));
                }
                else if(random >85 && random < 91)
                {
                    grids.Add(new Grid(x, y, EGridType.Pause));
                }
                else if(random > 90 && random < 96)
                {
                    grids.Add(new Grid(x, y, EGridType.Bomb));
                }
                else if(random > 95 && random < 101)
                {
                    grids.Add(new Grid(x, y, EGridType.Tunnel));
                }

                if (gapeX == 20)
                {
                    y++;
                    gapeY++;
                    if(gapeY == 2)
                    {
                        gapeX = 0;
                        gapeY = 0;
                        turn = -turn;
                    }
                }
                else
                {
                    x = x + (2 * turn);
                    gapeX++;
                }
                

            }

            
        }

        public void DrawGrids()
        {
            for(int i = 0; i < grids.Count; i++)
            {
                if (grids[i] != null)
                {
                    grids[i].Draw();
                }
            }
        }
    }
}
