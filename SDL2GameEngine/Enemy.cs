using System;
using OpenTK;
using SDL2;

namespace SDL2GameEngine
{
    class Enemy : SDLGameObject
    {

        Vector2d velocity = new Vector2d();

        public Enemy(LoaderParams _params) : base(_params)
        {
            velocity.X = 2;
        }

        public override void Update()
        {
            currentFrame = (int)(SDL2.SDL.SDL_GetTicks() / 100 % 8);

            if (position.X < 0)
                velocity.X = 2;
            if (position.X > 640 - width)
                velocity.X = -2;

            position.Add(ref velocity);
        }

        public override void Draw(SDL.SDL_RendererFlip flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE)
        {
            if (velocity.X > 0)
                base.Draw(flip);
            if (velocity.X < 0)
                base.Draw(SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL);
        }
    }
}
