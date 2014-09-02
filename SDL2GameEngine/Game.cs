#define DEBUG

using System;
using System.Collections.Generic;
using SDL2;

namespace SDL2GameEngine
{
    class Game
    {
        private bool _running;
        public bool Running { get { return _running; } set { _running = value; } }

        private static readonly Game _instance = new Game();
        public static Game Instance { get { return _instance; } }

        private IntPtr _window = IntPtr.Zero;
        private IntPtr _renderer = IntPtr.Zero;
        private int _height, _width;

        public IntPtr Renderer { get { return _renderer; } }
        public int Width { get { return _width; } private set { _width = value; } }
        public int Height { get { return _height; } private set { _height = value; } }

        private GameStateMachine _gsm = new GameStateMachine();
        public GameStateMachine GSM { get { return _gsm; } }

        public bool Init(string title, int xpos, int ypos, int width, int height, SDL.SDL_WindowFlags flags)
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) == 0)
            {

                Console.WriteLine("sdl init success"); 
                _window = SDL.SDL_CreateWindow(title, xpos, ypos, width, height, flags);
                if (_window != IntPtr.Zero)
                {
                    Console.WriteLine("Window init success"); 
                    _renderer = SDL.SDL_CreateRenderer(_window, -1, 0);

                    if (_renderer != IntPtr.Zero)
                    {
                        Console.WriteLine("Renderer init success"); 
                        SDL.SDL_SetRenderDrawColor(_renderer, 0, 0, 0, 255);

                        GameObjectFactory.Instance.RegisterType("MenuButton", new MenuButtonCreator());
                        GameObjectFactory.Instance.RegisterType("Player", new PlayerCreator());
                        GameObjectFactory.Instance.RegisterType("Enemy", new EnemyCreator());
                        GameObjectFactory.Instance.RegisterType("AnimatedGraphic", new AnimatedGraphicCreator());

                        SDL.SDL_GetWindowSize(_window, out _width, out _height);
                        _gsm.ChangeState(new PlayState());
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
            SDL.SDL_RenderClear(_renderer);

            _gsm.Render();
 
            // draw to the screen
            SDL.SDL_RenderPresent(_renderer);
        }

        public void Update()
        {
            _gsm.Update();
        }

        public void Clean()
        {
            SDL.SDL_DestroyWindow(_window);
            SDL.SDL_DestroyRenderer(_renderer);
            SDL.SDL_Quit();
        }

        public void HandleEvents()
        {
            InputHandler.Instance.Update();
        }
    }
}
