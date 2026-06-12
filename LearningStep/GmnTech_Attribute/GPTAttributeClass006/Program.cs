namespace GPTAttributeClass006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            题目：读取怪物特性

            背景：

            你已经给 Zombie 挂上了怪物种族特性。

            现在需要通过反射统计：

            Zombie 身上总共有多少个特性对象。

            要求：

            1. 创建一个只能修饰类的特性
            2. 特性需要接收一个字符串参数
            3. 创建 Zombie 类并挂载该特性
            4. Main 中通过 typeof 获取 Zombie 的 Type
            5. 使用 GetCustomAttributes(false)
            6. 输出获取到的特性数量

            学习目标：

            第一次通过反射读取特性对象
            */
            Type type = typeof(Zombie);
            object[] attributes = type.GetCustomAttributes(false);
            Console.WriteLine(attributes.Length);

        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    class MonsterTypeAttribute : Attribute
    {
        public string TypeName;
        public MonsterTypeAttribute(string typeName)
        {
            TypeName = typeName;
        }
    }
    [MonsterType("Undead")]
    class Zombie
    {

    }
}
