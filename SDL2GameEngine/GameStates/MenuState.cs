using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
