using System;
using System.Collections.Generic;

namespace SDL2GameEngine
{
    class MenuState : GameState
    {
        protected List<Action> _callbackList = new List<Action>();

        protected virtual void SetCallbacks(List<Action> callbacks)
        {
            throw new NotImplementedException();
        }
    }
}