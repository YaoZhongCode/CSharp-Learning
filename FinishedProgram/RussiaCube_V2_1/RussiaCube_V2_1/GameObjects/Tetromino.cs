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
    }
}
