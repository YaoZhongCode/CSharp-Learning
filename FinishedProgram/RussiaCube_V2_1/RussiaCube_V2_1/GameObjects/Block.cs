using RussiaCube_V2_1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.GameObjects
{
    /// <summary>
    /// 小方块
    /// </summary>
    internal class Block
    {
        public Position Pos { get; set; }
        public TetrominoType Type { get; }

        public Block(Position pos, TetrominoType type)
        {
            Pos = pos;
            Type = type;
        }
    }
}
