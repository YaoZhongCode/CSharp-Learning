using System.Reflection;

namespace AttributeClass005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ===================================================================
            背景模拟：
            你在开发一个 UI 框架（UIManager）。当界面打开时，需要扫描按钮点击事件
            方法上挂载的音效特性，以便在玩家点击按钮时播放指定的音效。

            具体要求：
            1. 声明一个自定义音效特性类，类名必须严格符合命名规范。
               - 使用 [AttributeUsage] 限制其【只能】挂载到方法（Method）上。
               - 构造函数接收一个 string 类型的音效文件名（SoundName）。
               - 包含一个只读属性存储该音效文件名。
            2. 声明一个按钮响应类 StartGameButton。
            3. 在 StartGameButton 类中声明一个无参无返回值方法 OnClick。
               - 在 OnClick 方法上方挂载音效特性，传入 "button_click.wav"。
            4. 在 Main 方法中：
               - 使用 typeof(StartGameButton).GetMethod(nameof(StartGameButton.OnClick), new Type[0])
                 显式锁定该无参方法（注意做判空防御检查）。
               - 使用 Attribute.GetCustomAttribute 获取该方法上的音效特性。
               - 判空防御后，在控制台打印出：
                 "点击按钮，播放音效：[音效文件名]"

            变量/方法命名规范：
            - 特性类名：ButtonClickSoundAttribute
            - 特性中的只读属性：SoundName
            - 目标按钮类名：StartGameButton
            - 目标响应方法名：OnClick
            ===================================================================
            */
            Type type = typeof(StartGameButton);
            MethodInfo? method = type.GetMethod(nameof(StartGameButton.OnClick), new Type[0]);
            if(method != null)
            {
                Attribute? attribute = Attribute.GetCustomAttribute(method, typeof(ButtonClickSoundAttribute));
                if(attribute != null && attribute is ButtonClickSoundAttribute buttonClick)
                {
                    Console.WriteLine($"点击按钮，播放音效：[{buttonClick.SongName}]");
                }
            }
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonClickSoundAttribute : Attribute
    {
        public string SongName { get; }
        public ButtonClickSoundAttribute(string songName)
        {
            SongName = songName;
        }
    }
    public class StartGameButton
    {
        [ButtonClickSound("button_click.wav")]
        public void OnClick()
        {
            Console.WriteLine("开始按钮被点击");
        }
    }


}
