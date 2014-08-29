using System;
using System.Collections.Generic;

namespace SDL2GameEngine
{
    abstract class GameState
    {
        public string StateID { get; protected set; }

        public List<GameObject> gameObjects = new List<GameObject>();
        public List<string> textureIDs = new List<string>();

        public virtual void Render()
        {
            foreach (GameObject go in gameObjects)
            {
                go.Draw();
            }
        }
        public virtual void Update()
        {
            foreach (GameObject go in gameObjects)
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
