using System.Text.Json.Serialization;

namespace GPTAttributeClass001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            题目：寻找特性的祖先

            背景模拟：

            你正在开发一个 RPG 游戏编辑器。

            为了研究 Unity 和 .NET 内置特性的本质，
            你决定验证几个常见特性是否都继承自 Attribute。

            具体要求：

            1.
            使用 typeof 获取以下三个类型：

            ObsoleteAttribute
            SerializableAttribute
            FlagsAttribute

            2.
            分别输出它们的 BaseType.Name

            3.
            输出格式自由

            4.
            禁止直接写死字符串

            必须通过反射获取

            变量命名规范：

            type1
            type2
            type3

            学习目标：

            彻底确认：

            所有特性的共同祖先都是 Attribute
            */
            Type type1 = typeof(ObsoleteAttribute);
            Type type2 = typeof(SerializableAttribute); 
            Type type3 = typeof(FlagsAttribute);
            Console.WriteLine($"type1 = {type1?.BaseType?.Name}");
            Console.WriteLine($"type2 = {type2?.BaseType?.Name}");
            Console.WriteLine($"type3 = {type3?.BaseType?.Name}");
        }
    }
}
