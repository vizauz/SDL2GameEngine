using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class PlayState : GameState
    {

        //Stack<GameObject> gameObjects = new Stack<GameObject>();

        public PlayState()
        {
            StateID = "play";
        }

        public override bool OnEnter()
        {
            Console.WriteLine("Enter play state");
            if (!TextureManager.Instance.Load("assets/face.png", "player", Game.Instance.Renderer))
                return false;

            if (!TextureManager.Instance.Load("assets/walkingEye.png", "enemy", Game.Instance.Renderer))
                return false;

            Player player = new Player(new LoaderParams(100, 100, 40, 60, "player"));
            Enemy enemy = new Enemy(new LoaderParams(100, 200, 60, 60, "enemy"));

            gameObjects.Add(player);
            gameObjects.Add(enemy);

            return true;
        }

        public override bool OnExit()
        {
            Console.WriteLine("Exit play state");
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
