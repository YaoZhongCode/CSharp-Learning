using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.GameObjects
{
    /// <summary>
    /// 格子类型
    /// </summary>
    enum EGridType
    {
        Normal,
        Pause,
        Bomb,
        Tunnel
    }

    internal class Grid : GameObject
    {
        private EGridType gridType;
        public EGridType GridType => gridType;

        public Grid(int x, int y, EGridType gridType) : base(x, y)
        {
            this.gridType = gridType;
            switch (gridType)
            {
                case EGridType.Normal:
                    icon = "□";
                    color = ConsoleColor.White;
                    break;
                case EGridType.Pause:
                    icon = "‖";
                    color = ConsoleColor.Blue;
                    break;
                case EGridType.Bomb:
                    icon = "●";
                    color = ConsoleColor.Red;
                    break;
                case EGridType.Tunnel:
                    icon = "¤";
                    color = ConsoleColor.Yellow;
                    break;
            }
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.ForegroundColor = color;
            Console.Write(icon);
        }

        public string GetGridTypeName()
        {
            string temp = " ";
            switch (GridType)
            {
                case EGridType.Normal:
                    temp = "普通";
                    break;
                case EGridType.Pause:
                    temp = "暂停";
                    break;
                case EGridType.Bomb:
                    temp = "炸弹";
                    break;
                case EGridType.Tunnel:
                    temp = "时空隧道";
                    break;
            }
            return temp;
        }
    }
}
