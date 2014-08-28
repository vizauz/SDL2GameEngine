using System;
using OpenTK;

namespace SDL2GameEngine
{
    class MenuButton : SDLGameObject
    {
        enum ButtonState
        {
            MOUSE_OUT = 0,
            MOUSE_OVER = 1,
            CLICKED = 2
        }

        bool released;
        Action callbackFunction;

        public MenuButton(LoaderParams _params, Action callback) 
            : base(_params) 
        { 
            currentFrame = (int)ButtonState.MOUSE_OUT;
            callbackFunction = callback;
        }

        public override void Update()
        {
            Vector2d mousePos = InputHandler.Instance.MousePosition;

            if (mousePos.X < position.X + width &&
                mousePos.X > position.X &&
                mousePos.Y < position.Y + height &&
                mousePos.Y > position.Y
                )
            {
                if (InputHandler.Instance.GetMouseButtonState(MouseButtons.LEFT) && released)
                {
                    currentFrame = (int)ButtonState.CLICKED;

                    callbackFunction();

                    released = false;
                }
                else if (!InputHandler.Instance.GetMouseButtonState(MouseButtons.LEFT))
                {
                    released = true;
                    currentFrame = (int)ButtonState.MOUSE_OVER;
                }
            }
            else
            {
                currentFrame = (int)ButtonState.MOUSE_OUT;  
            }
        }
    }
}
