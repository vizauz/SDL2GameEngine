using System;

namespace SDL2GameEngine
{
    abstract class Layer
    {
        public virtual void Update()
        {
            throw new NotImplementedException();
        }

        public virtual void Render()
        {
            throw new NotImplementedException();
        }
    }
}