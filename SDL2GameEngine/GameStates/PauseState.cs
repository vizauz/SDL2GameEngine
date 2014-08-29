using System;
using System.Collections.Generic;

namespace SDL2GameEngine
{
    class PauseState : MenuState
    {
        public PauseState()
        {
            StateID = "Pause";
        }

        public override bool OnEnter()
        {
            StateParser.ParseState("config.xml", StateID, ref gameObjects, ref textureIDs);

            callbackList.Add(MenuButtonCallback);
            callbackList.Add(BackButtonCallback);

            SetCallbacks(callbackList);
       
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
            Game.Instance.GSM.ChangeState(new MainMenuState());
        }

        private void BackButtonCallback()
        {
            Game.Instance.GSM.PopState();
        }

        protected override void SetCallbacks(List<Action> callbacks)
        {
            Type menuButtonType = typeof(MenuButton);

            foreach (GameObject item in gameObjects)
            {
                if (item.GetType() == menuButtonType)
                {
                    MenuButton mb = item as MenuButton;
                    mb.CallbackFunction = callbackList[mb.callbackID];
                }
            }
        }
    }
}
