namespace GPTClass001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【背景模拟】

            你正在制作一个 RPG 游戏。

            角色背包中存放了若干道具。

            现在需要按顺序把每一个道具输出到控制台。

            【具体要求】

            1. 创建一个字符串数组，表示玩家背包。
            2. 数组中至少放入 5 个道具。
            3. 使用 for 循环依次输出所有道具。
            4. 输出格式统一为：

            当前道具：XXX

            【变量命名规范】

            字符串数组：
            bagItems

            循环变量：
            i
            */

            string[] bagItems = { "恢复药水", "魔瓶", "树枝", "信", "火之盾" };
            for(int i =0; i < bagItems.Length; i++)
            {
                Console.WriteLine($"当前道具：{bagItems[i]}");
            }
        }
    }
}
