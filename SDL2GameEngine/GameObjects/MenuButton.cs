using System;
using OpenTK;

namespace SDL2GameEngine
{
    internal class MenuButton : SDLGameObject
    {
        private enum ButtonState
        {
            MOUSE_OUT = 0,
            MOUSE_OVER = 1,
            CLICKED = 2
        }

        private bool released;

        public int CallbackID { get; private set; }

        public Action CallbackFunction { get; set; }

        public MenuButton()
            : base()
        {
            _currentFrame = (int)ButtonState.MOUSE_OUT;
        }

        public override void Update()
        {
            Vector2d mousePos = InputHandler.Instance.MousePosition;

            if (mousePos.X < _position.X + _width &&
                mousePos.X > _position.X &&
                mousePos.Y < _position.Y + _height &&
                mousePos.Y > _position.Y
                )
            {
                if (InputHandler.Instance.GetMouseButtonState(MouseButtons.LEFT) && released)
                {
                    _currentFrame = (int)ButtonState.CLICKED;

                    CallbackFunction();

                    released = false;
                }
                else if (!InputHandler.Instance.GetMouseButtonState(MouseButtons.LEFT))
                {
                    released = true;
                    _currentFrame = (int)ButtonState.MOUSE_OVER;
                }
            }
            else
            {
                _currentFrame = (int)ButtonState.MOUSE_OUT;
            }
        }

        public override void Load(LoaderParams _params)
        {
            base.Load(_params);
            CallbackID = _params.CallbackID;
        }
    }
}