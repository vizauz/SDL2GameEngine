using SDL2;

namespace SDL2GameEngine
{
    class AnimatedGraphic : SDLGameObject
    {

        // times per second
        private int animSpeed;
        private int numOfFrames;
        public AnimatedGraphic(LoaderParams _params, int animatedSpeed, int numberOfFrames)
            : base(_params)
        {
            animSpeed = animatedSpeed;
            numOfFrames = numberOfFrames;
        }

        public override void Update()
        {
            currentFrame = (int)((SDL.SDL_GetTicks() / (1000 / animSpeed)) % numOfFrames);
        }
    }
}
