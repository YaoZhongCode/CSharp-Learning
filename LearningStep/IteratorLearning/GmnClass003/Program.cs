using System.Collections;

namespace GmnClass003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【小练习 1.3】：手动还原解糖遍历
            【背景模拟】：
            在 Unity 某些性能极其敏感的底层模块中，为了避免产生多余的包装或明确掌控游标状态，
            架构师要求禁止使用 foreach 语法糖，而是用最原始的 while + IEnumerator 逻辑遍历对话容器。

            【具体要求】：

            在 Main 方法中，创建一个 DialogueContainer 实例，传入包含 3 句台词的 string[] 数组。

            严禁使用 foreach 关键字。

            手动调用 GetEnumerator() 获取游标对象。

            使用 while 循环配合 MoveNext() 和 Current，将 3 句台词逐行打印到控制台。

            【变量/方法命名规范】：

            容器变量名：dialogueContainer

            迭代器变量名：enumerator

            请在下方回复你编写的 Main 方法代码段
            （包含前面编写好的 DialogueContainer 与 DialogueEnumerator 组合运行）。
            检查得分 60 分以上方可进入下一个知识点。
            */

            string[] dialogues = { "你好哇！", "你在干什么！", "快住手！" };
            DialogueContainer dialogueContainer = new DialogueContainer(dialogues);
            DialogueEnumerator? enumerator = dialogueContainer.GetEnumerator() as DialogueEnumerator; //不强制转换编译报错，所以我强制转换了
            if(enumerator == null)
            {
                return;
            }
            while (enumerator.MoveNext())
            {
                object current = enumerator.Current;
                Console.WriteLine(current);
            }

        }
    }
    public class DialogueEnumerator : IEnumerator
    {
        private string[] _dialogues;
        private int _currentIndex = -1;
        public DialogueEnumerator(string[] dialogue)
        {
            _dialogues = dialogue ?? throw new ArgumentNullException(nameof(dialogue));
        }
        public object Current
        {
            get
            {
                if(_currentIndex < 0 || _currentIndex >= _dialogues.Length)
                {
                    throw new InvalidOperationException("索引越界，确保MoveNext被正确使用");
                }
                return _dialogues[_currentIndex];
            }
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _dialogues.Length;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }

    public class DialogueContainer : IEnumerable
    {
        private string[] _dialogues;
        public DialogueContainer(string[] dialogues)
        {
            _dialogues = dialogues ?? throw new ArgumentNullException(nameof(dialogues));
        }
        public IEnumerator GetEnumerator()
        {
            return new DialogueEnumerator(_dialogues);
        }
    }
}
