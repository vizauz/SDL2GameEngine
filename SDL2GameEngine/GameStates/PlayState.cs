﻿#define DEBUG

using System;

namespace SDL2GameEngine
{
    class PlayState : GameState
    {
        public PlayState()
        {
            StateID = "Play";
        }

        public override bool OnEnter()
        {
            StateParser.ParseState("config.xml", StateID, ref gameObjects, ref textureIDs);

            return true;
        }

        public override bool OnExit()
        {
            foreach (string  textureId in textureIDs)
            {
                TextureManager.Instance.ClearFromTextureMap(textureId);
            }

            return true;
        }

        public override void Update()
        {
            foreach (GameObject go in gameObjects)
                go.Update();

            if (InputHandler.Instance.IsKeyDown(SDL2.SDL.SDL_Scancode.SDL_SCANCODE_ESCAPE))
            {
                Game.Instance.GSM.PushState(new PauseState());
            }

            if (CheckCollision(gameObjects[0], gameObjects[1]))
            {
                Game.Instance.GSM.PopState();
                Game.Instance.GSM.ChangeState(new GameoverState());
            }
        }

        private bool CheckCollision(GameObject a, GameObject b)
        {
            int leftA = (int)a.Position.X;
            int leftB = (int)b.Position.X;
            int rightA = (int)a.Position.X + a.Width;
            int rightB = (int)b.Position.X + b.Width;
            int topA = (int)a.Position.Y;
            int topB = (int )b.Position.Y;
            int bottomA = (int)a.Position.Y + a.Height;
            int bottomB = (int)b.Position.Y + b.Height;

            if (bottomA <= topB) return false;
            if (topA >= bottomB) return false;
            if (leftA >= rightB) return false;
            if (rightA <= leftB) return false;

            return true;
        }
    }
}