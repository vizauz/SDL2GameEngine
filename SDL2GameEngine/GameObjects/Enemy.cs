using System;
using OpenTK;
using SDL2;

namespace SDL2GameEngine
{
    class Enemy : SDLGameObject
    {

        Random rnd = new Random();

        public override void Load(LoaderParams _params)
        {
            base.Load(_params);

            velocity.X = rnd.Next(-3, 3);
            velocity.Y = rnd.Next(-3, 3);
        }

        public override void Update()
        {
            currentFrame = (int)(SDL2.SDL.SDL_GetTicks() / 100 % 8);

            if (position.X < 0)
                velocity.X = rnd.Next(1, 3);
            if (position.X > 640 - width)
                velocity.X = -rnd.Next(1, 3);
            if (position.Y < 0)
                velocity.Y = rnd.Next(1, 3);
            if (position.Y > 480 - height)
                velocity.Y = -rnd.Next(1, 3);

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
