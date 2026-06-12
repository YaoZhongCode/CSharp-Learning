namespace GPTAttributeClass003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /************************************************

            题目：存档标记系统 V2

            背景模拟：

            你正在开发 RPG 存档系统。

            策划要求：

            SaveData 特性只能用于：

            字段(Field)
            属性(Property)

            方法(Method)
            类(Class)

            全部禁止。

            具体要求：

            1.

            创建：

            SaveDataAttribute

            2.

            继承：

            Attribute

            3.

            使用 AttributeUsage

            4.

            允许：

            AttributeTargets.Field
            AttributeTargets.Property

            同时存在

            5.

            创建 Player 类

            6.

            Player 中创建：

            字段：

            Level

            属性：

            HP

            7.

            分别给它们添加：

            [SaveData]

            8.

            不要创建任何方法

            9.

            Main 保持为空

            命名规范：

            SaveDataAttribute
            Player
            Level
            HP

            学习目标：

            掌握 Flags 枚举在 AttributeTargets 中的组合写法。

            ************************************************/


        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    class SaveDataAttribute: Attribute
    {

    }

    class Player
    {
        [SaveData]
        public int Level = 1;
        [SaveData]
        public int HP { get; set; }
    }
}
