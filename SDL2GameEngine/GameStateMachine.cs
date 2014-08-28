using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class GameStateMachine
    {

        Stack<GameState> states = new Stack<GameState>();

        public void PushState(GameState state)
        {
            states.Push(state);
            states.Peek().OnEnter();
        }

        public void ChangeState(GameState state)
        {
            if (states.Count > 0)
            {
                if (states.Peek().StateID == state.StateID)
                    return;
                if (states.Peek().OnExit())
                {
                    states.Pop();
                }
            }
            states.Push(state);
            states.Peek().OnEnter();
        }

        public void PopState()
        {
            if (states.Count > 0)
            {
                if (states.Peek().OnExit())
                {
                    states.Pop();
                }
            }
        }

        public void Render()
        {
            if (states.Count > 0)
                states.Peek().Render();
        }

        public void Update()
        {
            if (states.Count > 0)
                states.Peek().Update();
        }
    }
}
