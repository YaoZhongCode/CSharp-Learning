using System.Collections;

namespace GmnClass001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【小练习 1.1】：手动实现对话句子迭代器
            【背景模拟】：
            在 RPG 游戏的对话系统中，UI 界面需要按顺序逐句显示 NPC 的台词。
            现在需要你手动实现一个底层迭代器，用于逐句读取对话字符串数组。

            【具体要求】：

            创建一个名为 DialogueEnumerator 的类，实现 System.Collections.IEnumerator 接口。

            构造函数接收一个 string[] 类型数组（表示多句对话）。

            进行防御性检查：若传入的 string[] 为 null，在构造函数中抛出 ArgumentNullException。

            严格按照接口规范，手动实现 Current、MoveNext()、Reset() 三个成员。

            确保初始游标位置符合 IEnumerator 规范（位于首个元素之前）。

            【变量/方法命名规范】：

            类名：DialogueEnumerator

            私有成员变量：以下划线开头（如 _dialogues、_currentIndex）

            接口成员：严格遵循 IEnumerator 规范的大小写与签名

            请在下方回复你编写的代码。检查得分 60 分以上方可进入下一个知识点。
            */
        }
    }
    public class DialogueEnumerator : IEnumerator
    {
        private string[] _dialogues;
        private int _currentIndex = -1;

        public DialogueEnumerator(string[] dialogues)
        {
            //防御性编程，防止传入空引用
            _dialogues = dialogues ?? throw new ArgumentNullException(nameof(dialogues));
        }
        public object Current
        {
            get
            {
                if(_currentIndex < 0 || _currentIndex >= _dialogues.Length)
                {
                    throw new InvalidOperationException("游标位于无效位置，请确保正确调用MoveNext()。");
                }
                return _dialogues[_currentIndex];
            }
        }

        public bool MoveNext()
        {
            if(_currentIndex < _dialogues.Length - 1)
            {
                _currentIndex++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }

}
