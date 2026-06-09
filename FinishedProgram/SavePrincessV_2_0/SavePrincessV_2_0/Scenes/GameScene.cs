using SavePrincessV_2_0.Core;
using SavePrincessV_2_0.GameObjects;
using SavePrincessV_2_0.Polymer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.Scenes
{
    public class GameScene : IScene
    {
        int width;
        int height;
        Maps maps;
        Player player;
        Position oldPos;
        Role boss;
        Princess princess;
        BattleSystem battleSystem;
        bool isFight;
        BattleReport? battleReport;
        string endStateTitle;
        public GameScene(int width, int height)
        {
            this.width = width;
            this.height = height;
            maps = new Maps(width, height);
            player = new Player("●", ConsoleColor.Yellow, width / 2, height - 30, 100, 16, 23, "玩家");
            boss = new Role("◎", ConsoleColor.Red, width / 2, height - 12, 120, 12, 20, "Boss");
            princess = new Princess("●", ConsoleColor.Green, width - 6, height - 12);
            battleSystem = new BattleSystem(width, height);
            isFight = false;
            oldPos = new Position(player.Pos.X, player.Pos.Y);
            endStateTitle = " ";
        }

        public void Enter()
        {
            Console.Clear(); //进场景先清理屏幕
            maps.Draw();
            player.Draw();
            boss.Draw();
        }

        public IScene? Update()
        {
            ShowPlayerHP(player);
            ConsoleKey key = Console.ReadKey(true).Key;
            if (isFight)
            {
                //战斗状态
                OnFight();
                if (battleReport?.battleResult == EBattleResult.Role2Win) return new EndScene(width, height, "游戏结束", endStateTitle, battleReport.battleResult);
                
                ShowEnemyHP(boss);
                if(battleReport != null && isFight)
                {
                    PrintLog("正在战斗！按任意键继续回合！",
                        $"第{battleReport.roundCount}回合",
                        $"{player.Name}攻击了{boss.Name}，造成{battleReport.role1Damage}点伤害。",
                        $"{boss.Name}攻击了{player.Name}，造成{battleReport.role2Damage}点伤害。", player, boss);
                }
                
            }
            else
            {
                //非战斗状态
                //当boss存活，玩家在boss周围且按下J键，进入战斗
                if(!boss.IsDead && player.Pos.IsAround(boss.Pos) && key == ConsoleKey.J)
                {
                    isFight = true;
                    ShowEnemyHP(boss);//显示boss血量
                    PrintLog("开始战斗！按任意键继续战斗！");
                    return null; //跳过剩下的代码
                }
                //检查是否在公主身边且Boss死亡，即可拯救公主
                else if(boss.IsDead && player.Pos.IsAround(princess.Pos) && key == ConsoleKey.J)
                {
                    if(battleReport != null)
                    {
                        return new EndScene(width, height, "游戏结束", endStateTitle, battleReport.battleResult);
                    }
                }
                    PlayerMove(key);
            }
            return null;
        }

        /// <summary>
        /// 玩家移动
        /// </summary>
        /// <param name="key">输入按键</param>
        private void PlayerMove(ConsoleKey key)
        {
            #region Player Moving
            oldPos.RenewPos(player.Pos);
            Console.SetCursorPosition(oldPos.X, oldPos.Y);
            Console.Write("  ");
            player.Move(key, boss.Pos, width, height, boss.IsDead);
            player.Draw();
            #endregion
        }

        /// <summary>
        /// 战斗中
        /// </summary>
        private void OnFight()
        {
            battleReport = battleSystem.ExecuteRound(player, boss);
            switch (battleReport.battleResult)
            {
                case EBattleResult.Continue:
                    //继续战斗
                    ShowEnemyHP(boss);//显示boss血量
                    break;
                case EBattleResult.Role1Win:
                    ClearLog();
                    ShowEnemyHP(boss);
                    PrintLog("战斗结束！", $"{player.Name}胜利，走到公主身边按J键拯救公主！");
                    princess.Draw();
                    endStateTitle = "英雄救美";
                    isFight = false;
                    break;
                case EBattleResult.Role2Win:
                    ClearLog();
                    isFight = false;
                    PrintLog("战斗结束！", $"{player.Name}失败！");
                    endStateTitle = "惨遭屠戮";
                    Console.ReadKey(true);
                    break;
            }
            if (!isFight && boss.IsDead)
            {
                Console.ReadKey(true); //等待输入，以便让玩家查看信息，按下后将清除boss尸体
                Console.SetCursorPosition(boss.Pos.X, boss.Pos.Y);
                Console.Write("  ");
                ClearEnemyHPDisplay();
            }
        }

        /// <summary>
        ///擦除日志区
        /// </summary>
        private void ClearLog()
        {
            Console.SetCursorPosition(2, height - 8);
            Console.Write(new string(' ', width - 4));
            Console.SetCursorPosition(2, height - 7);
            Console.Write(new string(' ', width - 4));
            Console.SetCursorPosition(2, height - 6);
            Console.Write(new string(' ', width - 4));
            Console.SetCursorPosition(2, height - 5);
            Console.Write(new string(' ', width - 4));
        }

        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <param name="str4"></param>
        private void PrintLog(string str1 = " ", string str2 = " ", string str3 = " ", string str4 = " ",Role? r1 = null, Role? r2 = null)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, height - 8);
            Console.Write(str1);
            Console.SetCursorPosition(2, height - 7);
            Console.Write(str2);
            Console.SetCursorPosition(2, height - 6);
            if (r1 != null) Console.ForegroundColor = r1.Color;
            Console.Write(str3);
            Console.SetCursorPosition(2, height - 5);
            if (r2 != null) Console.ForegroundColor = r2.Color;
            Console.Write(str4);
        }

        /// <summary>
        /// 进入战斗后显示敌人血量
        /// </summary>
        private void ShowEnemyHP(Role enemy)
        {
            Console.SetCursorPosition(width - 16, height - 9);
            Console.Write("              ");
            Console.SetCursorPosition(width - 16, height - 9);
            Console.ForegroundColor = enemy.Color;
            Console.Write($"{boss.Name}血量:{enemy.HP}");
        }

        /// <summary>
        /// 清除敌人血量显示
        /// </summary>
        public void ClearEnemyHPDisplay()
        {
            Console.SetCursorPosition(width - 16, height - 9);
            Console.Write("              ");
        }

        /// <summary>
        /// 玩家血量（全局显示）
        /// </summary>
        /// <param name="player"></param>
        private void ShowPlayerHP(Role player)
        {
            Console.SetCursorPosition(2, height - 9);
            Console.Write("              ");
            Console.SetCursorPosition(2, height - 9);
            Console.ForegroundColor = player.Color;
            Console.Write($"{player.Name}血量:{player.HP}");
        }
    }
}
