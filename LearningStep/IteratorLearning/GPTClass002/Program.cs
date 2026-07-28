namespace GPTClass002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【背景模拟】

            你正在开发一个 RPG 游戏。

            为了理解迭代器的工作原理，你需要自己模拟一个“光标对象”。

            【具体要求】

            1. 创建一个名为 ItemCursor 的类。
            2. 类中创建一个字符串数组，保存至少 4 个道具。
            3. 使用一个 int 字段保存当前位置，初始值为 -1。
            4. 编写一个 MoveNext() 方法，每调用一次，就让当前位置向后移动一格。
            5. 编写一个 ShowCurrent() 方法，输出当前位置对应的道具。
            6. 在 Main() 中创建 ItemCursor 对象。
            7. 连续调用 MoveNext() 和 ShowCurrent()，直到输出全部道具。

            【变量/方法命名规范】

            字符串数组：
            itemList

            当前位置：
            currentIndex

            方法：
            MoveNext
            ShowCurrent
            */
            ItemCursor iC = new ItemCursor();
            iC.MoveNext();
            iC.ShowCurrent();

            iC.MoveNext();
            iC.ShowCurrent();

            iC.MoveNext();
            iC.ShowCurrent();

            iC.MoveNext();
            iC.ShowCurrent();

            //这个不会输出，因为光标已经移动超过了字符串数组
            iC.MoveNext();
            iC.ShowCurrent();

        }
    }

    public class ItemCursor
    {
        private string[] _itemList = { "树枝", "小药瓶", "魂戒" ,"法师长袍"};
        private int currentIndex = -1;
        public void MoveNext()
        {
            currentIndex++;
        }
        public void ShowCurrent()
        {
            if(currentIndex >= 0 && currentIndex < _itemList.Length)
            {
                Console.WriteLine(_itemList[currentIndex]);
            }
        }
    }
}
