namespace GPTAttributeClass004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            题目：技能标签系统

            背景：

            一个技能可以拥有多个标签。

            例如：

            FireBall

            同时拥有：

            Fire
            Magic
            AOE

            要求：

            1. 创建 SkillTagAttribute
            2. 继承 Attribute
            3. 只能修饰 Class
            4. 设置 AllowMultiple = true
            5. 创建 FireBall 类
            6. 给 FireBall 添加三个 [SkillTag]
            7. Main 保持为空

            命名：

            SkillTagAttribute
            FireBall

            学习目标：

            掌握 AllowMultiple 的作用。
            */
        }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class SkillTagAttribute : Attribute
    {

    }

    [SkillTag]
    [SkillTag]
    [SkillTag]
    class FireBall
    {

    }
}
