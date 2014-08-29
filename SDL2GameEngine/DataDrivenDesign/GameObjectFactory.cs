using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class GameObjectFactory
    {
        private static readonly GameObjectFactory _instance = new GameObjectFactory();
        public static GameObjectFactory Instance { get { return _instance; } }
        
        Dictionary<string, BaseCreator> creators = new Dictionary<string, BaseCreator>();

        public bool RegisterType(string ID, BaseCreator creator)
        {
            if (!creators.ContainsKey(ID))
            {
                creators[ID] = creator;
                return true;
            }

            return false;
        }

        public GameObject Create(string ID)
        {
            if (creators.ContainsKey(ID))
            {
                BaseCreator creator = creators[ID];
                return creator.CreateGameObject();
            }

            return null;
        }
    }
}
