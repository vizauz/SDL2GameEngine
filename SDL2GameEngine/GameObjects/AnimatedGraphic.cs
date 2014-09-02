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
            _currentFrame = (int)((SDL.SDL_GetTicks() / (1000 / _animSpeed)) % _numOfFrames);
        }
    }
}
