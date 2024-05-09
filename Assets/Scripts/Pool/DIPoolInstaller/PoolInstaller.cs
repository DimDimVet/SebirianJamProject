using Zenject;

namespace Pools
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITrash1PoolExecutor>().To<Trash1PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash2PoolExecutor>().To<Trash2PoolExecutor>().AsSingle().NonLazy();
        }
    }
}

