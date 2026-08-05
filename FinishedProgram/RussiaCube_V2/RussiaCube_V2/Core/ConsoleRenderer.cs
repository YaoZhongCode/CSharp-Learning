using RussiaCube_V2.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Core
{
    internal static class ConsoleRenderer
    {
        /// <summary>
        /// 在逻辑网格坐标上绘制一个方块
        /// </summary>
        /// <param name="gridPos">目标位置</param>
        /// <param name="color">颜色</param>
        public static void DrawSquare(Position gridPos, ConsoleColor color)
        {
            if (gridPos.Y < 0) return; // 逻辑坐标在屏幕上方时不绘制

            // 转换公式：逻辑 X 坐标乘以 2 对应屏幕坐标
            int screenX = gridPos.X * 2;
            int screenY = gridPos.Y;

            Console.SetCursorPosition(screenX, screenY);
            Console.ForegroundColor = color;
            Console.Write("■");
        }

        /// <summary>
        /// 擦除指定逻辑网格坐标上的内容
        /// </summary>
        /// <param name="gridPos">目标位置</param>
        public static void ClearSquare(Position gridPos)
        {
            if (gridPos.Y < 0) return;

            int screenX = gridPos.X * 2;
            int screenY = gridPos.Y;

            Console.SetCursorPosition(screenX, screenY);
            Console.Write("  ");
        }

        /// <summary>
        /// 在屏幕任意绝对坐标写入文本（主要用于 UI 显示）
        /// </summary>
        /// <param name="screenX">X坐标</param>
        /// <param name="screenY">Y坐标</param>
        /// <param name="text">文本</param>
        /// <param name="color">颜色</param>
        public static void DrawText(int screenX, int screenY, string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(screenX, screenY);
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
