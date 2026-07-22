namespace GPTAttributeClass009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            题目：安全读取怪物特性

            背景：

            游戏启动时，需要读取怪物配置。

            为了避免程序因为类型转换失败而崩溃，
            决定使用安全转换方式读取特性。

            要求：

            1. 创建一个只能修饰类的怪物特性。
            2. 特性中保存一个字符串信息。
            3. 创建 Zombie 类并配置该特性。
            4. 使用反射获取 Zombie 身上的特性对象。
            5. 使用 as 完成类型转换。
            6. 判断转换结果是否为空。
            7. 转换成功后输出保存的字符串信息。

            学习目标：

            掌握 as 的安全转换方式，并理解它与强制转换的区别。
            */
            Type type = typeof(Zombie);
            object[] attributes = type.GetCustomAttributes(false);

            MonsterAttribute? attribute = attributes[0] as MonsterAttribute;
            if(attribute != null)
            {
                Console.WriteLine(attribute.TypeName);
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class MonsterAttribute: Attribute
    {
        public string TypeName { get; }
        public MonsterAttribute(string typeName)
        {
            TypeName = typeName;
        }
    }

    [Monster("Undead")]
    public class Zombie
    {

    }
}
