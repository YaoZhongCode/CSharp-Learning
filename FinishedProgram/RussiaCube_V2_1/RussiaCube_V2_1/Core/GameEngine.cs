using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Core
{
    /// <summary>
    /// 游戏引擎
    /// </summary>
    internal class GameEngine
    {
        //拥有场景管理器
        private SceneManager _sceneManager;
        //是否运行游戏标识
        private bool _isRunning;

        public GameEngine()
        {
            _sceneManager = new SceneManager();
            _isRunning = false;
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 22);
        }

        /// <summary>
        /// 启动游戏
        /// </summary>
        public void Run()
        {
            _isRunning = true;
            while (_isRunning)
            {
                //循环更新当前场景
                _sceneManager.Update();

                //休眠10毫秒，防止CPU空转
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// 停止游戏
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
        }
    }
}
