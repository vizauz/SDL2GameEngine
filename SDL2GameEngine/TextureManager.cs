using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDL2;


namespace SDL2GameEngine
{
    class TextureManager
    {
        private static readonly TextureManager _instance = new TextureManager();
        public static TextureManager Instace { get { return _instance; } }

        Dictionary<string, IntPtr> textureMap = new Dictionary<string, IntPtr>();

        public bool Load(string fileName, string id, IntPtr renderer)
        {
            IntPtr tmpSurface = SDL_image.IMG_Load(fileName);
            if (tmpSurface == IntPtr.Zero)
            {
                return false;
            }

            IntPtr texture = SDL.SDL_CreateTextureFromSurface(renderer, tmpSurface);
            SDL.SDL_FreeSurface(tmpSurface);

            if (texture != IntPtr.Zero)
            {
                textureMap[id] = texture;
                return true;
            }

            return true;
        }

        public void Draw(string id, int x, int y, int w, int h, IntPtr renderer, SDL.SDL_RendererFlip flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE)
        {
            SDL.SDL_Rect srcRect;
            SDL.SDL_Rect destRect;

            srcRect.x = 0;
            srcRect.y = 0;
            srcRect.w = destRect.w = w;
            srcRect.h = destRect.h = h;
            destRect.x = x;
            destRect.y = y;

            SDL.SDL_Point center;
            center.x = 0;
            center.y = 0;

                SDL.SDL_RenderCopyEx(renderer, textureMap[id], ref srcRect, ref destRect, 0, ref center, flip);
        }

        public void DrawFrame(string id, int x, int y, int w, int h, int currentRow, int currentFrame, IntPtr renderer, SDL.SDL_RendererFlip flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE)
        {
            SDL.SDL_Rect srcRect;
            SDL.SDL_Rect destRect;
            
            srcRect.x = w * currentFrame;
            srcRect.y = h * (currentRow - 1);
            srcRect.w = destRect.w = w; 
            srcRect.h = destRect.h = h;
            destRect.x = x;
            destRect.y = y;

            SDL.SDL_Point center;
            center.x = 0;
            center.y = 0;

            SDL.SDL_RenderCopyEx(renderer, textureMap[id], ref srcRect, ref destRect, 0, ref center, flip);
        }
    }
}
