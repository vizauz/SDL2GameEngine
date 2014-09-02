using System;
using System.Collections.Generic;

namespace SDL2GameEngine
{
    internal class MainMenuState : MenuState
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
            StateParser.ParseState("config.xml", StateID, ref _gameObjects, ref _textureIDs);

            _callbackList.Add(OnEnterPlayState);
            _callbackList.Add(OnExitMenuState);

            SetCallbacks(_callbackList);

            return true;
        }

        public override bool OnExit()
        {
            foreach (string textureId in _textureIDs)
            {
                TextureManager.Instance.ClearFromTextureMap(textureId);
            }
            return true;
        }

        protected override void SetCallbacks(List<Action> callbacks)
        {
            Type menuButtonType = typeof(MenuButton);

            foreach (GameObject item in _gameObjects)
            {
                if (item.GetType() == menuButtonType)
                {
                    MenuButton mb = item as MenuButton;
                    mb.CallbackFunction = _callbackList[mb.CallbackID];
                }
            }
        }
    }
}