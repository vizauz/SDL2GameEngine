using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class MenuState : GameState
    {
        //Stack<GameObject> gameObjects = new Stack<GameObject>();

        public MenuState()
        {
            StateID = "menu";
        }

        public override bool OnEnter()
        {
            Console.WriteLine("Enter menu state");

            if (!TextureManager.Instance.Load("assets/startButton.png", "start", Game.Instance.Renderer))
                return false;

            if (!TextureManager.Instance.Load("assets/exitButton.png", "exit", Game.Instance.Renderer))
                return false;


            GameObject startButton = new MenuButton(new LoaderParams(200, 100, 150, 50, "start"), StartButtonCallback);
            GameObject exitButton = new MenuButton(new LoaderParams(200, 200, 150, 50, "exit"), ExitButtonCallback);

            gameObjects.Add(startButton);
            gameObjects.Add(exitButton);

            return true;
        }

        public override bool OnExit()
        {
            Console.WriteLine("Exit menu state");

            //gameObjects.Clear();

            TextureManager.Instance.ClearFromTextureMap("start");
            TextureManager.Instance.ClearFromTextureMap("exit");

            return true;
        }

        //public override void Render()
        //{
        //    foreach (GameObject go in gameObjects)
        //        go.Draw();
        //}

        //public override void Update()
        //{
        //    foreach (GameObject go in gameObjects)
        //        go.Update();
        //}

        private void ExitButtonCallback() 
        {
            Game.Instance.Running = false;
        }

        private void StartButtonCallback()
        {
            Game.Instance.GSM.ChangeState(new PlayState());
        }
    }
}
