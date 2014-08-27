using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDL2;

namespace SDL2GameEngine
{
    class Game
    {

        List<SDLGameObject> gameObjs = new List<SDLGameObject>();
        SDLGameObject player;
        SDLGameObject enemy1;
        SDLGameObject enemy2;
        SDLGameObject enemy3;

        private bool _running;

        public bool Running
        {
            get { return _running; }
            set { _running = value; }
        }

        private static readonly Game _instance = new Game();
        public static Game Instance { get { return _instance; } }

        private IntPtr window = IntPtr.Zero;
        private IntPtr renderer = IntPtr.Zero;

        public IntPtr GetRender() { return renderer; }

        public bool Init(string title, int xpos, int ypos, int width, int height, SDL.SDL_WindowFlags flags)
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) == 0)
            {
                Console.WriteLine("sdl init success");
                window = SDL.SDL_CreateWindow(title, xpos, ypos, width, height, flags);
                if (window != IntPtr.Zero)
                {
                    Console.WriteLine("Window init success");
                    renderer = SDL.SDL_CreateRenderer(window, -1, 0);

                    if (renderer != IntPtr.Zero)
                    {
                        Console.WriteLine("Renderer init success");
                        SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);


                        TextureManager.Instace.Load("face.png", "man", renderer);
                        TextureManager.Instace.Load("walkingEye.png", "enemy", renderer);

                        player = new LegoMan(new LoaderParams(100, 100, 40, 60, "man"));
                        enemy1 = new Enemy(new LoaderParams(200, 50, 60, 60, "enemy"));
                        enemy2 = new Enemy(new LoaderParams(200, 120, 60, 60, "enemy"));
                        enemy3 = new Enemy(new LoaderParams(200, 200, 60, 60, "enemy"));

                        

                        gameObjs.Add(player);
                        gameObjs.Add(enemy1);
                        gameObjs.Add(enemy2);
                        gameObjs.Add(enemy3);
                    }
                    else
                    {
                        Console.WriteLine("Renderer init fail");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Window init fail");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("SDL init fail");
                return false;
            }

            _running = true;
            return true;
        }

        public void Render()
        {
            // clear renderer to draw color
            SDL.SDL_RenderClear(renderer);

            foreach (GameObject go in gameObjs)
            {
                go.Draw();
            }
            
            // draw to the screen
            SDL.SDL_RenderPresent(renderer);
        }

        public void Update()
        {
            foreach (GameObject go in gameObjs)
            {
                go.Update();
            }
        }

        public void Clean()
        {
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_DestroyRenderer(renderer);
            SDL.SDL_Quit();
        }

        public void HandleEvents()
        {
            InputHandler.Instance.Update();
        }
    }
}
