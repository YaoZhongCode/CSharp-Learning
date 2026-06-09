using SavePrincessV_2_0.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.Core
{
    public class GameManager
    {
        SceneManager sceneManager;
        int width;
        int height;
        public GameManager()
        {
            width = 60;
            height = 40;
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.Clear();

            sceneManager = new SceneManager();
            
        }

        public void Start()
        {
            //游戏一开始,就让他进入开始页面
            sceneManager.ChangeScene(new StartScene(width, height));

            while (true)
            {
                sceneManager.Update();
            }
        }
    }
}
