using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SDL2GameEngine
{
    class StateParser
    {
        static public bool ParseState(string stateFile, string stateID, ref List<GameObject> gameObjects, ref List<string> textureIDs)
        {
            XDocument doc = null;
            try
            {
                doc = XDocument.Load(stateFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot load file");
                throw;
            }

            var state = from s in doc.Root.Elements()
                             .Where(t => t.Attribute("stateID").Value.Equals(stateID))
                        select s;

            var textures = from t in state.Elements()
                               .Where(tmp => tmp.Name == "textures")
                           select t;

            var objects = from o in state.Elements()
                              .Where(tmp => tmp.Name == "objects")
                          select o;

            ParseTextures(textures, ref textureIDs);
            ParseObjects(objects, ref gameObjects);

            return true;
        }

        static void ParseObjects(IEnumerable<XElement> root, ref List<GameObject> result)
        {
            int x, y, width, height, numOfFrames, callbackID, animSpeed;
            string textureID;

            foreach (var item in root.Elements())
            {
                Int32.TryParse(item.Attribute("X").Value, out x);
                Int32.TryParse(item.Attribute("Y").Value, out y);
                Int32.TryParse(item.Attribute("Width").Value, out width);
                Int32.TryParse(item.Attribute("Height").Value, out height);
                Int32.TryParse(item.Attribute("CallbackID").Value, out callbackID);
                Int32.TryParse(item.Attribute("AnimationSpeed").Value, out animSpeed);
                Int32.TryParse(item.Attribute("NumberOfFrames").Value, out numOfFrames);
                textureID = item.Attribute("TextureID").Value;

                GameObject obj = GameObjectFactory.Instance.Create(item.Attribute("Type").Value);
                obj.Load(new LoaderParams(x, y, width, height, textureID, numOfFrames, callbackID, animSpeed));
                result.Add(obj);
            }
        }

        static void ParseTextures(IEnumerable<XElement> root, ref List<string> textureIDs)
        {
            foreach (var item in root.Elements())
            {
                string fileName = item.Attribute("Filename").Value;
                string id = item.Attribute("ID").Value;

                textureIDs.Add(id);
                TextureManager.Instance.Load(fileName, id, Game.Instance.Renderer);
            }
        }
    }
}