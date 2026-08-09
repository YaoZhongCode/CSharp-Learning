using RussiaCube_V2_1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.GameObjects
{
    /// <summary>
    /// 游戏主角！俄罗斯方块
    /// </summary>
    internal class Tetromino
    {
        //内部集合
        private readonly List<Block> _blocks;

        public int BlockCount => _blocks.Count;

        //供外部只读取，无法修改
        public IReadOnlyList<Block> Blocks => _blocks;

        //方块类型
        public TetrominoType Type { get; }

        //当前方块的绝对位置（地图上）
        public Position Position { get; private set; }

        //当前方块的旋转索引
        public int RotationIndex { get; private set; }

        public Tetromino(TetrominoType type)
        {
            Type = type;

            //初始化方块
            _blocks = new List<Block>()
            {
                new Block(new Position(0, 0), type),
                new Block(new Position(0, 0), type),
                new Block(new Position(0, 0), type),
                new Block(new Position(0, 0), type)
            };
        }

        /// <summary>
        /// 应用旋转索引并修改位置
        /// </summary>
        /// <param name="rotationIndex">目标旋转索引</param>
        /// <param name="newPositions">目标绝对位置</param>
        public void ApplyRotation(int rotationIndex, Position[] newPositions)
        {
            RotationIndex = rotationIndex;
            for(int i = 0; i < Blocks.Count; i++)
            {
                Blocks[i].Pos = newPositions[i];
            }
        }
    }
}
