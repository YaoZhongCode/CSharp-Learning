using RussiaCube_V1.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Core
{
    //方块信息类
    internal class CubeInfo
    {
        private List<Position[]> _cubeList;

        public CubeInfo(E_CubeType type)
        {
            _cubeList = new List<Position[]>();
            //添加各个方块的各种变形信息坐标
            switch (type)
            {
                case E_CubeType.Square:
                    //创建正方形除了原坐标以外的其他三个方块的坐标
                    Position[] shape = new Position[3] { new Position(2, 0), new Position(0, 1), new Position(2, 1) };
                    _cubeList.Add(shape);
                    break;
                case E_CubeType.Rectangle:
                    //创建长条形除了原坐标以外的其他三个方块的坐标
                    //长条形有四种形状
                    Position[] shape1 = new Position[3] { new Position(0, -1), new Position(0, 1), new Position(0, 2) };
                    Position[] shape2 = new Position[3] { new Position(-4, 0), new Position(-2, 0), new Position(2, 0) };
                    Position[] shape3 = new Position[3] { new Position(0, -2), new Position(0, -1), new Position(0, 1) };
                    Position[] shape4 = new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(4, 0) };
                    _cubeList.AddRange(new List<Position[]>() { shape1, shape2, shape3, shape4 });
                    break;
                case E_CubeType.Tank:
                    shape1 = new Position[3] { new Position(-2, 0), new Position(0, 1), new Position(2, 0) };
                    shape2 = new Position[3] { new Position(0, -1), new Position(-2, 0), new Position(0, 1) };
                    shape3 = new Position[3] { new Position(-2, 0), new Position(0, -1), new Position(2, 0) };
                    shape4 = new Position[3] { new Position(0, -1), new Position(2, 0), new Position(0, 1) };
                    _cubeList.AddRange(new List<Position[]>() { shape1, shape2, shape3, shape4 });
                    break;
                case E_CubeType.Trapezoid_left:
                    shape1 = new Position[3] { new Position(0, -1), new Position(-2, 0), new Position(-2, 1) };
                    shape2 = new Position[3] { new Position(-2, -1), new Position(0, -1), new Position(2, 0) };
                    shape3 = new Position[3] { new Position(2, -1), new Position(2, 0), new Position(0, 1) };
                    shape4 = new Position[3] { new Position(-2, 0), new Position(0, 1), new Position(2, 1) };
                    _cubeList.AddRange(new List<Position[]>() { shape1, shape2, shape3, shape4 });
                    break;
                case E_CubeType.Trapezoid_right:
                    shape1 = new Position[3] { new Position(0, -1), new Position(2, 0), new Position(2, 1) };
                    shape2 = new Position[3] { new Position(-2, 1), new Position(0, 1), new Position(2, 0) };
                    shape3 = new Position[3] { new Position(-2, -1), new Position(-2, 0), new Position(0, 1) };
                    shape4 = new Position[3] { new Position(-2, 0), new Position(0, -1), new Position(2, -1) };
                    _cubeList.AddRange(new List<Position[]>() { shape1, shape2, shape3, shape4 });
                    break;
                case E_CubeType.Trapezoid_long_left:
                    shape1 = new Position[3] { new Position(-2, -1), new Position(0, -1), new Position(0, 1) };
                    shape2 = new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(2, -1) };
                    shape3 = new Position[3] { new Position(0, -1), new Position(0, 1), new Position(2, 1) };
                    shape4 = new Position[3] { new Position(-2, 0), new Position(-2, 1), new Position(2, 0) };
                    _cubeList.AddRange(new List<Position[]>() { shape1, shape2, shape3, shape4 });
                    break;
                case E_CubeType.Trapezoid_long_right:
                    shape1 = new Position[3] { new Position(0, -1), new Position(-2, -1), new Position(0, 1) };
                    shape2 = new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(2, 1) };
                    shape3 = new Position[3] { new Position(0, -1), new Position(0, 1), new Position(-2, 1) };
                    shape4 = new Position[3] { new Position(-2, -1), new Position(-2, 0), new Position(2, 0) };
                    _cubeList.AddRange(new List<Position[]>() { shape1, shape2, shape3, shape4 });
                    break;
            }
        }

        /// <summary>
        /// 索引器，供外部访问存储的坐标信息
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns></returns>
        public Position[] this[int index]
        {
            get
            {
                //超出索引就抛出异常
                if(index < 0 || index >= _cubeList.Count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                return _cubeList[index];
            }
        }

        /// <summary>
        /// 供外部获取有几种方块形态
        /// </summary>
        public int Length => _cubeList.Count;
    }
}
