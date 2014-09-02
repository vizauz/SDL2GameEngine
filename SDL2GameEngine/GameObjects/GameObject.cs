using System;
using OpenTK;
using SDL2;

namespace SDL2GameEngine
{
    internal abstract class GameObject
    {
        protected string _textureId;
        protected int _currentRow;
        protected int _currentFrame;
        protected int _height;
        protected int _width;
        protected int _numOfFrames;
        protected Vector2d _position;
        protected Vector2d _velocity;
        protected int _animSpeed;

        public int Width { get { return _width; } }

        public int Height { get { return _height; } }

        public Vector2d Position { get { return _position; } }

        public virtual void Draw(SDL.SDL_RendererFlip flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE)
        {
            TextureManager.Instance.DrawFrame(
                _textureId,
                (int)_position.X,
                (int)_position.Y,
                _width,
                _height,
                _currentRow,
                _currentFrame,
                Game.Instance.Renderer,
                flip);
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }

        public virtual void Clean()
        {
            throw new NotImplementedException();
        }

        public virtual void Load(LoaderParams _params)
        {
            throw new NotImplementedException();
        }
    }
}