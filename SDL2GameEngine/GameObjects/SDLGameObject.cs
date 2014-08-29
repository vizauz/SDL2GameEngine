using System;
using OpenTK;

namespace SDL2GameEngine
{
    class SDLGameObject : GameObject
    {
        public override void Load(LoaderParams _params)
        {
            position = new Vector2d(_params.X, _params.Y);
            velocity = new Vector2d(0, 0);
            position.X = _params.X;
            position.Y = _params.Y;
            width = _params.Width;
            height = _params.Height;
            textureId = _params.TextureId;
            numOfFrames = _params.NumOfFrames;
            animSpeed = _params.AnimSpeed;

            currentFrame = 0;
            currentRow = 1;
        }
    }
}
