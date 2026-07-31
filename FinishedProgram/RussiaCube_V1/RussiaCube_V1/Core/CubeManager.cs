using RussiaCube_V1.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Core
{
    /// <summary>
    /// 管理方块的主要类
    /// </summary>
    internal class CubeManager : IDraw
    {
        //存储四个小方块：所有方块类型都是由四个小方块组成
        private List<DrawObject> _cubes;
        private Dictionary<E_CubeType, CubeInfo> _cubeInfoDic;
        private CubeInfo _nowCubeInfo;

        public CubeManager()
        {
            _nowCubeInfo = new CubeInfo(E_CubeType.Square); //暂时先这样实例化，后续会覆盖
            _cubes = new List<DrawObject>();

            //初始化方块信息
            _cubeInfoDic = new Dictionary<E_CubeType, CubeInfo>()
            {
                { E_CubeType.Square, new CubeInfo(E_CubeType.Square)},
                { E_CubeType.Rectangle, new CubeInfo(E_CubeType.Rectangle)},
                { E_CubeType.Tank, new CubeInfo(E_CubeType.Tank)},
                { E_CubeType.Trapezoid_left, new CubeInfo(E_CubeType.Trapezoid_left)},
                { E_CubeType.Trapezoid_right, new CubeInfo(E_CubeType.Trapezoid_right)},
                { E_CubeType.Trapezoid_long_left, new CubeInfo(E_CubeType.Trapezoid_long_left)},
                { E_CubeType.Trapezoid_long_right, new CubeInfo(E_CubeType.Trapezoid_long_right)},
            };
            //随机一个方块
            RandomCreateCube();
        }

        /// <summary>
        /// 创建一个随机方块
        /// </summary>
        public void RandomCreateCube()
        {
            //强转随机获取一个方块类型
            E_CubeType type = (E_CubeType)Random.Shared.Next(1, 8);

            //根据随机到的方块类型，生成方块（4个小方块组成）
            _cubes = new List<DrawObject>()
            {
                new DrawObject(type),
                new DrawObject(type),
                new DrawObject(type),
                new DrawObject(type),
            };

            //第一个小方块需要先声明，其他三个小方块根据它的坐标进行对应偏移
            _cubes[0].Pos = new Position(GameConfig.width / 2, 5);

            //获取到对应随机到的方块的具体偏移坐标数据
            _nowCubeInfo = _cubeInfoDic[type];

            //获取随机索引，从方块的所有类型中：正方形只有一个类型，其他的均有四种
            //使用自定义的属性Length就能动态定义边界
            int index = Random.Shared.Next(0, _nowCubeInfo.Length);
            //获取其中一种形态的坐标信息
            Position[] pos = _nowCubeInfo[index];
            for(int i = 0; i < pos.Length; i++)
            {
                //依次设定剩余三个小方块的正确坐标
                //根据第一个方块的坐标进行偏移
                _cubes[i + 1].Pos = _cubes[0].Pos + pos[i];
            }

        }

        //画出方块的方法
        public void Draw()
        {
            for(int i = 0; i < _cubes.Count; i++)
            {
                _cubes[i].Draw();
            }
        }

    }
}
