using System.Collections;

namespace GPTClass006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【背景模拟】

            你正在将自己之前编写的 ItemCursor，
            正式改造成符合 C# IEnumerator 接口规范的迭代器。

            【具体要求】

            1. ItemCursor 实现 IEnumerator 接口。
            2. Current 返回类型修改为 object。
            3. 实现 Reset() 方法，将光标恢复到起始位置。
            4. Main() 中遍历完成一次后，
               调用 Reset()，
               再遍历第二次。

            【命名规范（微软推荐风格）】

            私有字段：
            _itemList
            _currentIndex

            局部变量：
            cursor

            属性：
            Current

            方法：
            MoveNext
            Reset
            */
            ItemCursor cursor = new ItemCursor();
            while (cursor.MoveNext())
            {
                Console.WriteLine(cursor.Current);
            }

            cursor.Reset();

            while (cursor.MoveNext())
            {
                Console.WriteLine(cursor.Current);
            }

        }
    }

    public class ItemCursor : IEnumerator
    {
        private string[] _itemList = { "树枝", "小药瓶", "魂戒", "法师长袍" };
        private int _currentIndex = -1;
        public object Current { get { return _itemList[_currentIndex]; } }
        public bool MoveNext()
        {
            _currentIndex++;

            if (_currentIndex < _itemList.Length)
            {
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
