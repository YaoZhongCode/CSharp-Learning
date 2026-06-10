using FlyChessV2_0.Core;
using FlyChessV2_0.Polymer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.GameObjects
{
    enum ERoleType
    {
        Player,
        Computer
    }

    internal class Role : GameObject
    {
        private string name;
        public string Name => name;

        //记录在地图的位置索引
        private int nowIndex;
        public int NowIndex => nowIndex;

        //是否暂停
        private bool isPaused;
        public bool IsPaused => isPaused;

        //记录上一个位置索引，局部擦除用
        public int oldPos;
        private ERoleType roleType;

        public Role(int x, int y, int nowIndex, ERoleType roleType, string name) : base(x, y)
        {
            this.name = name;
            this.nowIndex = nowIndex;
            this.roleType = roleType;
            isPaused = false;
            if(this.roleType == ERoleType.Player)
            {
                icon = "☆";
                color = ConsoleColor.Cyan;
            }
            else
            {
                icon = "▲";
                color = ConsoleColor.Magenta;
            }
        }

        public void Move(int step, int maxIndex)
        {
            nowIndex += step;

            //防止溢出
            if (nowIndex < 0) nowIndex = 0;
            if (nowIndex > maxIndex) nowIndex = maxIndex; 
        }

        public string ApplyGridEffect(EGridType type, int maxIndex)
        {
            string description = " ";
            int step;
            switch (type)
            {
                case EGridType.Normal:
                    //什么都不做
                    description = "什么都没发生！";
                    break;
                case EGridType.Pause:
                    //暂停一回合
                    isPaused = true;
                    description = "触发暂停一回合！";
                    break;
                case EGridType.Bomb:
                    //随机倒退1-5格
                    step = RandomHelper.r.Next(1, 6);
                    description = $"触发倒退{step}格！";
                    nowIndex -= step;
                    if (nowIndex < 0) nowIndex = 0;
                    break;
                case EGridType.Tunnel:
                    //随机前进2-6格
                    step = RandomHelper.r.Next(2, 7);
                    description = $"触发前进{step}格！";
                    nowIndex += step;
                    if (nowIndex > maxIndex) nowIndex = maxIndex;
                    break;
            }
            return description;
        }


        public void SetPosition(Position pos)
        {
            this.pos = pos;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.ForegroundColor = color;
            Console.Write(icon);
        }

        /// <summary>
        /// 尝试暂停
        /// </summary>
        /// <returns></returns>
        public bool TryConsumePause()
        {
            if (isPaused)
            {
                isPaused = false;
                return true; //表示本回合应该跳过
            }

            return false;
        }
    }
}
