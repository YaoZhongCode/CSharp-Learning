using RussiaCube_V2_1.Core;
using RussiaCube_V2_1.GameObjects;
using RussiaCube_V2_1.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Rendering
{
    /// <summary>
    /// 控制台渲染工具
    /// </summary>
    internal static class ConsoleRenderer
    {
        /// <summary>
        /// 绘制最小单位
        /// </summary>
        /// <param name="position">位置</param>
        /// <param name="color">颜色</param>
        public static void DrawBlock(Position position, ConsoleColor color)
        {
            //超出地图上部，不画
            if (position.Y < 0) return;
            //设置对应的屏幕参数
            int screenX = position.X * 2;
            int screenY = position.Y;

            //设置位置和颜色，然后绘制
            Console.SetCursorPosition(screenX, screenY);
            Console.ForegroundColor = color;
            Console.Write("■");
        }

        /// <summary>
        /// 画出方块
        /// </summary>
        /// <param name="tetromino"></param>
        public static void DrawTetromino(Tetromino tetromino)
        {
            foreach(var t in tetromino.Blocks)
            {
                DrawBlock(t.Pos, tetromino.Color);
            }
        }

        /// <summary>
        /// 画棋盘，固定到地图上后，颜色改成暗红色
        /// </summary>
        /// <param name="map">地图信息</param>
        public static void DrawMap(Map map)
        {
            for (int y = map.Height - 1; y >= 0; y--)
            {
                for (int x = 1; x < map.Width; x++)
                {
                    Position pos = new Position(x, y);
                    Block? block = map[pos.X, pos.Y];
                    if (block != null)
                    {
                        DrawBlock(block.Pos, ConsoleColor.DarkRed);
                    }
                    else
                    {
                        ClearBlock(pos);
                    }
                }
            }
        }

        /// <summary>
        /// 擦除方块
        /// </summary>
        /// <param name="position">要擦除的位置</param>
        public static void ClearBlock(Position position)
        {
            int screenX = position.X * 2;
            int screenY = position.Y;
            Console.SetCursorPosition(screenX, screenY);
            Console.Write("  ");
        }
    }
}
