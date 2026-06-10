namespace AttributeClass001
{
    public class DungeonRegionAttribute : Attribute
    {
        public string Description { get; }

        public DungeonRegionAttribute(string description)
        {
            Description = description;
        }
    }

    [DungeonRegion("黑暗森林")]
    public class DungeonArea
    {
        public void OnPlayerEnter()
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ===================================================================
            背景模拟：
            你正在开发一款文字冒险游戏的副本（Dungeon）系统。需要设计一套标签，
            用来标记哪些类是“副本区域”，哪些方法是“副本触发事件”。

            具体要求：
            1. 声明一个自定义特性类，用于标记副本区域，类名必须严格符合官方命名规范。
               - 该特性包含一个构造函数，接收一个 string 类型的副本描述信息（Description）。
            2. 声明一个副本类（DungeonArea）。
               - 将上述声明的副本区域特性挂载到该类上，传入描述内容为 "黑暗森林"。
            3. 在 DungeonArea 类中声明一个无参、无返回值的方法，方法名为 OnPlayerEnter。
               - 暂时不需要编写具体的业务逻辑，方法体留空或输出一句提示即可。

            变量/方法命名规范：
            - 特性类名：DungeonRegionAttribute
            - 特性中的只读属性：Description
            - 副本类名：DungeonArea
            - 副本类中的触发方法：OnPlayerEnter
            ===================================================================
            */
            Console.WriteLine("副本区域特性挂载成功");

        }
    }
}
