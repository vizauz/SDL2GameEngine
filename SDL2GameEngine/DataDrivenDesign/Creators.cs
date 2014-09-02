namespace SDL2GameEngine
{
    internal class PlayerCreator : BaseCreator
    {
        public override GameObject CreateGameObject()
        {
            return new Player();
        }
    }

    internal class MenuButtonCreator : BaseCreator
    {
        public override GameObject CreateGameObject()
        {
            return new MenuButton();
        }
    }

    internal class AnimatedGraphicCreator : BaseCreator
    {
        public override GameObject CreateGameObject()
        {
            return new AnimatedGraphic();
        }
    }

    internal class EnemyCreator : BaseCreator
    {
        public override GameObject CreateGameObject()
        {
            return new Enemy();
        }
    }
}