using SavePrincessV_2_0.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.Core
{
    /// <summary>
    /// 战斗结果
    /// </summary>
    public enum EBattleResult
    {
        Role1Win,
        Role2Win,
        Continue
    }

    /// <summary>
    /// 战斗数据包
    /// </summary>
    internal class BattleReport
    {
        public int role1Damage;
        public int role2Damage;
        public EBattleResult battleResult;
        public int roundCount;
    }

    internal class BattleSystem
    {
        private int roundCount;
        int width, height;
        public BattleSystem(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public BattleReport ExecuteRound(Role r1, Role r2)
        {
            BattleReport battleReport = new BattleReport(); ;
            //角色1攻击角色2
            if (!r1.IsDead)
            {
                battleReport.role1Damage = r1.GetRandomAttack();
                r2.TakeDamage(battleReport.role1Damage);
            }
            else
            {
                battleReport.battleResult = EBattleResult.Role2Win;
                return battleReport;
            }
            //角色2攻击角色1
            if (!r2.IsDead)
            {
                battleReport.role2Damage = r2.GetRandomAttack();
                r1.TakeDamage(battleReport.role2Damage);
            }
            else
            {
                battleReport.battleResult = EBattleResult.Role1Win;
                return battleReport;
            }
            battleReport.battleResult = EBattleResult.Continue;
            roundCount++;
            battleReport.roundCount = roundCount;
            return battleReport;
        }
    }
}
