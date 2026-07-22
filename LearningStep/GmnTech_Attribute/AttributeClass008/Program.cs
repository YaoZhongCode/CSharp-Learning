using System.Reflection;

namespace AttributeClass008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ===================================================================
            背景模拟：
            你在开发一个自动化测试框架（AutoTestRunner）。框架启动时，需要扫描
            程序集中所有挂载了“测试用例”标签的方法，并自动实例化类并执行该测试方法。

            具体要求：
            1. 声明一个自定义测试用例特性类，类名必须严格符合命名规范。
               - 使用 [AttributeUsage] 限制其【只能】挂载到方法（Method）上。
               - 构造函数接收一个 string 类型的测试用例描述（TestCaseName）。
               - 包含一个只读属性存储该描述（名称必须严格为 TestCaseName）。
            2. 声明两个测试类：
               - PlayerTests：
                 包含无参方法 TestPlayerHp()，挂载特性传入 "测试玩家血量上限"。
                 方法体内打印："执行：血量上限测试通过"。
               - ItemTests：
                 包含无参方法 TestUseItem()，挂载特性传入 "测试道具使用逻辑"。
                 方法体内打印："执行：道具使用测试通过"。
            3. 在 Main 方法中：
               - 获取当前程序集 `Assembly.GetExecutingAssembly()` 并提取所有 `Type[]`。
               - 使用双层遍历（外层遍历 Type，内层遍历 MethodInfo）。
                 获取 MethodInfo 时，需使用 `t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)`。
               - 当检测到方法上挂载了测试特性时：
                 a) 在控制台打印："开始测试用例：[TestCaseName] (方法: [Type.Name].[MethodInfo.Name])"
                 b) 使用 `Activator.CreateInstance(t)` 动态创建该类的实例。
                 c) 使用 `method.Invoke(instance, null)` 执行该测试方法。

            变量/方法命名规范：
            - 特性类名：TestCaseAttribute
            - 特性中的只读属性：TestCaseName
            - 目标测试类名：PlayerTests, ItemTests
            - 测试方法名：TestPlayerHp, TestUseItem
            ===================================================================
            */
            Assembly a = Assembly.GetExecutingAssembly();
            Type[] types = a.GetTypes();

            foreach (var t in types)
            {
                MethodInfo[]? methods = t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (methods == null) return;
                foreach (var m in methods)
                {
                    Attribute? attribute = Attribute.GetCustomAttribute(m, typeof(TestCaseAttribute));
                    if (attribute != null && attribute is TestCaseAttribute testArrt)
                    {
                        Console.WriteLine($"开始测试用例：[{testArrt.TestCaseName}] (方法: {t.Name}.{m.Name})");
                        object? obj = Activator.CreateInstance(t);
                        m.Invoke(obj, null);
                    }
                }


            }
        }
        [AttributeUsage(AttributeTargets.Method)]
        public class TestCaseAttribute : Attribute
        {
            public string TestCaseName { get; }
            public TestCaseAttribute(string testCaseName)
            {
                TestCaseName = testCaseName;
            }
        }
        public class PlayerTests
        {
            [TestCase("测试玩家血量上限")]
            public void TestPlayerHp()
            {
                Console.WriteLine("执行：血量上限测试通过");
            }
        }

        public class ItemTests
        {
            [TestCase("测试道具使用逻辑")]
            public void TestUseItem()
            {
                Console.WriteLine("执行：道具使用测试通过");
            }
        }



    }
}
