namespace GPTAttributeClass007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            题目：读取怪物种族

            背景：

            游戏启动时需要读取怪物配置。

            每个怪物类通过特性记录自己的种族。

            要求：

            1. 创建一个只能修饰类的特性
            2. 特性内部保存一个字符串信息
            3. 创建 Zombie 类并配置种族
            4. Main 中获取 Zombie 的 Type
            5. 使用 GetCustomAttributes(false)
            6. 从返回结果中取出第一个特性对象
            7. 强制转换回原来的特性类型
            8. 输出保存的字符串信息

            学习目标：

            理解 object -> MonsterTypeAttribute 的类型转换过程
            */

            Type type = typeof(Zombie);
            object[] attributes = type.GetCustomAttributes(false);
            MonsterAttribute mab = (MonsterAttribute)attributes[0];
            Console.WriteLine(mab.TypeName);
        }
    }

    //只能修饰类的特性
    [AttributeUsage(AttributeTargets.Class)]
    public class MonsterAttribute : Attribute
    {
        public string TypeName;
        public MonsterAttribute(string name)
        {
            TypeName = name;
        }
    }

    [Monster("Undead")]
    public class Zombie
    {

    }
}
