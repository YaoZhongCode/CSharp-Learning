using RussiaCube_V1.GameObjects;
using RussiaCube_V1.Polymer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Core
{
    /// <summary>
    /// 移动方向
    /// </summary>
    enum E_MoveDirection
    {
        Left,
        Right
    }

    /// <summary>
    /// 变形方向
    /// </summary>
    enum E_SwitchDirection
    {
        Left,
        Right
    }

    /// <summary>
    /// 管理方块的主要类
    /// </summary>
    internal class CubeManager : IDraw
    {
        //存储四个小方块：所有方块类型都是由四个小方块组成
        private List<DrawObject> _cubes;
        //使用字典存储所有方块类型信息
        private Dictionary<E_CubeType, CubeInfo> _cubeInfoDic;
        //存储当前方块的信息
        private CubeInfo _nowCubeInfo;
        private int _nowShapeIndex;

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
            _nowShapeIndex= Random.Shared.Next(0, _nowCubeInfo.Length);
            //获取其中一种形态的坐标信息
            Position[] pos = _nowCubeInfo[_nowShapeIndex];
            for(int i = 0; i < pos.Length; i++)
            {
                //依次设定剩余三个小方块的正确坐标
                //根据第一个方块的坐标进行偏移
                _cubes[i + 1].Pos = _cubes[0].Pos + pos[i];
            }

        }

        /// <summary>
        /// 擦除方块
        /// </summary>
        private void Clear()
        {
            //改变之前先擦掉之前的形状
            for (int i = 0; i < _cubes.Count; i++)
            {
                _cubes[i].Clear();
            }
        }

        /// <summary>
        /// 画出方块的方法
        /// </summary>
        public void Draw()
        {
            for(int i = 0; i < _cubes.Count; i++)
            {
                _cubes[i].Draw();
            }
        }

        /// <summary>
        /// 切换方块形状：四个形状
        /// </summary>
        /// <param name="direction">改变方向</param>
        /// <param name="map">地图信息</param>
        public void SwitchShape(E_SwitchDirection direction, Map map)
        {
            //先检查是否可以改变形态
            if(!IsCanSwitch(direction, map))
            {
                //如果不能改变形态，就返回掉方法
                return;
            }

            Clear();

            switch (direction)
            {
                case E_SwitchDirection.Left:
                    _nowShapeIndex--;
                    //当当前的形状索引小于0，让其变成4个形状中的最后一个，实现循环
                    if (_nowShapeIndex < 0) _nowShapeIndex = _nowCubeInfo.Length - 1;
                    break;
                case E_SwitchDirection.Right:
                    //让当前形状索引往后加，超出长度后回到0索引，实现循环
                    _nowShapeIndex++;
                    if (_nowShapeIndex >= _nowCubeInfo.Length) _nowShapeIndex = 0;
                    break;
            }

            Position[] pos = _nowCubeInfo[_nowShapeIndex];
            for(int i = 0; i < pos.Length; i++)
            {
                _cubes[i + 1].Pos = _cubes[0].Pos + pos[i];
            }

            Draw();
        }

        /// <summary>
        /// 检查是否可以切换形状：避免与墙壁或动态墙壁重合
        /// </summary>
        /// <param name="direction">方向</param>
        /// <param name="map">地图信息</param>
        /// <returns></returns>
        private bool IsCanSwitch(E_SwitchDirection direction, Map map)
        {
            //先模拟一遍是否可以切换
            //用一个临时索引记录，不影响真正的索引
            int _tempIndex = _nowShapeIndex;
            switch (direction)
            {
                case E_SwitchDirection.Left:
                    _tempIndex--;
                    //当当前的形状索引小于0，让其变成4个形状中的最后一个，实现循环
                    if (_tempIndex < 0) _tempIndex = _nowCubeInfo.Length - 1;
                    break;
                case E_SwitchDirection.Right:
                    //让当前形状索引往后加，超出长度后回到0索引，实现循环
                    _tempIndex++;
                    if (_tempIndex >= _nowCubeInfo.Length) _tempIndex = 0;
                    break;
            }

            //获取所有小方块的对应偏移坐标
            Position[] pos = _nowCubeInfo[_tempIndex];
            Position tempPos;

            //遍历所有小方块
            for (int i = 0; i < pos.Length; i++)
            {
                //获取偏移后的坐标
                tempPos = _cubes[i + 1].Pos + pos[i];

                //检查是否和墙壁重合，重合就返回false
                for (int j =0; j < map.DeadWallsLength; j++)
                {
                    if (tempPos.Equals(map[j, E_WallType.Dead]))
                    {
                        return false;
                    }
                }
                //检查是否和动态墙壁重合，重合就返回false
                for (int j = 0; j < map.DynamicWallsLength; j++)
                {
                    if (tempPos.Equals(map[j, E_WallType.Dynamic]))
                    {
                        return false;
                    }
                }
            }



            return true;
        }

        /// <summary>
        /// 方块左右移动方法
        /// </summary>
        /// <param name="direction">移动方向</param>
        public void MoveLeftOrRight(E_MoveDirection direction)
        {
            //动之前先擦除自己，避免留下残影
            Clear();

            //创建一个目标移动位置
            //通过传入的移动方向，配合三目运算符决定是向左还是向右
            Position newPos = new Position(direction == E_MoveDirection.Left ? -2 : 2, 0);

            //遍历所有小方块，并改变它们的X坐标
            for(int i = 0; i < _cubes.Count; i++)
            {
                //逐个移动
                _cubes[i].Pos += newPos;
            }

            Draw();
        }
    }
}
