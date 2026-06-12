namespace GPTAttributeClass002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            题目：怪物标记系统

            背景模拟：

            你正在开发一个 RPG 游戏。

            策划要求：

            只有怪物类才能被打上 Monster 特性。

            字段、属性、方法都不允许使用。

            具体要求：

            1.
            创建 MonsterAttribute

            2.
            MonsterAttribute 必须继承 Attribute

            3.
            使用 AttributeUsage 限制：

            只能修饰 Class

            4.
            创建：

            Slime
            Dragon

            两个类

            并正确使用：

            [Monster]

            5.
            Main 中不需要任何逻辑

            只要成功编译即可

            命名规范：

            MonsterAttribute
            Slime
            Dragon

            学习目标：

            掌握 AttributeUsage 的基本用途。
            */

        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    class MonsterAttribute : Attribute
    {

    }

    [Monster]
    class Slime
    {

    }

    [Monster]
    class Dragon
    {

    }
}
