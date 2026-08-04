using RussiaCube_V1.Core;
using RussiaCube_V1.Polymer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Scenes
{
    internal class GameScene : IScene
    {
        //创建地图
        private Map _map;
        private CubeManager _cubeManager;
        private Thread _inputThread;
        private object _locker;
        public GameScene()
        {
            _map = new Map();
            _cubeManager = new CubeManager();
            _inputThread = new Thread(Input);
            _locker = new object();
        }
        public void Enter()
        {
            Console.Clear();
            //线程设置为后台线程，使其跟随主线程一起结束
            _inputThread.IsBackground = true;
            //开启线程
            _inputThread.Start();
            _map.DrawDeadWall(); //画出不变的墙壁
        }

        
        public IScene? Update()
        {
            IScene? nextScene = null;
            //保护线程安全
            lock (_locker)
            {
                //画方块
                _cubeManager.Draw();
                //画出动态墙壁
                _map.DrawDynamicWall();
                //方块自动掉落
                 nextScene = _cubeManager.FallDown(_map);
                //每次检测是否已经结束游戏，结束就返回结束场景
                if (nextScene != null)
                {
                    return nextScene;
                }
            }
            Thread.Sleep(250);
            return null;
        }

        /// <summary>
        /// 输入系统
        /// </summary>
        private void Input()
        {
            while (true)
            {
                //键盘被激活时才触发
                if (Console.KeyAvailable)
                {
                    //保护线程安全
                    lock (_locker)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.LeftArrow:
                                _cubeManager.SwitchShape(E_SwitchDirection.Left, _map);
                                Console.SetCursorPosition(2, GameConfig.height - 6);
                                Console.Write("按下了左箭头");
                                break;
                            case ConsoleKey.RightArrow:
                                _cubeManager.SwitchShape(E_SwitchDirection.Right, _map);
                                Console.SetCursorPosition(2, GameConfig.height - 6);
                                Console.Write("按下了右箭头");
                                break;
                            case ConsoleKey.A:
                                _cubeManager.MoveLeftOrRight(E_MoveDirection.Left, _map);
                                break;
                            case ConsoleKey.D:
                                _cubeManager.MoveLeftOrRight(E_MoveDirection.Right, _map);
                                break;
                            case ConsoleKey.S:
                                _cubeManager.FallDown(_map);
                                break;
                        }
                    }
                }
            }
        }
    }
}
