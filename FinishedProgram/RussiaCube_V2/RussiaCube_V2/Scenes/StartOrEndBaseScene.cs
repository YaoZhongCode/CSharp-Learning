using RussiaCube_V2.Core;
using RussiaCube_V2.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V2.Scenes
{
    internal abstract class StartOrEndBaseScene : IScene
    {
        protected string _title;
        protected List<string> _options;
        protected int _nowSelectId;
        protected InputManager _inputManager;
        protected IScene? _nextScene;

        public StartOrEndBaseScene()
        {
            _nextScene = null;
            _nowSelectId = 0;
            _inputManager = new InputManager();
            _title = "";
            _options = new List<string>();
        }

        public virtual void Enter()
        {
            Console.Clear();

            _inputManager.StartListening();
            _inputManager.OnKeyPressed += OnKeyPress;
        }

        public void Exit()
        {
            _inputManager.StopListening();
            _inputManager.OnKeyPressed -= OnKeyPress;
            
        }

        public virtual void Render()
        {
            //绘制标题
            ConsoleRenderer.DrawText(4, 2, _title, ConsoleColor.Yellow);
            for(int i = 0; i < _options.Count; i++)
            {
                string prefix = (_nowSelectId == i) ? ">" : " ";
                ConsoleColor color = (_nowSelectId == i) ? ConsoleColor.Red : ConsoleColor.White;
                string textDraw = prefix + _options[i];
                int drawY = 4 + i * 2;
                ConsoleRenderer.DrawText(4, drawY, textDraw, color);
            }
        }

        public abstract IScene? Update();

        private void OnKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    _nowSelectId--;
                    if (_nowSelectId < 0) _nowSelectId = 0;
                    break;
                case ConsoleKey.S:
                    _nowSelectId++;
                    if (_nowSelectId >= _options.Count) _nowSelectId = _options.Count - 1;
                    break;
                case ConsoleKey.Enter:
                    OnOptionSelected(_nowSelectId);
                    break;
            }
        }

        protected abstract void OnOptionSelected(int selectedIndex);
    }
}
