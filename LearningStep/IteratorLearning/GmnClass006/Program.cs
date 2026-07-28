namespace GmnClass006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ================================================================
            【小练习 3.1】：强类型数据流迭代器（一键复制）
            ================================================================

            【背景模拟】：
            在处理大量数值数据（如玩家伤害列表、商品价格清单）时，为了追求极致性能，
            必须使用泛型迭代器 IEnumerator<T> 避免值类型的装箱与拆箱。

            【具体要求】：
            1. 创建一个类 ValueStreamProcessor。
            2. 在类中编写方法 GetCriticalDamageValues()，返回类型为 IEnumerator<int>。
               - 方法内依次 yield return 强类型整数：500, 1200, 3500。
            3. 在 Main 方法中：
               - 实例化 ValueStreamProcessor。
               - 调用 GetCriticalDamageValues()，直接用 IEnumerator<int> 类型的变量接收。
               - 使用 while 循环配合 MoveNext()，读取 Current 并累加这些伤害值，最后将总伤害打印到控制台。

            【变量/方法命名规范】：
            - 类名：ValueStreamProcessor
            - 方法名：GetCriticalDamageValues
            - Main 中变量名：processor、damageEnumerator、totalDamage

            请在下方回复你编写的代码。检查得分 60 分以上方可进入下一个知识点。
            ================================================================
            */
            ValueStreamProcessor processor = new ValueStreamProcessor();
            IEnumerator<int> damageEnumerator = processor.GetCriticalDamageValues();
            int totalDamage = 0;
            while (damageEnumerator.MoveNext())
            {
                totalDamage += damageEnumerator.Current;
            }
            Console.WriteLine($"总伤害：{totalDamage}");

        }
    }
    public class ValueStreamProcessor
    {
        public IEnumerator<int> GetCriticalDamageValues()
        {
            yield return 500;
            yield return 1200;
            yield return 3500;
        }
    }

}
