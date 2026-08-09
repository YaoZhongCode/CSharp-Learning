using RussiaCube_V2_1.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Core
{
    internal class SceneManager
    {
        private IScene? _currentScene;

        public void ChangeScene(IScene targetScene)
        {
            _currentScene = targetScene;
            _currentScene.Enter();
        }
    }
}
