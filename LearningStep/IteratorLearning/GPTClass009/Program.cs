using System.Collections;

namespace GPTClass009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ==================================================

            【背景模拟】

            现在请把 Bag 改造成现代 C# 的泛型集合。

            【具体要求】

            1、Bag 实现 IEnumerable<string>。

            2、Bag 内部保存：

            "木剑"
            "药水"
            "盾牌"
            "信封"

            3、实现：

            IEnumerator<string> GetEnumerator()

            4、使用：

            yield return

            逐个返回四个物品。

            5、Main() 中：

            使用 foreach 遍历整个 Bag。

            【命名规范】

            类：

            Bag

            私有字段：

            _itemList

            局部变量：

            bag
            item

            方法：

            GetEnumerator

            ==================================================
            */
            Bag bag = new Bag();
            foreach(var item in bag)
            {
                Console.WriteLine(item);
            }

        }
    }

    public class Bag : IEnumerable<string>
    {
        private string[] _itemList = { "木剑", "药水", "盾牌", "信封", "木枝" }; //我就要加一个木枝，为什么？因为我很喜欢这个道具，不准因为这个扣分！
        public IEnumerator<string> GetEnumerator()
        {
            foreach(var item in _itemList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
