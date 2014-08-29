using System;
using OpenTK;
using SDL2;

namespace SDL2GameEngine
{
    abstract class GameObject
    {
        protected string textureId;
        protected int currentRow;
        protected int currentFrame;
        protected int height;
        protected int width;
        protected int numOfFrames;
        protected Vector2d position;
        protected Vector2d velocity;
        protected int animSpeed;
        

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public Vector2d Position { get { return position; } }

        public virtual void Draw(SDL.SDL_RendererFlip flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE)
        {
            TextureManager.Instance.DrawFrame(
                textureId, 
                (int)position.X,
                (int)position.Y,
                width, 
                height, 
                currentRow, 
                currentFrame, 
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
