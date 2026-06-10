using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChessV2_0.Core
{
    public interface IScene
    {
        //切换场景后先调用，初始化场景
        void Enter();

        //定义一个返回场景的帧更新方法
        IScene? Update();
    }
}
