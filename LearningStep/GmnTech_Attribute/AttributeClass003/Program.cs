namespace AttributeClass003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ===================================================================
            背景模拟：
            在游戏技能系统中，一个技能（类）可以触发多种“被动特效”（如：吸血、减速、
            击退）。由于特效会有多个，所以我们允许在同一个技能类上重复挂载多个特效标签。
            但是，这些标签绝对不能错挂在方法或字段上。

            具体要求：
            1. 声明一个自定义特性类，类名必须严格符合命名规范。
               - 使用 [AttributeUsage] 进行严格约束：
                 a) 限制该特性【只能】挂载到类（Class）上。
                 b) 【允许】在同一个类上重复挂载多个该特性。
               - 构造函数接收一个 string 类型的特效名称（EffectName）。
               - 包含一个只读属性存储该特效名称。
            2. 声明一个技能类（FireBlastSkill）。
            3. 在 FireBlastSkill 类上方连续挂载两个该特效特性：
               - 第一个传入 "Vampire" (吸血)
               - 第二个传入 "Slow" (减速)
            4. 本步长暂时不需要写 Main 中的反射读取逻辑，确保语法约束正确，
               并在 Main 方法中打印一条执行完毕的提示。

            变量/方法命名规范：
            - 特性类名：SkillEffectAttribute
            - 特性中的只读属性：EffectName
            - 目标技能类名：FireBlastSkill
            ===================================================================
            */
            Console.WriteLine("编译通过");
        }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =true)]
    public class SkillEffectAttribute : Attribute
    {
        public string EffectName { get; }
        public SkillEffectAttribute(string effectName)
        {
            EffectName = effectName;
        }
    }
    [SkillEffect("Vampire")]
    [SkillEffect("Slow")]
    public class FireBlastSkill
    {

    }
}
