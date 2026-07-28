using System.Collections;

namespace GPTClass007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【背景模拟】

            你现在已经拥有一个真正的 IEnumerator。

            请继续实现一个 Bag 类，
            使它能够提供自己的迭代器。

            【具体要求】

            1. 创建一个 Bag 类。
            2. Bag 实现 IEnumerable 接口。
            3. 实现 GetEnumerator() 方法。
            4. GetEnumerator() 返回一个新的 ItemCursor 对象。
            5. Main() 中：

                Bag bag = new Bag();

                IEnumerator cursor = bag.GetEnumerator();

                while(cursor.MoveNext())
                {
                    Console.WriteLine(cursor.Current);
                }

            【命名规范】

            类：

            Bag
            ItemCursor

            私有字段：

            _itemList
            _currentIndex

            局部变量：

            bag
            cursor

            方法：

            GetEnumerator
            MoveNext
            Reset

            属性：

            Current
            */
            Bag bag = new Bag();
            IEnumerator cursor = bag.GetEnumerator();
            while (cursor.MoveNext())
            {
                Console.WriteLine(cursor.Current);
            }
        }
    }
    public class Bag : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return new ItemCursor();
        }
    }


    public class ItemCursor : IEnumerator
    {
        private string[] _itemList = { "树枝", "信封", "小魔瓶", "琉璃之泪" };
        private int _currentIndex = -1;
        public object Current => _itemList[_currentIndex];

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _itemList.Length;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }

}
