using FlyChessV2_0.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Core
{
    public class SceneManager
    {
        private IScene? currentScene;
        public SceneManager()
        {
            Console.SetWindowSize(GameConfig.width, GameConfig.height);
            Console.CursorVisible = false;
        }

        public void SwitchScene(IScene nextScene)
        {
            currentScene = nextScene;
            currentScene.Enter();
        }

        public void Update()
        {
            IScene? nextScene = null;
            if (currentScene != null)
            {
                //如果当前场景返回了一个新场景，先装起来
                nextScene = currentScene.Update();
            }

            if(nextScene != null)
            {
                //如果下一个场景不为空，说明有新场景返回，需要切换到新场景
                SwitchScene(nextScene); //切换到新场景
            }
        }
    }
}
