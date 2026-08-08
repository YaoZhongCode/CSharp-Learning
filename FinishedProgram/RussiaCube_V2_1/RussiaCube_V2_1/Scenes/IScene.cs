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
    }
}
