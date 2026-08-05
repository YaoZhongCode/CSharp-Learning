using RussiaCube_V2.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Managers
{
    internal class SceneManager
    {
        // 存储当前正在运行的场景
        private IScene? _currentScene;

        // 获取当前场景（只读属性，方便外部查看）
        public IScene? CurrentScene => _currentScene;

        /// <summary>
        /// 切换场景
        /// </summary>
        /// <param name="nextScene">要切换到的场景</param>
        public void ChangeScene(IScene nextScene)
        {
            // 步骤 1: 如果当前有场景，先让当前场景执行 Exit() 清理资源
            _currentScene?.Exit();
            // 步骤 2: 将 _currentScene 替换为 nextScene
            _currentScene = nextScene;
            // 步骤 3: 让新场景执行 Enter() 进行初始化
            _currentScene.Enter();
        }

        /// <summary>
        /// 每帧更新当前场景逻辑
        /// </summary>
        public void Update()
        {
            IScene? nextScene = null;

            // 如果 _currentScene 不为空，调用它的 Update()
            nextScene = _currentScene?.Update();

            //如果下一个场景不为空，说明需要切换场景
            if(nextScene != null)
            {
                ChangeScene(nextScene);
            }

        }

        /// <summary>
        /// 每帧绘制当前场景画面
        /// </summary>
        public void Render()
        {
            // 如果 _currentScene 不为空，调用它的 Render()
            _currentScene?.Render();
        }
    }
}
