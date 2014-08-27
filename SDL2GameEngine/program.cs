using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDL2;

namespace SDL2GameEngine
{
    class program
    {
        const int FPS = 60;
        const int DELAY_TIME = (int)1000.0 / FPS;

        static void Main()
        {

            UInt32 frameStart, frameTime;

            if (Game.Instance.Init(String.Empty, 805240832, 805240832, 640, 480, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN))
            {
                while (Game.Instance.Running)
                {
                    frameStart = SDL.SDL_GetTicks();

                    Game.Instance.HandleEvents();
                    Game.Instance.Update();
                    Game.Instance.Render();

                    frameTime = SDL.SDL_GetTicks() - frameStart;

                    if (frameTime < DELAY_TIME)
                    {
                        SDL.SDL_Delay((uint)(DELAY_TIME - frameTime));
                    }
                }
            }
            else
            {
                Console.WriteLine("Game init failure");
            }

            Game.Instance.Clean();
        }
    }
}
