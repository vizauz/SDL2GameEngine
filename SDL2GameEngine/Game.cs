﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDL2;

namespace SDL2GameEngine
{
    class Game
    {
        private int frame;
        private bool _running;
        public bool Running
        {
            get
            {
                return _running;
            }
        }

        private IntPtr window = IntPtr.Zero;
        private IntPtr renderer = IntPtr.Zero;

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


                        TextureManager.Instace.Load("face.png", "face", renderer);
                        TextureManager.Instace.Load("walkingEye.png", "eye", renderer);
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

            TextureManager.Instace.Draw("face", 100, 100, 40, 60, renderer);
            TextureManager.Instace.DrawFrame("eye", 200, 200, 60, 60, 1, frame, renderer);
            TextureManager.Instace.DrawFrame("eye", 270, 200, 60, 60, 1, frame, renderer, SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL);
            
            // draw to the screen
            SDL.SDL_RenderPresent(renderer);
        }

        public void Update()
        {
            frame = (int)(SDL.SDL_GetTicks() / 100) % 8;
        }

        public void Clean()
        {
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_DestroyRenderer(renderer);
            SDL.SDL_Quit();
        }

        public void HandleEvents()
        {
            SDL.SDL_Event _event;

            if (SDL.SDL_PollEvent(out _event) > 0)
            {
                switch (_event.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        _running = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}