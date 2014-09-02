using System;
using System.Collections.Generic;
using SDL2;

namespace SDL2GameEngine
{
    class Player : SDLGameObject
    {
        public override void Load(LoaderParams _params)
        {
            base.Load(_params);
        }

        public override void Update()
        {
            if (InputHandler.Instance.IsKeyDown(SDL.SDL_Scancode.SDL_SCANCODE_W))
                _position.Y -= 5;
            if (InputHandler.Instance.IsKeyDown(SDL.SDL_Scancode.SDL_SCANCODE_S))
                _position.Y += 5;
            if (InputHandler.Instance.IsKeyDown(SDL.SDL_Scancode.SDL_SCANCODE_A))
                _position.X -= 5;
            if (InputHandler.Instance.IsKeyDown(SDL.SDL_Scancode.SDL_SCANCODE_D))
                _position.X += 5;
        }
    }
}
