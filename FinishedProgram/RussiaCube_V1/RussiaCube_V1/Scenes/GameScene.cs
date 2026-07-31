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
        Map _map;
        CubeManager _cubeManager;
        public GameScene()
        {
            _map = new Map();
            _cubeManager = new CubeManager();
        }
        public void Enter()
        {
            Console.Clear();
            _map.DrawDeadWall(); //画出不变的墙壁
        }

        public IScene? Update()
        {
            _cubeManager.Draw();

            return null;
        }
    }
}
