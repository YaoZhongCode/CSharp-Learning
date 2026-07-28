namespace GmnClass007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ================================================================
            【小练习 3.2】：使用 IEnumerable<T> 方法配合 foreach（一键复制）
            ================================================================

            【背景模拟】：
            在财务或游戏数值统计模块中，需要提供一个获取过滤后数据流的方法。
            为了让调用方的代码最简洁，方法需要返回 IEnumerable<T>，使外部可以直接通过 foreach 遍历。

            【具体要求】：
            1. 创建类 RewardStreamProcessor。
            2. 编写方法 GetBonusGoldSequence()，返回类型为 IEnumerable<int>。
               - 方法内部依次 yield return 奖励金币数：100, 250, 500。
            3. 在 Main 方法中：
               - 实例化 RewardStreamProcessor。
               - 直接使用 foreach 循环遍历 processor.GetBonusGoldSequence()。
               - 在 foreach 循环内部，将每次获取到的金币数逐行打印到控制台。

            【变量/方法命名规范】：
            - 类名：RewardStreamProcessor
            - 方法名：GetBonusGoldSequence
            - Main 中变量名：processor、gold

            请在下方回复你编写的代码。检查得分 60 分以上方可进入下一个知识点。
            ================================================================
            */
            RewardStreamProcessor processor = new RewardStreamProcessor();
            foreach(var gold in processor.GetBonusGoldSequence())
            {
                Console.WriteLine(gold);
            }
        }
    }

    public class RewardStreamProcessor
    {
        public IEnumerable<int> GetBonusGoldSequence()
        {
            yield return 100;
            yield return 250;
            yield return 500;
        }

    }
}
