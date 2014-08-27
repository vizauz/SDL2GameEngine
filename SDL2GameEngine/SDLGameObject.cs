using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class SDLGameObject : GameObject
    {
        public SDLGameObject(LoaderParams _params)
        {
            x = _params.X;
            y = _params.Y;
            width = _params.Width;
            height = _params.Height;
            textureId = _params.TextureId;

            currentFrame = 0;
            currentRow = 1;
        }
    }
}
