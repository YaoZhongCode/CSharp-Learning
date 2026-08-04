using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Scenes
{
    internal interface IScene
    {
        // 1. 进入场景时调用（做初始化，比如清屏、画初始界面）
        void Enter();
        // 2. 每帧更新逻辑（处理业务逻辑、按键检测等）
        void Update();
        // 3. 每帧绘制渲染（只负责画面输出）
        void Render();
        // 4. 退出场景时调用（非常关键！用来清理资源、关闭线程/Task、取消事件订阅）
        void Exit();
    }
}
