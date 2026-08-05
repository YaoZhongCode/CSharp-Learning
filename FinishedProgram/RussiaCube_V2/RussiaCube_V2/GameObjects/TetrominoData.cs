using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.GameObjects
{
    /// <summary>
    /// 方块形状数据预设表（纯数据）
    /// </summary>
    internal static class TetrominoData
    {
        //// 存储所有方块数据的字典
        private static readonly Dictionary<TetrominoType, Position[][]> _shapes;

        /// <summary>
        /// 构造函数
        /// </summary>
        static TetrominoData()
        {
            _shapes = new Dictionary<TetrominoType, Position[][]>();

            // 1. 正方形 (O)：只有 1 种形态
            _shapes.Add(TetrominoType.O, new Position[][]
            {
                new Position[]
                {
                    new Position(0, 0), new Position(1, 0), new Position(0, 1), new Position(1, 1)
                }
            });

            //2. 长条形 (I)：4 种形态 (0度, 90度, 180度, 270度)
            _shapes.Add(TetrominoType.I, new Position[][]
            {
                //第一种
                new Position[]
                {
                    new Position(-1, 0), new Position(0, 0), new Position(1, 0), new Position(2, 0)
                },
                //第二种
                new Position[]
                {
                    new Position(0, -1), new Position(0, 0), new Position(0, 1), new Position(0, 2)
                },

                //第三种
                new Position[]
                {
                    new Position(-1, 0), new Position(0, 0), new Position(1, 0), new Position(2, 0)
                },

                //第四种
                new Position[]
                {
                    new Position(0, -1), new Position(0, 0), new Position(0, 1), new Position(0, 2)
                },
            });

            //3. 坦克头/凸字形 (T)：4 种形态
            _shapes.Add(TetrominoType.T, new Position[][]
            {
                //1
                new Position[]
                {
                    new Position(0, 0), new Position(-1, 0), new Position(1, 0), new Position(0, -1)
                },
                //2
                new Position[]
                {
                    new Position(0, 0), new Position(0, -1), new Position(0, 1), new Position(1, 0)
                },
                //3
                new Position[]
                {
                    new Position(0, 0), new Position(-1, 0), new Position(1, 0), new Position(0, 1)
                },
                //4
                new Position[]
                {
                    new Position(0, 0), new Position(0, -1), new Position(0, 1), new Position(-1, 0)
                }
                
            });

            //4 左构形(J)
            _shapes.Add(TetrominoType.J, new Position[][]
            {
                //1
                new Position[]
                {
                    new Position(0, 0), new Position(-1, 0), new Position(0, -1), new Position(0, -2)
                },

                //2
                new Position[]
                {
                    new Position(0, 0), new Position(0, -1), new Position(1, 0), new Position(2, 0)
                },

                //3
                new Position[]
                {
                    new Position(0, 0), new Position(1, 0), new Position(0, 1), new Position(0, 2)
                },

                //4
                new Position[]
                {
                    new Position(0, 0), new Position(0, 1), new Position(-1, 0), new Position(-2, 0)
                }

            });

            //5 右构形(L)
            _shapes.Add(TetrominoType.L, new Position[][]
            {
                //1
                new Position[]
                {
                    new Position(0, 0), new Position(1, 0), new Position(0, -1), new Position(0, -2)
                },

                //2
                new Position[]
                {
                    new Position(0, 0), new Position(0, 1), new Position(1, 0), new Position(2, 0)
                },

                //3
                new Position[]
                {
                    new Position(0, 0), new Position(-1, 0), new Position(0, 1), new Position(0, 2)
                },

                //4
                new Position[]
                {
                    new Position(0, 0), new Position(0, -1), new Position(-1, 0), new Position(-2, 0)
                }

            });

            //6 右梯形(S)
            _shapes.Add(TetrominoType.S, new Position[][]
            {
                //1
                new Position[]
                {
                    new Position(0, 0), new Position(0, -1), new Position(1, 0), new Position(1, 1)
                },

                //2
                new Position[]
                {
                    new Position(0, 0), new Position(1, 0), new Position(0, 1), new Position(-1, 1)
                },

                //3
                new Position[]
                {
                    new Position(0, 0), new Position(0, -1), new Position(1, 0), new Position(1, 1)
                },

                //4
                new Position[]
                {
                    new Position(0, 0), new Position(1, 0), new Position(0, 1), new Position(-1, 1)
                }
                 
            });

            //7左梯形(Z)
            _shapes.Add(TetrominoType.Z, new Position[][]
            {
                //1 
                new Position[]
                {
                    new Position(0, 0), new Position(0, -1), new Position(-1, 0), new Position(-1, 1)
                },

                //2
                new Position[]
                {
                    new Position(0, 0), new Position(-1, 0), new Position(0, 1), new Position(1, 1)
                },

                //3
                new Position[]
                {
                    new Position(0, 0), new Position(0, -1), new Position(-1, 0), new Position(-1, 1)
                },

                //4
                new Position[]
                {
                    new Position(0, 0), new Position(-1, 0), new Position(0, 1), new Position(1, 1)
                }
            });

        }

        /// <summary>
        /// 根据方块类型和索引，获取对应的4个小方块相对坐标
        /// </summary>
        /// <param name="type">方块类型</param>
        /// <param name="rotationIndex">旋转索引</param>
        /// <returns></returns>
        public static Position[] GetOffsets(TetrominoType type, int rotationIndex)
        {
            //查看这个类型存不存在字典中
            if (_shapes.ContainsKey(type))
            {
                //取到键对应的值
                Position[][] rotations = _shapes[type];

                //防止索引越界
                //传入参数超过4，求余旋转坐标数组长度等于0，相当于循环，负数也会被取绝对值
                int safeIndex = Math.Abs(rotationIndex % rotations.Length);
                return rotations[safeIndex];
            }


            //如果没有找到，返回一个空数组
            return new Position[0];
        }

        /// <summary>
        /// 获取某种形态有几个旋转状态
        /// </summary>
        /// <param name="type">方块类型</param>
        /// <returns></returns>
        public static int GetRotationCount(TetrominoType type)
        {
            if (_shapes.ContainsKey(type))
            {
                return _shapes[type].Length;
            }

            return 1;
        }
    }
}
