using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Managers
{
    /// <summary>
    /// 输入控制
    /// </summary>
    internal class InputManager
    {
        //当有按键按下时触发的事件，传递按下的按键
        public event Action<ConsoleKey>? OnKeyPressed;

        private CancellationTokenSource? _cts;

        /// <summary>
        /// 开启多线程后台监听按键
        /// </summary>
        public void StartListening()
        {
            //如果已经在监听，先停止之前的
            StopListening();

            _cts = new CancellationTokenSource();

            //在后台 Task 中运行按键监听循环
            Task.Run(() => ListenInput(_cts.Token), _cts.Token);
        }

        /// <summary>
        /// 取消监听任务
        /// </summary>
        public void StopListening()
        {
            if(_cts != null)
            {
                _cts.Cancel(); //发送取消信号，让后台 Task 的循环结束
                _cts.Dispose(); //释放令牌资源
                _cts = null; //置空令牌
            }
        }

        /// <summary>
        /// 输入监听
        /// </summary>
        /// <param name="token">令牌</param>
        private void ListenInput(CancellationToken token)
        {
            // 只要外部没有按下“取消开关”，就一直监听
            while (!token.IsCancellationRequested)
            {
                if (Console.KeyAvailable)
                {
                    // 读取按键（true 表示不在屏幕上打印按下的字符）
                    ConsoleKey key = Console.ReadKey(true).Key;

                    // 触发事件通知订阅者
                    OnKeyPressed?.Invoke(key);
                }
                //休眠 10 毫秒，防止后台线程把 CPU 占满
                Thread.Sleep(10);
            }
        }
    }
}
