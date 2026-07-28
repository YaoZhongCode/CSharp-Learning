using System.Collections;

namespace GmnClass004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【小练习 2.1】：使用 yield return 实现技能多段释放序列
            【背景模拟】：
            在 Unity 动作游戏中，玩家释放三段斩技能（Combo）。
            你需要编写一个技能序列生成方法，按顺序返回每一段技能的伤害数值（如 100, 150, 300）。
            要求使用 yield return 来控制多段技能的逐步释放逻辑。

            【具体要求】：

            创建一个名为 SkillComboManager 的类。

            在类中编写一个名为 GetComboDamageSequence 的方法，返回值类型为 IEnumerator。

            方法内部：

            逐次使用 yield return 返回第一段伤害 100、第二段伤害 150、第三段伤害 300（整数即可）。

            在第三段伤害返回后，使用 yield break 显式终止序列。

            在 Main 方法中：

            实例化 SkillComboManager。

            调用 GetComboDamageSequence() 获取 IEnumerator 接口实例（注意：直接用 IEnumerator 接收，不要强转！）。

            使用 while 循环配合 MoveNext() 与 Current，逐个将每段伤害数值打印到控制台。

            【变量/方法命名规范】：

            类名：SkillComboManager

            方法名：GetComboDamageSequence

            Main 中变量名：comboManager、sequence

            请在下方回复你编写的代码。检查得分 60 分以上方可进入下一个知识点。
            */
            SkillComboManager comboManager = new SkillComboManager();
            IEnumerator sequence = comboManager.GetComboDamageSequence();
            while (sequence.MoveNext())
            {
                Console.WriteLine($"伤害值：{sequence.Current}");
            }
        }
    }
    public class SkillComboManager
    {
        public IEnumerator GetComboDamageSequence()
        {
            yield return 100;
            yield return 150;
            yield return 300;
            yield break;
        }
    }

}
