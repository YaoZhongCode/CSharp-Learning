using RussiaCube_V2_1.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Core
{
    /// <summary>
    /// 场景管理器
    /// </summary>
    internal class SceneManager
    {
        //当前场景
        private IScene? _currentScene;

        public SceneManager()
        {
            _currentScene = new GameScene();
            _currentScene?.Enter();
        }

        /// <summary>
        /// 切换场景
        /// </summary>
        /// <param name="targetScene">目标场景</param>
        public void ChangeScene(IScene targetScene)
        {
            _currentScene?.Exit();
            _currentScene = targetScene;
            _currentScene?.Enter();
        }

        /// <summary>
        /// 更新当前场景的Update
        /// </summary>
        public void Update()
        {
            _currentScene?.Update();
        }

        public void Render()
        {
            _currentScene?.Render();
        }
    }
}
