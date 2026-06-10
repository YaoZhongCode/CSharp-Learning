using FlyChessV2_0.GameObjects;
using FlyChessV2_0.Polymer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Core
{
    public class MoveReport
    {
        public bool isPaused;
        public Queue<string> massage;

        public MoveReport()
        {
            massage = new Queue<string>();
        }
    }



    internal class RoleController
    {
        private MoveReport? moveReport;
        int count;
        int step;
        int preIndex;
        int maxLoop;

        public RoleController()
        {
            maxLoop = 10;
        }

        /// <summary>
        /// 移动逻辑
        /// </summary>
        /// <param name="role"></param>
        /// <param name="grids"></param>
        /// <param name="mapSize"></param>
        public MoveReport Movement(Role role, Grids grids, int mapSize)
        {
            moveReport = new MoveReport();
            //如果是暂停状态，则跳过一回合
            if (role.TryConsumePause())
            {
                moveReport.isPaused = true;
                return moveReport;
            }
            moveReport.massage = new Queue<string>();
            count = 0;
            //扔骰子，1-6点
            step = RandomHelper.r.Next(1, 7);
            moveReport.massage.Enqueue($"{role.Name}掷出了{step}点骰子点数，移动{step}格。");
            role.Move(step, mapSize - 1);
            do
            {
                preIndex = role.NowIndex;
                Grid grid = grids[role.NowIndex];
                moveReport.massage.Enqueue($"{role.Name}走到了{grid.GetGridTypeName()}格子");
                string description = role.ApplyGridEffect(grid.GridType, mapSize - 1);
                moveReport.massage.Enqueue($"{description}");
                count++;
            } while (role.NowIndex != preIndex && count < maxLoop);
            role.SetPosition(grids[role.NowIndex].Pos);
            return moveReport;
        }

        /// <summary>
        /// 检查胜利
        /// </summary>
        /// <param name="role"></param>
        /// <param name="grids"></param>
        /// <returns></returns>
        public bool CheckEnd(Role role, Grids grids)
        {
            if (role.Pos.Equals(grids[grids.Length - 1].Pos))
            {
                return true;
            }
            return false;
        }
    }
}
