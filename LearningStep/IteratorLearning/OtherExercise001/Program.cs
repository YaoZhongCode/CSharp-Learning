using System.Collections;

namespace OtherExercise001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //请为一个自定义类，用两种方法让其可以被foreach遍历
            int[] list = { 11, 14, 16, 17, 20, 22 };
            MyClass1 class1 = new MyClass1(list);
            MyClass2 class2 = new MyClass2(list);
            foreach(var n in class1)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("----------------------------------------");
            foreach(var n in class2)
            {
                Console.WriteLine(n);
            }


        }
    }
    //第一种
    public class MyClass1 : IEnumerator<int>, IEnumerable<int>
    {
        private int[] _lists;
        private int _currentIndex = -1;
        public MyClass1(int[] lists)
        {
            //防御性检查
            _lists = lists ?? throw new ArgumentNullException(nameof(lists));
        }

        public int Current => _lists[_currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public IEnumerator<int> GetEnumerator()
        {
            Reset();
            return this;
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _lists.Length;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //第二种
    public class MyClass2 : IEnumerable<int>
    {
        private int[] _lists;
        public MyClass2(int[] lists)
        {
            _lists = lists ?? throw new ArgumentNullException(nameof(lists));
        }
        public IEnumerator<int> GetEnumerator()
        {
            foreach(var i in _lists)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
