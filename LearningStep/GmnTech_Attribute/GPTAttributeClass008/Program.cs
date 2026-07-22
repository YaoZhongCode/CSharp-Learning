namespace GPTAttributeClass008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            题目：怪物身份检查

            背景：

            游戏运行时获得了一个 object 对象。

            需要先判断它是不是 MonsterAttribute，
            只有确认后，后续才允许进行转换。

            要求：

            1. 创建一个继承 Attribute 的怪物特性。
            2. 创建一个挂载该特性的 Zombie 类。
            3. 通过反射获取 Zombie 身上的第一个特性对象。
            4. 使用 is 判断该对象是否为 MonsterAttribute。
            5. 输出判断结果(True 或 False)。

            学习目标：

            理解为什么大型项目中，类型转换前要先进行类型判断。
            */
            Type type = typeof(Zombie);
            object[] attributes = type.GetCustomAttributes(false);
            Console.WriteLine("是否是怪物特性：" + (attributes[0] is MonsterAttribute));

        }
    }

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
