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
        private readonly Dictionary<TetrominoType, TetrominoInfo> _infos;

        private Tetromino _currentTetromino;
        public Tetromino CurrentTetromino => _currentTetromino;

        public int LastClearedRows { get; private set; }

        public TetrominoManager(Map map)
        {
            //拿到地图引用
            _map = map;

            //将所有形状的旋转信息存到字典中
            _infos = new Dictionary<TetrominoType, TetrominoInfo>()
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

        /// <summary>
        /// 生成随机方块
        /// </summary>
        public void Spawn()
        {
            //获取一个随机的类型
            TetrominoType type = (TetrominoType)Random.Shared.Next(0, 7);
            //同步当前方块类型
            _currentTetromino = new Tetromino(type);
            //根据随机到的方块类型，获取对应的旋转信息
            TetrominoInfo info = _infos[type];
            //取出第一个旋转信息组
            Position[] pos = info[0];
            //创建出生地点
            Position spawnPosition = new Position(_map.Width / 2, 0);

            //更新每个小方块在地图上的绝对位置
            for (int i = 0; i < _currentTetromino.BlockCount; i++)
            {
                _currentTetromino.Blocks[i].Pos = spawnPosition + pos[i];
            }
        }

        /// <summary>
        /// 是否可以移动
        /// </summary>
        /// <param name="offset">向量</param>
        /// <returns>true=可以移动 false=不能移动</returns>
        private bool CanMove(Position offset)
        {
            //遍历方块的四个小方块
            foreach(var b in _currentTetromino.Blocks)
            {
                Position nextPos = b.Pos + offset;

                //当不在地图内，不能移动
                if (!_map.IsInside(nextPos))
                {
                    return false;
                }

                //如果被占用，不能移动
                if (_map.IsOccupied(nextPos))
                {
                    return false;
                }
            }


            return true;
        }

        /// <summary>
        /// 确认可以移动后，设置到目标位置
        /// </summary>
        /// <param name="offset">偏移</param>
        private void ApplyOffset(Position offset)
        {
            foreach(var b in _currentTetromino.Blocks)
            {
                b.Pos += offset;
            }
        } 

        /// <summary>
        /// 移动方法
        /// </summary>
        /// <param name="offset">偏移</param>
        /// <returns>true=移动成功 false=移动失败</returns>
        public bool Move(Position offset)
        {
            //不能移动，返回false
            if (!CanMove(offset))
            {
                return false;
            }

            //可以移动，设置到目标位置并返回true
            ApplyOffset(offset);
            return true;
        }

        /// <summary>
        /// 方块下落方法
        /// </summary>
        /// <returns>true=下落成功 false=下落失败</returns>
        public bool Fall()
        {
            LastClearedRows = 0;
            //移动失败时
            if(!Move(new Position(0, 1)))
            {
                //固定地图
                LastClearedRows = LockTetromino();
                //返回移动失败

                return false;
            }

            return true;
        }

        /// <summary>
        /// 固定方块并检查消除满行
        /// </summary>
        /// <returns>消除的行数</returns>
        private int LockTetromino()
        {
            _map.PlaceTetromino(_currentTetromino);
            return _map.ClearFullRows();

        }

        /// <summary>
        /// 获取旋转后的绝对位置
        /// </summary>
        /// <param name="rotationIndex">旋转索引</param>
        /// <returns>绝对位置信息组</returns>
        private Position[] GetRotatedPositions(int rotationIndex)
        {
            //拿到当前方块的类型
            TetrominoInfo info = _infos[_currentTetromino.Type];
            //根据拿到的方块的类型获取到旋转状态偏移信息组
            Position[] relativePositions = info[rotationIndex];
            //创建一个临时数组用来存放旋转后的绝对位置坐标
            Position[] newPositions = new Position[_currentTetromino.BlockCount];

            for(int i = 0; i < _currentTetromino.BlockCount; i++)
            {
                //绝对位置=当前方块原点+旋转偏移
                newPositions[i] = _currentTetromino.Position + relativePositions[i];
            }

            //把存了绝对位置坐标的数组返回出去
            return newPositions;
        }

        /// <summary>
        /// 旋转方块
        /// </summary>
        /// <returns>true=旋转成功，false=旋转失败</returns>
        public bool Rotate()
        {
            //拿到当前方块的类型
            TetrominoInfo info = _infos[_currentTetromino.Type];

            //拿到下一个旋转索引（当前旋转+1求余数组长度4，可以保证索引无限循环）
            int nextRotation = (_currentTetromino.RotationIndex + 1) % info.RotationCount;

            //创建一个新的位置数组，拿到下一个旋转索引在地图上的绝对坐标
            Position[] newPositions = GetRotatedPositions(nextRotation);

            //判断这些绝对坐标是否出界或被占用
            foreach(var p in newPositions)
            {
                if (!_map.IsInside(p))
                {
                    //出界返回false
                    return false;
                }
                if (_map.IsOccupied(p))
                {
                    //被占用返回false
                    return false;
                }

            }

            //通过合法性检测，真正更新旋转后的旋转索引和绝对位置
            _currentTetromino.ApplyRotation(nextRotation, newPositions);
            return true;
        }
    }
}
