using Zenject;

namespace Pools
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITrash0PoolExecutor>().To<Trash0PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash1PoolExecutor>().To<Trash1PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash2PoolExecutor>().To<Trash2PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash3PoolExecutor>().To<Trash3PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash4PoolExecutor>().To<Trash4PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash5PoolExecutor>().To<Trash5PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash6PoolExecutor>().To<Trash6PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash7PoolExecutor>().To<Trash7PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash8PoolExecutor>().To<Trash8PoolExecutor>().AsSingle().NonLazy();
            Container.Bind<ITrash9PoolExecutor>().To<Trash9PoolExecutor>().AsSingle().NonLazy();
        }
    }
}

