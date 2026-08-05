using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Scenes
{
    internal class EndScene : StartOrEndBaseScene
    {
        public EndScene() : base()
        {
            _title = "游戏已终结";
            _options.Add("回主菜单");
            _options.Add("退出游戏");
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
                    _nextScene = new StartScene();
                    break;
                case 1:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
