using SavePrincessV_2_0.Core;
using SavePrincessV_2_0.Scenes;
using SavePrincessV_2_0.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.GameObjects
{
    /// <summary>
    /// 只定义一个角色类就行，到时实例化直接给不同的名字就可以生成玩家和boss
    /// </summary>
    internal class Role : GameObject
    {
        protected string name;
        public string Name => name;
        public ConsoleColor Color => color;
        protected int hp;
        public int HP => hp;
        protected int minAtk;
        protected int maxAtk;
        protected bool isDead;
        public bool IsDead { get { return isDead; } }
        public Role(string icon, ConsoleColor color, int x, int y,int HP, int minAtk, int maxAtk, string name) : base(icon, color, x, y)
        {
            this.name = name;
            this.hp = HP;
            this.minAtk = minAtk;
            this.maxAtk = maxAtk;
            isDead = false;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.ForegroundColor = color;
            Console.Write(icon);
        }

        /// <summary>
        /// 受伤逻辑
        /// </summary>
        /// <param name="damage">伤害量</param>
        public void TakeDamage(int damage)
        {
            hp -= damage;
            //受伤后立即检查是否死亡
            if (HP <= 0)
            {
                hp = 0;
                isDead = true;
            }
        }

        /// <summary>
        /// 随机攻击力
        /// </summary>
        /// <returns></returns>
        public int GetRandomAttack()
        {
            return RandomHelper.Next(minAtk, maxAtk);
        }
    }
}
