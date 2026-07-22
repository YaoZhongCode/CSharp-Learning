using System.Reflection;

namespace AttributeClass006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ===================================================================
            背景模拟：
            你在开发一个 UI 框架（UIManager）。当界面打开时，需要扫描按钮点击事件
            方法上挂载的音效特性。若检测到音效特性，不仅要打印播放音效，
            还要使用 MethodInfo.Invoke 动态调用该按钮的点击响应方法，触发业务逻辑。

            具体要求：
            1. 声明一个自定义音效特性类，类名必须严格符合命名规范。
               - 使用 [AttributeUsage] 限制其【只能】挂载到方法（Method）上。
               - 构造函数接收一个 string 类型的音效文件名（SoundName）。
               - 包含一个只读属性存储该音效文件名（注意拼写为 SoundName！）。
            2. 声明一个按钮响应类 StartGameButton。
               - 包含一个无参无返回值方法 OnClick。
               - 在 OnClick 方法上方挂载音效特性，传入 "button_click.wav"。
               - OnClick 方法体中，打印一行日志："进入游戏场景..."。
            3. 在 Main 方法中：
               - 实例化一个 StartGameButton 对象（名为 buttonInstance）。
               - 使用 typeof(StartGameButton).GetMethod(nameof(StartGameButton.OnClick), new Type[0])
                 显式锁定该无参方法（进行判空防御）。
               - 获取该方法上的音效特性。
               - 若特性存在，先在控制台打印出："点击按钮，播放音效：[SoundName]"。
               - 随后，使用 method.Invoke(buttonInstance, null) 动态调用该方法。

            变量/方法命名规范：
            - 特性类名：ButtonClickSoundAttribute
            - 特性中的只读属性：SoundName
            - 目标按钮类名：StartGameButton
            - 目标响应方法名：OnClick
            - 实例变量名：buttonInstance
            ===================================================================
            */
            StartGameButton buttonInstance = new StartGameButton();
            Type type = typeof(StartGameButton);
            MethodInfo? method = type.GetMethod(nameof(StartGameButton.OnClick), new Type[0]);
            if(method != null)
            {
                Attribute? attribute = Attribute.GetCustomAttribute(method, typeof(ButtonClickSoundAttribute));
                if(attribute != null && attribute is ButtonClickSoundAttribute buttonAttr)
                {
                    Console.WriteLine($"点击按钮，播放音效：[{buttonAttr.SoundName}]");
                    method.Invoke(buttonInstance, null);
                }
            }

        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonClickSoundAttribute : Attribute
    {
        public string SoundName { get; }
        public ButtonClickSoundAttribute(string soundName)
        {
            SoundName = soundName;
        }
    }

    public class StartGameButton
    {
        [ButtonClickSound("button_click.wav")]
        public void OnClick()
        {
            Console.WriteLine("进入游戏场景...");
        }
    }
}
