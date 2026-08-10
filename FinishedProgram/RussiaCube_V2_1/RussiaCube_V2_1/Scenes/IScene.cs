using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2_1.Scenes
{
    /// <summary>
    /// 场景接口
    /// </summary>
    internal interface IScene
    {
        /// <summary>
        /// 进入场景时调用
        /// </summary>
        void Enter();
        /// <summary>
        /// 场景逻辑更新
        /// </summary>
        void Update();
        /// <summary>
        /// 场景渲染
        /// </summary>
        void Render();
        /// <summary>
        /// 退出场景
        /// </summary>
        void Exit();
    }
}
