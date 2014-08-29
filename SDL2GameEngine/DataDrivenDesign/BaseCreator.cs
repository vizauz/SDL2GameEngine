using System;

namespace SDL2GameEngine
{
    class BaseCreator
    {
        virtual public GameObject CreateGameObject() { throw new NotImplementedException(); }
    }
}
