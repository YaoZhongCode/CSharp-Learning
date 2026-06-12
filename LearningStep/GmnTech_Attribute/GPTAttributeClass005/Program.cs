namespace GPTAttributeClass005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            题目：怪物类型标签

            背景：

            游戏中的怪物需要记录所属种族。

            例如：

            Undead（亡灵）
            Dragon（龙族）
            Beast（野兽）

            要求：

            1. 创建 MonsterTypeAttribute
            2. 继承 Attribute
            3. 只能修饰 Class
            4. 创建字段：

            TypeName

            类型：

            string

            5. 创建构造函数：

            MonsterTypeAttribute(string typeName)

            6. 构造函数中保存数据到 TypeName

            7. 创建三个类：

            Zombie
            DragonBoss
            Wolf

            8. 分别使用：

            [MonsterType("Undead")]
            [MonsterType("Dragon")]
            [MonsterType("Beast")]

            9. Main 保持为空

            命名：

            MonsterTypeAttribute
            TypeName
            Zombie
            DragonBoss
            Wolf

            学习目标：

            理解特性构造函数参数本质上是在创建特性对象时传参。
            */
        }
    }
    [AttributeUsage(AttributeTargets.Class)] //限制为仅能挂载在类上面
    class MonsterTypeAttribute : Attribute
    {

        public string TypeName { get; private set; }
        public MonsterTypeAttribute(string typeName)
        {
            TypeName = typeName;
        }
    }
    [MonsterType("Undead")]
    class Zombie
    {

    }
    [MonsterType("Dragon")]
    class DragonBoss
    {

    }
    [MonsterType("Beast")]
    class Wolf
    {

    }
}
