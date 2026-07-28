namespace GPTClass003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【背景模拟】

            你正在继续完善自己的 ItemCursor。

            为了模拟真正的 IEnumerator，你需要让 MoveNext()
            能够告诉调用者："是否还有下一个元素。"

            【具体要求】

            1. 将 MoveNext() 的返回类型改成 bool。
            2. 每次调用时，先让 currentIndex 自增。
            3. 如果 currentIndex 仍然小于数组长度，则返回 true。
            4. 否则返回 false。
            5. 在 Main() 中使用 while 循环：
                   while (cursor.MoveNext())
               来遍历所有道具。
            6. ShowCurrent() 方法保持不变。

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
            while (iC.MoveNext())
            {
                iC.ShowCurrent();
            }

        }
    }
    public class ItemCursor
    {
        private string[] itemList = { "树枝", "小药瓶", "魂戒", "法师长袍" };
        private int currentIndex = -1;
        public bool MoveNext()
        {
            currentIndex++;

            if(currentIndex < itemList.Length)
            {
                return true;
            }
            return false;
        }
        public void ShowCurrent()
        {
            if (currentIndex >= 0 && currentIndex < itemList.Length)
            {
                Console.WriteLine(itemList[currentIndex]);
            }
        }
    }

}
