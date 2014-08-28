using System;
using System.Collections.Generic;
using SDL2;

namespace SDL2GameEngine
{
    class Player : SDLGameObject
    {
        public Player(LoaderParams _params) : base(_params) { }

        public override void Update()
        {
            if (InputHandler.Instance.IsKeyDown(SDL.SDL_Scancode.SDL_SCANCODE_W))
                position.Y -= 5;
            if (InputHandler.Instance.IsKeyDown(SDL.SDL_Scancode.SDL_SCANCODE_S))
                position.Y += 5;
            if (InputHandler.Instance.IsKeyDown(SDL.SDL_Scancode.SDL_SCANCODE_A))
                position.X -= 5;
            if (InputHandler.Instance.IsKeyDown(SDL.SDL_Scancode.SDL_SCANCODE_D))
                position.X += 5;
        }
    }
}
