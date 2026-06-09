using SavePrincessV_2_0.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.Core
{
    internal class SceneManager
    {
        private IScene? currentScene;

        public void ChangeScene(IScene scene)
        {
            currentScene = scene;
            currentScene.Enter();
        }

        public void Update()
        {
            IScene? nextScene = currentScene!.Update();
            if(nextScene != null)
            {
                ChangeScene(nextScene);
            }
        }

    }
}
