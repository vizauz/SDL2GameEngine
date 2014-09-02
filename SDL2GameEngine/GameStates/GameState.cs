using System;
using System.Collections.Generic;

namespace SDL2GameEngine
{
    internal abstract class GameState
    {
        public string StateID { get; protected set; }

        public List<GameObject> _gameObjects = new List<GameObject>();
        public List<string> _textureIDs = new List<string>();

        public virtual void Render()
        {
            foreach (GameObject go in _gameObjects)
            {
                go.Draw();
            }
        }

        public virtual void Update()
        {
            foreach (GameObject go in _gameObjects)
            {
                go.Update();
            }
        }

        public virtual bool OnEnter()
        {
            throw new NotImplementedException();
        }

        public virtual bool OnExit()
        {
            throw new NotImplementedException();
        }
    }
}