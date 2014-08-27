using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    abstract class GameObject
    {
        protected string textureId;
        protected int currentRow;
        protected int currentFrame;
        protected int x;
        protected int y;
        protected int height;
        protected int width;

        //public virtual void Load(int x, int y, int width, int height, string textureId)
        //{
        //    this.x = x;
        //    this.y = y;
        //    this.width = width;
        //    this.height = height;
        //    this.textureId = textureId;

        //    this.currentFrame = 0;
        //    this.currentRow = 1;
        //}

        public virtual void Draw()
        {
            TextureManager.Instace.DrawFrame(
                textureId, 
                x, 
                y, 
                width, 
                height, 
                currentRow, 
                currentFrame, 
                Game.Instance.GetRender());
        }
        public virtual void Update() { }
        public virtual void Clean() { }
    }
}
