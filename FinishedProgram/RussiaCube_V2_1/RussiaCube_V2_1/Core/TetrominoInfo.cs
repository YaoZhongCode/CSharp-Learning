using RussiaCube_V2_1.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Core
{
    /// <summary>
    /// 记录不同形态的方块的旋转坐标
    /// </summary>
    internal class TetrominoInfo
    {
        private readonly List<Position[]> _rotationStates;

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns>存储着4个小方块相对坐标的位置数组</returns>
        public Position[] this[int index]
        {
            get
            {
                return _rotationStates[index];
            }
        }

        /// <summary>
        /// 集合元素有几个
        /// </summary>
        public int RotationCount => _rotationStates.Count;

        public TetrominoInfo(TetrominoType type)
        {
            if(type == TetrominoType.O)
            {
                //如果是四方形，只有一种旋转形态
                _rotationStates = new List<Position[]>()
                {
                    new Position[]
                    {
                        new Position(0, 0),
                        new Position(-1, 0),
                        new Position(-1, 1),
                        new Position(0, 1)
                    }
                };
                return;
            }

            //其他六种方块都有四个旋转形态
            _rotationStates = new List<Position[]>();
            switch (type)
            {
                case TetrominoType.T:
                    _rotationStates.Add(new Position[]
                    {
                        //第一种形态
                        new Position(0, 0), new Position(-1, 0), new Position(0, -1), new Position(0, 1)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第二种形态
                        new Position(0, 0), new Position(0, -1), new Position(-1, 0), new Position(1, 0)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第三种形态
                        new Position(0, 0), new Position(0, 1), new Position(-1, 0), new Position(1, 0)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第四种形态
                        new Position(0, 0), new Position(1, 0), new Position(0, -1), new Position(0, 1)
                    });
                    break;
                case TetrominoType.I:
                    _rotationStates.Add(new Position[]
                    {
                        //第一种形态
                        new Position(0, 0), new Position(0, -1), new Position(0, 1), new Position(0, 2)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第二种形态
                        new Position(0, 0), new Position(-1, 0), new Position(1, 0), new Position(2, 0)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第三种形态
                        new Position(0, 0), new Position(0, -1), new Position(0, 1), new Position(0, 2)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第四种形态
                        new Position(0, 0), new Position(-1, 0), new Position(1, 0), new Position(2, 0)
                    });
                    break;
                case TetrominoType.J:
                    _rotationStates.Add(new Position[]
                   {
                        //第一种形态
                        new Position(0, 0), new Position(-1, 0), new Position(0, -1), new Position(0, -2)
                   });
                    _rotationStates.Add(new Position[]
                    {
                        //第二种形态
                        new Position(0, 0), new Position(0, -1), new Position(1, 0), new Position(2, 0)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第三种形态
                        new Position(0, 0), new Position(1, 0), new Position(0, 1), new Position(0, 2)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第四种形态
                        new Position(0, 0), new Position(0, 1), new Position(-1, 0), new Position(-2, 0)
                    });
                    break;
                case TetrominoType.L:
                    _rotationStates.Add(new Position[]
                   {
                        //第一种形态
                        new Position(0, 0), new Position(1, 0), new Position(0, -1), new Position(0, -2)
                   });
                    _rotationStates.Add(new Position[]
                    {
                        //第二种形态
                        new Position(0, 0), new Position(0, 1), new Position(1, 0), new Position(2, 0)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第三种形态
                        new Position(0, 0), new Position(-1, 0), new Position(0, 1), new Position(0, 2)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第四种形态
                        new Position(0, 0), new Position(0, -1), new Position(-1, 0), new Position(-2, 0)
                    });
                    break;
                case TetrominoType.S:
                    _rotationStates.Add(new Position[]
                   {
                        //第一种形态
                        new Position(0, 0), new Position(0, -1), new Position(1, 0), new Position(1, 1)
                   });
                    _rotationStates.Add(new Position[]
                    {
                        //第二种形态
                        new Position(0, 0), new Position(1, 0), new Position(0, 1), new Position(-1, 1)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第三种形态
                        new Position(0, 0), new Position(0, -1), new Position(1, 0), new Position(1, 1)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第四种形态
                        new Position(0, 0), new Position(1, 0), new Position(0, 1), new Position(-1, 1)
                    });
                    break;
                case TetrominoType.Z:
                    _rotationStates.Add(new Position[]
                   {
                        //第一种形态
                        new Position(0, 0), new Position(0, -1), new Position(-1, 0), new Position(-1, 1)
                   });
                    _rotationStates.Add(new Position[]
                    {
                        //第二种形态
                        new Position(0, 0), new Position(-1, 0), new Position(0, 1), new Position(1, 1)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第三种形态
                        new Position(0, 0), new Position(0, -1), new Position(-1, 0), new Position(-1, 1)
                    });
                    _rotationStates.Add(new Position[]
                    {
                        //第四种形态
                        new Position(0, 0), new Position(-1, 0), new Position(0, 1), new Position(1, 1)
                    });
                    break;
            }
        }

    }
}
