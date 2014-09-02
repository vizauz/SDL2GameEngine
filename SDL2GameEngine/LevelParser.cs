using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;

namespace SDL2GameEngine
{
    class LevelParser
    {
        private static int _tileSize;
        private static int _width;
        private static int _height;

        public static Level ParseLevel(string levelFile)
        {
            Level level = new Level();

            XDocument doc = null;
            try
            {
                doc = XDocument.Load(levelFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot load file");
                throw;
            }

            Int32.TryParse(doc.Root.Attribute("tilewidth").Value, out _tileSize);
            Int32.TryParse(doc.Root.Attribute("width").Value, out _width);
            Int32.TryParse(doc.Root.Attribute("height").Value, out _height);

            //parse tileset
            var tilesets = from t in doc.Root.Elements().Where(tmp => tmp.Name == "tileset") select t;
            foreach (var tileset in tilesets)
                ParseTileset(tileset, ref level._tilesets);

            // parse any object layer
            var layers = from l in doc.Root.Elements().Where(tmp => tmp.Name == "layer") select l;
            foreach (var layer in layers)
                ParseTileLayer(layer, ref level._layers, ref level._tilesets);

            var properties = from p in doc.Root.Elements().Where(tmp => tmp.Name == "properties") select p;
            foreach (var property in properties)
                ParseTextures(property);

            var objectGroup = doc.Root.Element("objectgroup");
            ParseObjectLayer(objectGroup, ref level._layers);

            return level;
        }

        private static void ParseObjectLayer(XElement objectGroup, ref List<Layer> layers)
        {
            ObjectLayer objLayer = new ObjectLayer();

            var objects = from o in objectGroup.Elements("object") select o;
            foreach (var item in objects)
            {
                int x = 0, y = 0, width = 0, height = 0, numFrames = 0, callbackID = 0, animSpeed = 0;
                string textureID = String.Empty;

                Int32.TryParse(item.Attribute("x").Value, out x);
                Int32.TryParse(item.Attribute("y").Value, out y);

                GameObject gameObject = GameObjectFactory.Instance.Create(item.Attribute("type").Value);

                XElement properties = item.Element("properties");
                foreach (XElement property in properties.Elements("property"))
                {
                    if (property.Attribute("name").Value == "textureHeight")
                    {
                        Int32.TryParse(property.Attribute("value").Value, out height);
                    }
                    if (property.Attribute("name").Value == "textureWidth")
                    {
                        Int32.TryParse(property.Attribute("value").Value, out width);
                    }
                    if (property.Attribute("name").Value == "textureId")
                    {
                        textureID = property.Attribute("value").Value;
                    }
                    if (property.Attribute("name").Value == "animationSpeed")
                    {
                        Int32.TryParse(property.Attribute("value").Value, out animSpeed);
                    }
                    if (property.Attribute("name").Value == "numberOfFrames")
                    {
                        Int32.TryParse(property.Attribute("value").Value, out numFrames);
                    }
                    if (property.Attribute("name").Value == "callbackId")
                    {
                        Int32.TryParse(property.Attribute("value").Value, out callbackID);
                    }
                }

                gameObject.Load(new LoaderParams(x, y, width, height, textureID));
                objLayer.GameObjects.Add(gameObject);
            }

            layers.Add(objLayer);
        }

        private static void ParseTextures(XElement properties)
        {
            var textures = from p in properties.Elements() select p;
            foreach (XElement texture in textures)
            {
                TextureManager.Instance.Load(texture.Attribute("value").Value, texture.Attribute("name").Value, Game.Instance.Renderer);
            }
        }

        private static void ParseTileset(XElement root, ref List<Tileset> tilesets)
        {
            // HACK: hope this will work...
            XElement node = (XElement)root.FirstNode;
            // from el in root.Elements().Where(tmp => tmp.Name == "image") select el;

            TextureManager.Instance.Load(node.Attribute("source").Value, root.Attribute("name").Value, Game.Instance.Renderer);

            Tileset tileset;
            Int32.TryParse(node.Attribute("width").Value, out tileset._width);
            Int32.TryParse(node.Attribute("height").Value, out tileset._height);
            Int32.TryParse(root.Attribute("firstgid").Value, out tileset._firstGridID);
            Int32.TryParse(root.Attribute("tilewidth").Value, out tileset._tileWidth);
            Int32.TryParse(root.Attribute("tileheight").Value, out tileset._tileHeight);
            Int32.TryParse(root.Attribute("margin").Value, out tileset._margin);
            Int32.TryParse(root.Attribute("spacing").Value, out tileset._spacing);
            tileset._name = root.Attribute("name").Value;
            tileset._numColumns = tileset._width / (tileset._tileWidth + tileset._spacing);

            tilesets.Add(tileset);
        }

        private static void ParseTileLayer(XElement root, ref List<Layer> layers, ref List<Tileset> tilesets)
        {
            TileLayer tileLayer = new TileLayer(_tileSize, tilesets);
            //List<List<int>> data = new List<List<int>>();
            int[,] data = new int[_height, _width];
            string decodedIDs = String.Empty;

            // HACK: hope this will work... we got <data>
            XElement node = (XElement)root.FirstNode;
            List<int> uncompressIds = Uncompress(Convert.FromBase64CharArray(node.Value.ToCharArray(), 0, node.Value.Length));

            for (int rows = 0; rows < _height; rows++)
                for (int cols = 0; cols < _width; cols++)
                    data[rows, cols] = uncompressIds[rows * _width + cols];

            tileLayer.SetTileIDs(data);
            layers.Add(tileLayer);
        }

        private static List<int> Uncompress(byte[] byteBuffer)
        {
            List<byte> tmpRes = new List<byte>();

            using (MemoryStream ms = new MemoryStream(byteBuffer))
            {
                using (GZipStream zs = new GZipStream(ms, CompressionMode.Decompress))
                {
                    using (BufferedStream sr = new BufferedStream(zs))
                    {
                        int read;
                        while ((read = sr.ReadByte()) != -1)
                            tmpRes.Add((byte)read);
                    }
                }
            }

            byte[] bytes = tmpRes.ToArray();
            List<int> retResult = new List<int>();

            for (int i = 0; i < bytes.Length - 1; i++)
            {
                if (i % 4 == 0)
                {
                    if (bytes[i + 1] == 1)
                    {
                        retResult.Add(tmpRes[i] + 256);
                        i++;
                    }
                    else
                    {
                        retResult.Add(tmpRes[i]);
                    }
                }
            }

            return retResult;
        }
    }
}