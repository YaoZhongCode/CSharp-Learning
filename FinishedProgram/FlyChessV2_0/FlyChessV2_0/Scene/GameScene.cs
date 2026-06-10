using FlyChessV2_0.Core;
using FlyChessV2_0.GameObjects;
using FlyChessV2_0.Polymer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Scene
{
    internal class GameScene : IScene
    {
        private Walls walls;
        private Grids grids;
        private int mapSize;
        private Role player;
        private Role computer;
        private int currentTurn;
        private RoleController controller;

        public GameScene()
        {
            currentTurn = 1;
            mapSize = 219;
            player = new Role(0, 0, 0, ERoleType.Player, "玩家");
            computer = new Role(0, 0, 0, ERoleType.Computer, "电脑");
            walls = new Walls();
            grids = new Grids(10, 3, mapSize);
            controller = new RoleController();
            player.SetPosition(grids[player.NowIndex].Pos);
            computer.SetPosition(grids[computer.NowIndex].Pos);
        }

        
        public void Enter()
        {
            Console.Clear();
            Console.SetCursorPosition(2, GameConfig.height / 2 + 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("按下任意键开始游戏...");

            grids.DrawGrids();
            walls.Draw();

            GridDescription();
            grids.DrawGrids();
            if (player.Pos.Equals(computer.Pos))
            {
                Console.SetCursorPosition(player.Pos.X, player.Pos.Y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("◎");
            }
            else
            {
                player.Draw();
                computer.Draw();
            }
        }

        public IScene? Update()
        {
            MoveReport moveReport;
            Console.ReadKey(true);
            Console.SetCursorPosition(2, GameConfig.height / 2 + 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"第{currentTurn}回合，按任意键继续回合...");

            //局部刷新地图
            player.oldPos = player.NowIndex;
            computer.oldPos = computer.NowIndex;
            grids[player.oldPos].Draw();

            moveReport = controller.Movement(player, grids, mapSize);
            ClearLogArea();
            PrintLog(moveReport, player);
            DrawRole();
            
            Console.ReadKey(true);
            grids[computer.oldPos].Draw();
            moveReport = controller.Movement(computer, grids, mapSize);
            ClearLogArea();
            PrintLog(moveReport, computer);
            DrawRole();
           
            if(controller.CheckEnd(player, grids))
            {
                return new EndScene(true);
            }
            if(controller.CheckEnd(computer, grids))
            {
                return new EndScene(false);
            }
            currentTurn++;
            return null;
        }

        /// <summary>
        /// 格子描述
        /// </summary>
        private void GridDescription()
        {
            Console.SetCursorPosition(2, GameConfig.height / 2 + 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("□：普通格子");

            Console.SetCursorPosition(2, GameConfig.height / 2 + 6);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("‖：暂停，一回合不动");

            Console.SetCursorPosition(2, GameConfig.height / 2 + 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("●：炸弹，随机倒退1-5格");

            Console.SetCursorPosition(2, GameConfig.height / 2 + 8);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("¤：时空隧道，随机前进2-6格");

            Console.SetCursorPosition(2, GameConfig.height / 2 + 9);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("☆：玩家");

            Console.SetCursorPosition(2, GameConfig.height / 2 + 10);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("▲：电脑");

            Console.SetCursorPosition(2, GameConfig.height / 2 + 11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("◎：玩家电脑重合");
        }

        private void PrintLog(MoveReport moveReport, Role role)
        {
            Console.SetCursorPosition(2, GameConfig.height / 2 + 14);
            Console.ForegroundColor = role.Color;
            Console.Write($"{role.Name}的回合！");
            if (moveReport.isPaused)
            {
                Console.SetCursorPosition(2, GameConfig.height / 2 + 15);
                Console.Write("当前处于暂停回合，无法掷骰子！");
            }
            else
            {
                if (moveReport.massage != null)
                {
                    int heightLine = 15;
                    for (int i = 0; i < moveReport.massage.Count; i++)
                    {
                        Console.SetCursorPosition(2, GameConfig.height / 2 + heightLine);
                        Console.Write(moveReport.massage.Dequeue());
                        heightLine++;
                    }
                }
            }
        }

        private void DrawRole()
        {
            if (player.Pos.Equals(computer.Pos))
            {
                //如果玩家和电脑位置重合，画这个符号
                Console.SetCursorPosition(player.Pos.X, player.Pos.Y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("◎");
            }
            else
            {
                //否则让他们自己画自己
                player.Draw();
                computer.Draw();
            }
        }

        private void ClearLogArea()
        {
            int heightLine = 14;
            for(int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(2, GameConfig.height / 2 + heightLine);
                Console.Write(new string(' ', 56));
                heightLine++;
            }
        }

        
    }
}
