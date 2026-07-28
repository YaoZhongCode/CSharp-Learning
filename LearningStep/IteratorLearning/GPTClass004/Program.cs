namespace GPTClass004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【背景模拟】

            你正在继续模拟 IEnumerator。

            目前 MoveNext() 已经负责移动光标。

            现在请增加一个 Current 属性，用于返回当前光标所指向的道具。

            【具体要求】

            1. 保留上一题的 MoveNext()。
            2. 删除 ShowCurrent() 方法。
            3. 新增一个只读属性：
                   public string Current
            4. Current 返回当前位置对应的字符串。
            5. Main() 中使用：

                   while (cursor.MoveNext())
                   {
                       Console.WriteLine(cursor.Current);
                   }

               输出全部道具。

            【命名规范（采用接近官方风格）】

            私有字段：
            _itemList
            _currentIndex

            属性：
            Current

            方法：
            MoveNext

            局部变量：
            cursor
            */
            ItemCursor iC = new ItemCursor();
            while (iC.MoveNext())
            {
                Console.WriteLine(iC.Current);
            }

        }
    }

    public class ItemCursor
    {
        private string[] _itemList = { "树枝", "小药瓶", "魂戒", "法师长袍" };
        private int _currentIndex = -1;
        public string Current { get { return _itemList[_currentIndex]; } }
        public bool MoveNext()
        {
            _currentIndex++;

            if (_currentIndex < _itemList.Length)
            {
                return true;
            }
            return false;
        }


        //public void ShowCurrent()
        //{
        //    if (_currentIndex >= 0 && _currentIndex < _itemList.Length)
        //    {
        //        Console.WriteLine(_itemList[_currentIndex]);
        //    }
        //}


    }
}
