using Zenject;

namespace MainMenu
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMenuExecutor>().To<MenuExecutor>().AsSingle().NonLazy();
        }
    }
}

