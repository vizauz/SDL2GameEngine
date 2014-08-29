using SDL2;

namespace SDL2GameEngine
{
    class AnimatedGraphic : SDLGameObject
    {
        public override void Load(LoaderParams _params)
        {
            base.Load(_params);
        }
    
        public override void Update()
        {
            currentFrame = (int)((SDL.SDL_GetTicks() / (1000 / animSpeed)) % numOfFrames);
        }
    }
}
