namespace AttributeClass004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ===================================================================
            背景模拟：
            在游戏角色初始化的装备系统中，一个装备类（Equipment）可以同时被打上
            多个标签（如：“史诗”、“可交易”、“绑定”）。

            具体要求：
            1. 声明一个自定义装备标签特性类，类名必须严格符合命名规范。
               - 使用 [AttributeUsage] 限制其【只能】挂载到类（Class）上，
                 且【允许】重复挂载。
               - 构造函数接收一个 string 类型的标签名称（TagName）。
               - 包含一个只读属性存储该标签名称。
            2. 声明一个装备类 DragonShield。
            3. 在 DragonShield 类上方连续挂载两个标签特性：
               - 第一个传入 "Epic"
               - 第二个传入 "Tradable"
            4. 在 Main 方法中：
               - 获取 DragonShield 的 Type。
               - 使用 Attribute.GetCustomAttributes 静态方法获取该类上的所有装备标签特性数组。
               - 对数组进行判空防御检查，遍历数组，并在控制台依次打印出：
                 "装备属性标签：[标签名称]"

            变量/方法命名规范：
            - 特性类名：EquipmentTagAttribute
            - 特性中的只读属性：TagName
            - 目标装备类名：DragonShield
            ===================================================================
            */
            Type type = typeof(DragonShield);
            Attribute[] attributes = Attribute.GetCustomAttributes(type, typeof(EquipmentTagAttribute));
            if(attributes != null && attributes.Length > 0)
            {
                foreach (var a in attributes)
                {
                    if (a is EquipmentTagAttribute tag) Console.WriteLine($"装备属性标签：[{tag.TagName}]");
                }
            }
            else
            {
                Console.WriteLine("装备无标签");
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class EquipmentTagAttribute : Attribute
    {
        public string TagName { get; } 
        public EquipmentTagAttribute(string tagName)
        {
            TagName = tagName;
        }
    }

    [EquipmentTag("Epic")]
    [EquipmentTag("Tradable")]
    public class DragonShield
    {

    }
}
