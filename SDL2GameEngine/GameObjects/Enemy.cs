using System;
using SDL2;

namespace SDL2GameEngine
{
    internal class Enemy : SDLGameObject
    {
        private Random rnd;

        public Enemy()
        {
            rnd = new Random(Environment.TickCount);
        }

        public override void Load(LoaderParams _params)
        {
            base.Load(_params);

            _velocity.X = rnd.Next(-3, 3);
            _velocity.Y = rnd.Next(-3, 3);
        }

        public override void Update()
        {
            _currentFrame = (int)(SDL2.SDL.SDL_GetTicks() / 100 % 8);

            //if (_position.X < 0)
            //    _velocity.X = rnd.Next(1, 3);
            //if (_position.X > 640 - _width)
            //    _velocity.X = -rnd.Next(1, 3);
            //if (_position.Y < 0)
            //    _velocity.Y = rnd.Next(1, 3);
            //if (_position.Y > 480 - _height)
            //    _velocity.Y = -rnd.Next(1, 3);

            //_position.Add(ref _velocity);
        }

        public override void Draw(SDL.SDL_RendererFlip flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE)
        {
            if (_velocity.X > 0)
                base.Draw(flip);
            if (_velocity.X < 0)
                base.Draw(SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL);
        }
    }
}