using System;
using System.Collections.Generic;
using System.Text;
using RussiaCube_V1.GameObjects;

namespace RussiaCube_V1.Polymer
{
    /// <summary>
    /// 游戏主体地图
    /// </summary>
    internal class Map
    {
        //固定的墙壁
        private List<DrawObject> _deadWalls;
        //动态墙壁
        private List<DrawObject> _dynamicWalls;

        public Map()
        {
            _deadWalls = new List<DrawObject>();
            _dynamicWalls = new List<DrawObject>();
        }


    }
}
