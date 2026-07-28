using System.Collections;

namespace GPTClass008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //由于GPT没有给我一键复制的练习题，所以这道题没有前面的那种题目
            //本题是需要写泛型版本的ItemCursor

            ItemCursor cursor = new ItemCursor();
            foreach(var item in cursor)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class ItemCursor : IEnumerator<string>, IEnumerable
    {
        private string[] _itemList = { "木剑", "木枝", "信封", "琉璃之泪" };
        private int _currentIndex = -1;
        public string Current => _itemList[_currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public IEnumerator GetEnumerator()
        {
            Reset(); //返回一个迭代器之前，先重置光标位置
            return this; //把自己返回出去
        }

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
