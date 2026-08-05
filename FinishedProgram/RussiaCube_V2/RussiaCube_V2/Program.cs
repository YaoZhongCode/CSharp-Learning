using RussiaCube_V2.Core;
using RussiaCube_V2.Scenes;

namespace RussiaCube_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            GameEngine engine = new GameEngine();

            engine.SceneManager.ChangeScene(new StartScene());

            engine.Run();
        }
    }
}
