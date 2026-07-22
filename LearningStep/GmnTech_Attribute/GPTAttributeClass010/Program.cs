using System.Reflection;

namespace GPTAttributeClass010
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            题目：简化读取怪物特性

            背景：

            为了让代码更简洁，项目决定不再使用
            GetCustomAttributes()。

            要求：

            1. 创建一个只能修饰类的怪物特性。
            2. 特性中保存一个字符串信息。
            3. 创建 Zombie 类并配置该特性。
            4. 使用 GetCustomAttribute<T>() 获取特性。
            5. 判断返回值是否为空。
            6. 输出保存的字符串信息。

            学习目标：

            掌握项目中最常见的特性读取方式。
            */

            Type type = typeof(Zombie);
            MonsterAttribute? attribute = type.GetCustomAttribute<MonsterAttribute>();
            if (attribute != null) Console.WriteLine(attribute.TypeName);

        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class MonsterAttribute : Attribute
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
