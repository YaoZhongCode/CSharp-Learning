using HungrySnakeV2_0.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnakeV2_0.Core
{
    internal class SceneManager
    {
        private IScene? currentScene;

        public void ChangeScene(IScene scene)
        {
            currentScene = scene;
        }

        public void Update()
        {
            currentScene?.Update();
        }
    }
}
