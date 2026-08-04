using System;
using System.Collections.Generic;
using System.Text;
using RussiaCube_V1.Core;
using RussiaCube_V1.GameObjects;

namespace RussiaCube_V1.Polymer
{
    enum E_WallType
    {
        Dead,
        Dynamic
    }

    /// <summary>
    /// 游戏主体地图
    /// </summary>
    internal class Map
    {
        //固定的墙壁
        private List<DrawObject> _deadWalls;
        //动态墙壁
        private List<DrawObject> _dynamicWalls;

        

        //供外部获取墙壁长度
        public int DeadWallsLength => _deadWalls.Count;
        public int DynamicWallsLength => _dynamicWalls.Count;

        //记录每一行有多少个小方块：消除方块用
        //索引值就是行号，第0行就是最下方墙壁的上一行
        //每一行满了，就进行消除
        private int[] _mapLines;

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index">索引值</param>
        /// <param name="type">墙壁类型</param>
        /// <returns></returns>
        public DrawObject this[int index, E_WallType type]
        {
            get
            {
                if(type == E_WallType.Dead)
                {
                    return _deadWalls[index];
                }
                else
                {
                    return _dynamicWalls[index];
                }
            }
        }

        public Map()
        {
            _deadWalls = new List<DrawObject>();
            _dynamicWalls = new List<DrawObject>();

            //初始化行号记录器，使其从最下方墙壁的上一行开始记录
            _mapLines = new int[GameConfig.height - 8];

            //竖向墙壁
            for(int i = 0; i < GameConfig.width; i += 2)
            {
                _deadWalls.Add(new DrawObject(E_CubeType.Wall, i, GameConfig.height - 7));
            }

            //构建横向墙壁
            for(int i = 0; i < GameConfig.height - 7; i++)
            {
                _deadWalls.Add(new DrawObject(E_CubeType.Wall, 0, i));
                _deadWalls.Add(new DrawObject(E_CubeType.Wall, GameConfig.width - 2, i));
            }
        }

        /// <summary>
        /// 画出不动的墙壁
        /// </summary>
        public void DrawDeadWall()
        {
            for(int i = 0; i < _deadWalls.Count; i++)
            {
                _deadWalls[i].Draw();
            }
        }

        /// <summary>
        /// 画动态墙壁
        /// </summary>
        public void DrawDynamicWall()
        {
            //里面没有方块，就不画
            if(_dynamicWalls.Count <= 0)
            {
                return;
            }
            for(int i = 0; i < _dynamicWalls.Count; i++)
            {
                _dynamicWalls[i].Draw();
            }
        }

        /// <summary>
        /// 添加动态墙壁
        /// </summary>
        /// <param name="walls">要添加的方块数据</param>
        /// <returns>返回是否已经结束</returns>
        public bool AddDynamicWalls(List<DrawObject> cubes)
        {
            for(int i = 0; i < cubes.Count; i++)
            {
                //先把类型转换为墙壁（主要是颜色区分）
                cubes[i].ChangeType(E_CubeType.Wall);
                _dynamicWalls.Add(cubes[i]); //添加到动态墙壁里面去

                if (cubes[i].Pos.Y == 0)
                {
                    //添加的方块的Y值已经等于0，说明已经顶到最顶部，结束游戏
                    return true;
                } 

                //每次添加动态墙壁，就去更新对应小方块的行里面的计数
                //根据索引来得到对应行
                //以第0行为基础，减去添加的小方块的Y高度，即可获得对应的行数
                _mapLines[GameConfig.height - 8 - cubes[i].Pos.Y] += 1;
            }
            ClearDynamicWalls();
            ClearCube();
            DrawDynamicWall();


            return false;
        }

        /// <summary>
        /// 清除动态墙壁
        /// </summary>
        private void ClearDynamicWalls()
        {
            for(int i = 0; i < _dynamicWalls.Count; i++)
            {
                _dynamicWalls[i].Clear();
            }
        }

        /// <summary>
        /// 消除小方块
        /// </summary>
        private void ClearCube()
        {
            //用以记录待删除的小方块
            List<DrawObject> delCubes = new List<DrawObject>();

            //遍历每一行，检查是否已经填满小方块
            for(int i = 0; i < _mapLines.Length; i++)
            {
                //如果该行里的计数，已经满了，就执行
                //消除这一行的小方块
                //上方小方块下移
                //记录上方小方块的行号计数也对应下移
                //使用地图的宽除以2减去2得到正确的是否已经满了的数量
                if (_mapLines[i] == (GameConfig.width/2) - 2)
                {
                    //遍历动态墙壁
                    for(int j = 0; j < _dynamicWalls.Count; j++)
                    {
                        //如果动态墙壁里当前的小方块的Y坐标与已满的行号一致，说明该小方块需要消除
                        //记录进待删除列表
                        if(i == GameConfig.height - 8 - _dynamicWalls[j].Pos.Y)
                        {
                            //将小方块添加进去待删除列表
                            delCubes.Add(_dynamicWalls[j]);
                        }
                        //如果当前小方块的Y坐标大于当前行号，说明其位于需要消除那一行的上方
                        //将所有位于需要消除那一行上方的小方块下移一格
                        else if(GameConfig.height - 8 - _dynamicWalls[j].Pos.Y > i)
                        {
                            //小方块下移
                            Position temp = new Position(_dynamicWalls[j].Pos.X, _dynamicWalls[j].Pos.Y + 1);
                            _dynamicWalls[j].Pos = temp;
                        }
                    }

                    //从动态墙壁中移除待删除的小方块
                    for(int j = 0; j < delCubes.Count; j++)
                    {
                        _dynamicWalls.Remove(delCubes[j]);
                    }

                    //要消除这一行的上方行数的计数往下迁移
                    for(int j = i; j < _mapLines.Length - 1; j++)
                    {
                        //不停的让前一个等于后一个
                        _mapLines[j] = _mapLines[j + 1];
                    }
                    //清除最后一行的计数，因为它已经向前移动，最后一行是空
                    _mapLines[_mapLines.Length - 1] = 0;

                    //递归调用自己，防止一次性消除多行时，第二行落下后，未被检测到而造成的未消除现象
                    //未被检测到的原因是： 第一行消除后，第二行满的落下去，但是循环里的i已经自增到1，不会再次检测第0行
                    //所以需要递归重新检测消除，如果后面递归没有进入if语句块，那么递归就会结束
                    ClearCube();
                    break;
                }
            }
        }
    }
}
