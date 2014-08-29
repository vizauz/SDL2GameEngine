using System;

namespace SDL2GameEngine
{
    class LoaderParams
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string  TextureId { get; private set; }
        public int NumOfFrames { get; private set; }
        public int CallbackID { get; private set; }
        public int AnimSpeed { get; private set; }

        public LoaderParams(
            int x, 
            int y, 
            int width, 
            int height, 
            string textureId, 
            int numberOfFrames = 0, 
            int callbackID = 0, 
            int animSpeed = 0)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            TextureId = textureId;
            NumOfFrames = numberOfFrames;
            CallbackID = callbackID;
            AnimSpeed = animSpeed;
        }
    }
}
