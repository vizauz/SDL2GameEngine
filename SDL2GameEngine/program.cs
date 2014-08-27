using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDL2;

namespace SDL2GameEngine
{
    class program
    {
        static void Main()
        {

            if (Game.Instance.Init(String.Empty, 805240832, 805240832, 640, 480, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN))
            {
                while (Game.Instance.Running)
                {
                    Game.Instance.HandleEvents();
                    Game.Instance.Update();
                    Game.Instance.Render();
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
