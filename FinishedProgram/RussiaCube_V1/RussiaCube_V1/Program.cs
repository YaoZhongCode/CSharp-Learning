

using RussiaCube_V1.Core;
using RussiaCube_V1.Scenes;

namespace RussiaCube_V1
{
    internal class Program
    {
        //俄罗斯方块
        static void Main(string[] args)
        {
            Console.SetWindowSize(GameConfig.width, GameConfig.height);
            Console.CursorVisible = false;

            SceneManager sceneManager = new SceneManager();
            sceneManager.ChangeScene(new StartScene()); //开始游戏时默认进入开始场景

            while (true)
            {
                sceneManager.UpdateScene();
            }
        }
    }
}
