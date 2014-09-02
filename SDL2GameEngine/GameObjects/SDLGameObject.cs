using System;
using OpenTK;

namespace SDL2GameEngine
{
    class SDLGameObject : GameObject
    {
        public override void Load(LoaderParams _params)
        {
            _position = new Vector2d(_params.X, _params.Y);
            _velocity = new Vector2d(0, 0);
            _position.X = _params.X;
            _position.Y = _params.Y;
            _width = _params.Width;
            _height = _params.Height;
            _textureId = _params.TextureId;
            _numOfFrames = _params.NumOfFrames;
            _animSpeed = _params.AnimSpeed;

            _currentFrame = 0;
            _currentRow = 1;
        }
    }
}
