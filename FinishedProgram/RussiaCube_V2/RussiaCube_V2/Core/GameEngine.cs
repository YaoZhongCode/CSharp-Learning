using RussiaCube_V2.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Core
{
    internal class GameEngine
    {
        private bool _isRunning;
        private SceneManager _sceneManager;
        public SceneManager SceneManager => _sceneManager;

        public GameEngine()
        {
            _sceneManager = new SceneManager();
            _isRunning = false;
        }

        /// <summary>
        /// 启动游戏主循环
        /// </summary>
        public void Run()
        {
            _isRunning = true;

            //游戏主循环
            while (_isRunning)
            {
                // 1. 处理/更新当前场景的逻辑
                _sceneManager.Update();
                // 2. 渲染当前场景的画面
                _sceneManager.Render();
                // 3. 控制帧率：休眠 30 毫秒（约 33 帧/秒），降低 CPU 占用率
                Thread.Sleep(30);
            }
        }

        /// <summary>
        /// 停止游戏（退出主循环）
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
        }
    }
}
