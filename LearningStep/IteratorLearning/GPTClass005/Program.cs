namespace GPTClass005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【思考题】

            1.

            为什么 MoveNext() 必须设计成方法，
            而不能设计成属性？

            请说明原因。

            -------------------------

            2.

            为什么 Current 更适合设计成属性，
            而不是 GetCurrent() 方法？

            请说明原因。

            -------------------------

            3.

            下面两个成员：

            MoveNext()

            Current

            哪一个会改变对象状态？
            哪一个只是读取对象状态？

            请分别回答。
            */

            /*第一题： 因为MoveNext() 需要改变光标位置，是一种动作，所以设置成方法
             * 
             * 第二题：  因为当前光标所指向的元素，是对象本身的一种状态，读取他并不会改变什么，所以设置成属性
             * 
             * 第三题： MoveNext() 会改变对象状态
             * Current只是读取对象状态
             * 
             */
        }
    }
}
