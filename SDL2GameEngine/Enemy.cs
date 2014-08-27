using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class Enemy : SDLGameObject
    { 
        public Enemy(LoaderParams _params) : base(_params)
        {

        }

        public override void Update()
        {
            currentFrame = (int)(SDL2.SDL.SDL_GetTicks() / 100 % 8);
        }
    }
}
