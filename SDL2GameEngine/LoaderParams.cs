using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class LoaderParams
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string  TextureId { get; private set; }

        public LoaderParams(int x, int y, int width, int height, string textureId)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            TextureId = textureId;
        }
    }
}
