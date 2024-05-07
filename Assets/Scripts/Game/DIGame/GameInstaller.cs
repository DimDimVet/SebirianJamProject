using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameExecutor>().To<GameExecutor>().AsSingle().NonLazy();
        }
    }
}

