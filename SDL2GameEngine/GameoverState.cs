using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class GameoverState : GameState
    {
        public override bool OnEnter()
        {
            if (!TextureManager.Instance.Load("assets/againButton.png", "again", Game.Instance.Renderer))
                return false;
            if (!TextureManager.Instance.Load("assets/menuButton.png", "menu", Game.Instance.Renderer))
                return false;
            if (!TextureManager.Instance.Load("assets/gameoverAnim.png", "gameover", Game.Instance.Renderer))
                return false;

            GameObject menuButton = new MenuButton(new LoaderParams(200, 200, 150, 50, "menu"), MenuButtonCallback);
            GameObject againButton = new MenuButton(new LoaderParams(200, 300, 150, 50, "again"), AgainButtonCallback);
            GameObject gameOverAnimation = new AnimatedGraphic(new LoaderParams(200, 100, 150, 30, "gameover"), 3, 2);

            gameObjects.Add(menuButton);
            gameObjects.Add(againButton);
            gameObjects.Add(gameOverAnimation);

            return true;
        }
        public override bool OnExit()
        {
            TextureManager.Instance.ClearFromTextureMap("menu");
            TextureManager.Instance.ClearFromTextureMap("again");
            return true;
        }

        private void MenuButtonCallback()
        {
            Game.Instance.GSM.PopState();
            Game.Instance.GSM.ChangeState(new MenuState());
        }

        private void AgainButtonCallback()
        {
            Game.Instance.GSM.PopState();
            Game.Instance.GSM.ChangeState(new PlayState());
        }
    }
}
