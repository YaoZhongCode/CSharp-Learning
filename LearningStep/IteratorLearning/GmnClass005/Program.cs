using System.Collections;

namespace GmnClass005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ================================================================
            【小练习 2.2】：模拟关卡加载控制权切换（可点击右上角一键复制）
            ================================================================

            【背景模拟】：
            在游戏关卡加载时，需要在异步流程中按阶段向外部汇报加载进度。
            你需要编写一个关卡加载器，验证“外部驱动”与“内部暂停”的执行顺序。

            【具体要求】：
            1. 创建类 LevelLoader。
            2. 编写方法 LoadLevelSteps()，返回类型为 IEnumerator。
               - 方法内部依次执行：
                 - 打印 "内部：开始初始化物理引擎"
                 - yield return "物理引擎就绪"
                 - 打印 "内部：开始加载场景纹理"
                 - yield return "纹理加载完成"
                 - 打印 "内部：所有资源准备完毕"
                 - 显式使用 yield break 退出。

            3. 在 Main 方法中：
               - 实例化 LevelLoader 并调用 LoadLevelSteps() 获取 enumerator 变量。
               - 在首次调用 MoveNext() 之前，先打印 "Main：准备开始加载"。
               - 使用 while 循环驱动 MoveNext()。
               - 每次循环内部打印 "Main：获取到步骤结果 -> " + enumerator.Current。

            【变量/方法命名规范】：
            - 类名：LevelLoader
            - 方法名：LoadLevelSteps
            - Main 中变量名：loader、enumerator

            请在下方回复你编写的代码。检查得分 60 分以上方可进入下一个知识点。
            ================================================================
            */
            LevelLoader loader = new LevelLoader();
            IEnumerator enumerator = loader.LoadLevelSteps();
            Console.WriteLine("Main: 准备开始加载");
            while (enumerator.MoveNext())
            {
                Console.WriteLine($"Main: 获取到步骤结果 -> {enumerator.Current}");
            }

        }
    }
    public class LevelLoader
    {
        public IEnumerator LoadLevelSteps()
        {
            Console.WriteLine("内部：开始初始化物理引擎");
            yield return "物理引擎就绪";
            Console.WriteLine("内部：开始加载场景纹理");
            yield return "纹理加载完成";
            Console.WriteLine("内部：所有资源加载完毕");
            yield break;
        }
    }
}
