namespace GmnClass008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ================================================================
            【小练习 3.3】：实现暴击伤害流式过滤器（一键复制）
            ================================================================

            【背景模拟】：
            在战斗伤害统计系统中，需要从一连串的原始伤害数据中，筛选出所有超过“暴击判定阈值”的伤害值进行特殊显示。
            为了保证零内存分配和高性能，必须使用带有参数的 yield return 实现流式过滤。

            【具体要求】：
            1. 创建类 DamageFilterProcessor。
            2. 编写方法 FilterCriticalHits(IEnumerable<int> rawDamages, int criticalThreshold)，返回类型为 IEnumerable<int>。
               - 构造函数/入参防御性检查：若 rawDamages 为 null，抛出 ArgumentNullException。
               - 使用 foreach 结合 if 语句，仅对大于 criticalThreshold 的伤害值进行 yield return。
            3. 在 Main 方法中：
               - 实例化 DamageFilterProcessor。
               - 准备一个包含数据 { 50, 180, 90, 250, 30, 120 } 的 int[] 数组。
               - 调用 FilterCriticalHits，传入数组和阈值 100。
               - 使用 foreach 遍历过滤后的结果，并逐行打印到控制台。

            【变量/方法命名规范】：
            - 类名：DamageFilterProcessor
            - 方法名：FilterCriticalHits
            - Main 中变量名：processor、rawData、criticalDamages

            请在下方回复你编写的代码。检查得分 60 分以上方可进入下一个知识点。
            ================================================================
            */
            DamageFilterProcessor processor = new DamageFilterProcessor();
            int[] rawData = { 50, 180, 90, 250, 30, 120 };

            IEnumerable<int> criticalDamages = processor.FilterCriticalHits(rawData, 100);
            foreach(var c in criticalDamages)
            {
                Console.WriteLine(c);
            }
        }
    }

    public class DamageFilterProcessor
    {
        public IEnumerable<int> FilterCriticalHits(IEnumerable<int> rawDamages, int criticalThreshold)
        {
            if (rawDamages == null) throw new ArgumentNullException(nameof(rawDamages));

            foreach(var d in rawDamages)
            {
                if(d > criticalThreshold)
                {
                    yield return d;
                }
            }
        }
    }
}
