using RussiaCube_V2.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Core
{
    /// <summary>
    /// 方块控制类
    /// </summary>
    internal class TetrominoController
    {
        public TetrominoType Type { get; private set; }
        public Position Position { get; private set; }
        public int RotationIndex { get; private set; }
        public ConsoleColor Color { get; private set; }

        public TetrominoController()
        {
            Color = ConsoleColor.Yellow;
        }

        /// <summary>
        /// 生成一个新的下落方块
        /// </summary>
        /// <param name="type">方块类型</param>
        /// <param name="startPos">开始位置</param>
        /// <param name="color">颜色</param>
        public void Spawn(TetrominoType type, Position startPos, ConsoleColor color)
        {
            Type = type;
            Position = startPos;
            Color = color;
            RotationIndex = 0;
        }

        /// <summary>
        /// 获取当前方块包含的4个小方块在地图上的绝对坐标
        /// </summary>
        /// <returns></returns>
        public Position[] GetWorldPositions()
        {
            //根据类型和旋转索引，拿到对应的大方块
            Position[] offsets = TetrominoData.GetOffsets(Type, RotationIndex);
            //创建一个坐标数组用来存储计算出来的绝对坐标
            Position[] worldPositions = new Position[offsets.Length];
            for(int i = 0; i < offsets.Length; i++)
            {
                //遍历后加上当前坐标存入
                worldPositions[i] = offsets[i] + Position;
            }

            return worldPositions;
        }

        /// <summary>
        /// 尝试平移
        /// </summary>
        /// <param name="direction">方向</param>
        /// <param name="map">地图信息</param>
        /// <returns>true表示可以移动，false表示无法移动</returns>
        public bool TryMove(Position direction, GridMap map)
        {
            Position targetPos = Position + direction;
            Position[] offsets = TetrominoData.GetOffsets(Type, RotationIndex);

            //检查移动后的每个小格子是不是合法的
            for(int i = 0; i < offsets.Length; i++)
            {
                Position checkPos = targetPos + offsets[i];

                if (map.IsOccupied(checkPos))
                {
                    //任一小格子被占用，均不允许移动
                    return false;
                }
            }

            Position = targetPos;
            return true;
        }

        /// <summary>
        /// 尝试旋转形态
        /// </summary>
        /// <param name="clockwide">是否顺时针</param>
        /// <param name="map">地图信息</param>
        /// <returns></returns>
        public bool TryRotate(bool clockwide, GridMap map)
        {
            //获取下一个旋转形态的索引
            int nextRotation = RotationIndex + (clockwide ? 1 : -1);
            Position[] nextOffsets = TetrominoData.GetOffsets(Type, nextRotation);

            //遍历所有旋转后的小方块
            for(int i = 0; i < nextOffsets.Length; i++)
            {
                //获得一个临时的世界地图的绝对坐标
                Position checkPos = Position + nextOffsets[i];
                if (map.IsOccupied(checkPos))
                {
                    //任一一个小方块被阻挡，拒绝旋转
                    return false;
                }
            }

            //通过检测后，才进行真的旋转
            RotationIndex = nextRotation;
            return true;
        }

    }
}
