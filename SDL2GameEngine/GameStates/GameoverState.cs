using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDL2GameEngine
{
    class GameoverState : MenuState
    {
        public GameoverState()
        {
            StateID = "Gameover";
        }

        public override bool OnEnter()
        {
            StateParser.ParseState("config.xml", StateID, ref gameObjects, ref textureIDs);

            callbackList.Add(MenuButtonCallback);
            callbackList.Add(AgainButtonCallback);

            SetCallbacks(callbackList);

            return true;
        }
        public override bool OnExit()
        {
            foreach (string textureID  in textureIDs)
            {
                TextureManager.Instance.ClearFromTextureMap(textureID);
            }
            return true;
        }

        private void MenuButtonCallback()
        {
            Game.Instance.GSM.PopState();
            Game.Instance.GSM.ChangeState(new MainMenuState());
        }

        private void AgainButtonCallback()
        {
            Game.Instance.GSM.PopState();
            Game.Instance.GSM.ChangeState(new PlayState());
        }

        protected override void SetCallbacks(List<Action> callbacks)
        {
            Type menuButtonType = typeof(MenuButton);

            foreach (GameObject item in gameObjects)
            {
                if(item.GetType() == menuButtonType)
                {
                    MenuButton mb = item as MenuButton;
                    mb.CallbackFunction = callbackList[mb.callbackID];
                }
            }
        }
    }
}
