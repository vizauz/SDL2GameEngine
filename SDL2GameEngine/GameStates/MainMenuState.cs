using System;
using System.Collections.Generic;

namespace SDL2GameEngine
{
    class MainMenuState : MenuState
    {
        public MainMenuState()
        {
            StateID = "Menu";
        }

        private void OnEnterPlayState()
        {
            Game.Instance.GSM.ChangeState(new PlayState());
        }

        private void OnExitMenuState()
        {
            Game.Instance.Running = false;
        }

        public override bool OnEnter()
        {
            
            StateParser.ParseState("config.xml", StateID, ref gameObjects, ref textureIDs);

            callbackList.Add(OnEnterPlayState);
            callbackList.Add(OnExitMenuState);

            SetCallbacks(callbackList);
            
            return true;
        }

        public override bool OnExit()
        {
            foreach (string textureId in textureIDs)
            {
                TextureManager.Instance.ClearFromTextureMap(textureId);
            }
            return true;
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
