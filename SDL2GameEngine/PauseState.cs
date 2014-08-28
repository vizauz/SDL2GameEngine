using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class PauseState : GameState
    {

        //Stack<GameObject> gameObjects = new Stack<GameObject>();

        public override bool OnEnter()
        {
            if (!TextureManager.Instance.Load("assets/menuButton.png", "menu", Game.Instance.Renderer))
                return false;
            if (!TextureManager.Instance.Load("assets/backButton.png", "back", Game.Instance.Renderer))
                return false;

            GameObject menuButton = new MenuButton(new LoaderParams(200, 200, 150, 50, "menu"), MenuButtonCallback);
            GameObject backButton = new MenuButton(new LoaderParams(200, 300, 150, 50, "back"), BackButtonCallback);

            gameObjects.Add(menuButton);
            gameObjects.Add(backButton);

            return true;
        }

        public override bool OnExit()
        {
            TextureManager.Instance.ClearFromTextureMap("menu");
            TextureManager.Instance.ClearFromTextureMap("back");

            return true;
        }

        private void MenuButtonCallback()
        {
            Game.Instance.GSM.PopState();
            Game.Instance.GSM.ChangeState(new MenuState());
        }

        private void BackButtonCallback()
        {
            Game.Instance.GSM.PopState();
        }
    }
}
