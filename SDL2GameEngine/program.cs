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
            Game game = new Game();

            game.Init(String.Empty, 805240832, 805240832, 640, 480, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            while (game.Running)
            {
                game.HandleEvents();
                game.Render();
            }

            game.Clean();
        }
    }
}
