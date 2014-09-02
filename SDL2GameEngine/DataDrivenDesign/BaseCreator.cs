using System;

namespace SDL2GameEngine
{
    internal class BaseCreator
    {
        virtual public GameObject CreateGameObject()
        {
            throw new NotImplementedException();
        }
    }
}