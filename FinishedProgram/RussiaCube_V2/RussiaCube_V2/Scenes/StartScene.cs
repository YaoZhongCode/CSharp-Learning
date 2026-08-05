using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Scenes
{
    internal class StartScene : StartOrEndBaseScene
    {
        public StartScene() : base()
        {
            _title = "俄罗斯方块";
            _options.Add("开始游戏");
            _options.Add("结束游戏");
        }

        public override IScene? Update()
        {
            return _nextScene;
        }

        protected override void OnOptionSelected(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    _nextScene = new GameScene();
                    break;
                case 1:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
