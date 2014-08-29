namespace SDL2GameEngine
{
    class PlayerCreator : BaseCreator
    {
        public override GameObject CreateGameObject()
        {
            return new Player();
        }
    }

    class MenuButtonCreator : BaseCreator
    {
        public override GameObject CreateGameObject()
        {
            return new MenuButton();
        }
    }

    class AnimatedGraphicCreator : BaseCreator
    {
        public override GameObject CreateGameObject()
        {
            return new AnimatedGraphic();
        }
    }

    class EnemyCreator : BaseCreator
    {
        public override GameObject CreateGameObject()
        {
            return new Enemy();
        }
    }
}
