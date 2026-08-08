using RussiaCube_V2_1.GameObjects;
using RussiaCube_V2_1.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Core
{
    /// <summary>
    /// 方块管理器
    /// </summary>
    internal class TetrominoManager
    {
        //地图
        private readonly Map _map;

        //各种类型的旋转角度信息
        private readonly Dictionary<TetrominoType, TetrominoInfo> _info;

        private Tetromino _currentTetromino;
        public Tetromino CurrentTetromino => _currentTetromino;

        public TetrominoManager(Map map)
        {
            //拿到地图引用
            _map = map;

            //将所有形状的旋转信息存到字典中
            _info = new Dictionary<TetrominoType, TetrominoInfo>()
            {
                { TetrominoType.O, new TetrominoInfo(TetrominoType.O) },
                {TetrominoType.T, new TetrominoInfo(TetrominoType.T) },
                {TetrominoType.I, new TetrominoInfo(TetrominoType.I) },
                {TetrominoType.J, new TetrominoInfo(TetrominoType.J) },
                {TetrominoType.L, new TetrominoInfo(TetrominoType.L) },
                {TetrominoType.S, new TetrominoInfo(TetrominoType.S) },
                {TetrominoType.Z, new TetrominoInfo(TetrominoType.Z) }
            };

            _currentTetromino = new Tetromino(TetrominoType.O);
        }

        public void Spawn()
        {
            //获取一个随机的类型
            TetrominoType type = (TetrominoType)Random.Shared.Next(0, 7);
            _currentTetromino = new Tetromino(type);
            //根据随机到的方块类型，获取对应的旋转信息
            TetrominoInfo info = _info[type];
            //取出第一个旋转信息组
            Position[] pos = info[0];
            //创建出生地点
            Position spawnPosition = new Position(_map.Width / 2, 1);

            //更新每个小方块在地图上的绝对位置
            for (int i = 0; i < _currentTetromino.BlockCount; i++)
            {
                _currentTetromino.Blocks[i].Pos = spawnPosition + pos[i];
            }

        }



    }
}
