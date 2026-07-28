using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Scenes
{
    //场景接口，方便管理切换场景
    internal interface IScene
    {
        //初始化场景方法
        void Enter();

        //场景更新方法
        IScene? Update();
    }
}
