using System.Collections.Generic;

namespace SDL2GameEngine
{
    class ObjectLayer : Layer
    {
        private List<GameObject> _gameObjects = new List<GameObject>();
        public List<GameObject> GameObjects { get { return _gameObjects; } }

        public override void Render()
        {
            foreach (GameObject go in _gameObjects)
                go.Draw();
        }

        public override void Update()
        {
            foreach (GameObject go in _gameObjects)
                go.Update();
        }
    }
}