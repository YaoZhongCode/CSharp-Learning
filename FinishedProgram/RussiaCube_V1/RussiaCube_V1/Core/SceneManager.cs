using RussiaCube_V1.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Core
{
    internal class SceneManager
    {
        private IScene? _currentScene;

        public void ChangeScene(IScene nextScene)
        {
            _currentScene = nextScene;
            _currentScene.Enter(); //切换场景后调用一次进入代码
        }

        public void UpdateScene()
        {
            IScene? nextScene = null;
            if(_currentScene != null)
            {
                nextScene = _currentScene.Update();
            }

            //如果有场景返回，切换场景
            if(nextScene != null)
            {
                ChangeScene(nextScene);
            }
        }

    }
}
