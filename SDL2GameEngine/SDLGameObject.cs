using System;
using OpenTK;

namespace SDL2GameEngine
{
    class SDLGameObject : GameObject
    {
        

        public SDLGameObject(LoaderParams _params)
        {
            position.X = _params.X;
            position.Y = _params.Y;
            width = _params.Width;
            height = _params.Height;
            textureId = _params.TextureId;

            currentFrame = 0;
            currentRow = 1;
        }
    }
}
