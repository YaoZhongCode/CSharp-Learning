using System;
using System.Collections.Generic;
using System.Text;
using RussiaCube_V1.Core;
using RussiaCube_V1.GameObjects;

namespace RussiaCube_V1.Polymer
{
    enum E_WallType
    {
        Dead,
        Dynamic
    }

    /// <summary>
    /// 游戏主体地图
    /// </summary>
    internal class Map
    {
        //固定的墙壁
        private List<DrawObject> _deadWalls;
        //动态墙壁
        private List<DrawObject> _dynamicWalls;

        //供外部获取墙壁长度
        public int DeadWallsLength => _deadWalls.Count;
        public int DynamicWallsLength => _dynamicWalls.Count;

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index">索引值</param>
        /// <param name="type">墙壁类型</param>
        /// <returns></returns>
        public DrawObject this[int index, E_WallType type]
        {
            get
            {
                if(type == E_WallType.Dead)
                {
                    return _deadWalls[index];
                }
                else
                {
                    return _dynamicWalls[index];
                }
            }
        }

        public Map()
        {
            _deadWalls = new List<DrawObject>();
            _dynamicWalls = new List<DrawObject>();

            //竖向墙壁
            for(int i = 0; i < GameConfig.width; i += 2)
            {
                _deadWalls.Add(new DrawObject(E_CubeType.Wall, i, GameConfig.height - 7));
            }

            //构建横向墙壁
            for(int i = 0; i < GameConfig.height - 7; i++)
            {
                _deadWalls.Add(new DrawObject(E_CubeType.Wall, 0, i));
                _deadWalls.Add(new DrawObject(E_CubeType.Wall, GameConfig.width - 2, i));
            }
        }

        /// <summary>
        /// 画出不动的墙壁
        /// </summary>
        public void DrawDeadWall()
        {
            for(int i = 0; i < _deadWalls.Count; i++)
            {
                _deadWalls[i].Draw();
            }
        }

        /// <summary>
        /// 画动态墙壁
        /// </summary>
        public void DrawDynamicWall()
        {
            for(int i = 0; i < _dynamicWalls.Count; i++)
            {
                _dynamicWalls[i].Draw();
            }
        }

        /// <summary>
        /// 添加动态墙壁
        /// </summary>
        /// <param name="walls">要添加的方块数据</param>
        public void AddDynamicWalls(List<DrawObject> cubes)
        {
            for(int i = 0; i < cubes.Count; i++)
            {
                //先把类型转换为墙壁（主要是颜色区分）
                cubes[i].ChangeType(E_CubeType.Wall);
                _dynamicWalls.Add(cubes[i]); //添加到动态墙壁里面去
            }
        }
    }
}
