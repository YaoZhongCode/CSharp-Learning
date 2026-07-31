using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.GameObjects
{
    /// <summary>
    /// 方块类型
    /// </summary>
    enum E_CubeType
    {
        /// <summary>
        /// 墙壁
        /// </summary>
        Wall,
        /// <summary>
        /// 正方形
        /// </summary>
        Square,
        /// <summary>
        /// 长方形
        /// </summary>
        Rectangle,
        /// <summary>
        /// 坦克头型
        /// </summary>
        Tank,
        /// <summary>
        /// 左梯形
        /// </summary>
        Trapezoid_left,
        /// <summary>
        /// 右梯形
        /// </summary>
        Trapezoid_right,
        /// <summary>
        /// 长左梯形
        /// </summary>
        Trapezoid_long_left,
        /// <summary>
        /// 长右梯形
        /// </summary>
        Trapezoid_long_right,
    }

    /// <summary>
    /// 绘制方块类
    /// </summary>
    internal class DrawObject : IDraw
    {
        private Position _pos;
        private E_CubeType _cubeType;

        public Position Pos { get { return _pos; } set { _pos = value; } }

        //构造函数
        public DrawObject(E_CubeType cubeType)
        {
            _cubeType = cubeType;
        }

        //重载构造函数
        public DrawObject(E_CubeType cubeType, int x, int y) : this(cubeType)
        {
            _pos = new Position(x, y);
        }

        /// <summary>
        /// 绘制方法
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(_pos.X, _pos.Y);
            switch (_cubeType)
            {
                case E_CubeType.Wall:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case E_CubeType.Square:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case E_CubeType.Rectangle:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case E_CubeType.Tank:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case E_CubeType.Trapezoid_left:
                case E_CubeType.Trapezoid_right:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case E_CubeType.Trapezoid_long_left:
                case E_CubeType.Trapezoid_long_right:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }

            Console.Write("■");
        }

        /// <summary>
        /// 改变形状方法
        /// </summary>
        /// <param name="cubeType">目标形状</param>
        public void ChangeType(E_CubeType cubeType)
        {
            _cubeType = cubeType;
        }
    }
}
