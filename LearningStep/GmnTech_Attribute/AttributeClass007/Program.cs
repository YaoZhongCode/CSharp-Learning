using System.Reflection;

namespace AttributeClass007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ===================================================================
            背景模拟：
            你在为游戏开发一个模块初始化器（ModuleInitializer）。游戏启动时，
            需要自动扫描程序集中所有被标记为“游戏模块”的类，并将它们的模块名称打印出来。

            具体要求：
            1. 声明一个自定义模块特性类，类名必须严格符合命名规范。
               - 使用 [AttributeUsage] 限制其【只能】挂载到类（Class）上。
               - 构造函数接收一个 string 类型的模块名称（ModuleName）。
               - 包含一个只读属性存储该模块名称。
            2. 声明三个类：
               - GameModuleA：挂载该特性，传入 "UiModule"
               - GameModuleB：挂载该特性，传入 "AudioModule"
               - UnusedModule：不挂载任何特性
            3. 在 Main 方法中：
               - 使用 Assembly.GetExecutingAssembly() 获取当前程序集。
               - 调用 GetTypes() 获取所有 Type 数组。
               - 遍历该数组，获取每个 Type 上挂载的该模块特性。
               - 若提取成功，在控制台打印出：
                 "成功注册游戏模块：[ModuleName] (类名: [Type.Name])"

            变量/方法命名规范：
            - 特性类名：GameModuleAttribute
            - 特性中的只读属性：ModuleName
            - 目标类名：GameModuleA, GameModuleB, UnusedModule
            ===================================================================
            */
            Assembly a = Assembly.GetExecutingAssembly();
            Type[] types = a.GetTypes();
            if (types == null) return;
            foreach(var t in types)
            {
                Attribute? attribute = Attribute.GetCustomAttribute(t, typeof(GameModuleAttribute));
                if(attribute != null && attribute is GameModuleAttribute gameAttr)
                {
                    Console.WriteLine($"成功注册游戏模块：[{gameAttr.ModuleName}](类名: [{t.Name}])");
                }
            }

        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class GameModuleAttribute : Attribute
    {
        public string ModuleName { get; }
        public GameModuleAttribute(string moduleName)
        {
            ModuleName = moduleName;
        }
    }
    [GameModule("UiModule")]
    public class GameModuleA
    {
    }
    [GameModule("AudioModule")]
    public class GameModuleB { }

    public class UnusedModule { }
}
