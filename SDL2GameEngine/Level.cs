using System.Collections.Generic;

namespace SDL2GameEngine
{
    class Level
    {
        public List<Tileset> _tilesets = new List<Tileset>();
        public List<Layer> _layers = new List<Layer>();

        public void Render()
        {
            foreach (Layer l in _layers)
                l.Render();
        }

        public void Update()
        {
            foreach (Layer l in _layers)
                l.Update();
        }
    }
}