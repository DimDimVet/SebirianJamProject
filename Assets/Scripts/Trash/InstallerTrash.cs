using Zenject;

namespace Trash
{
    public class InstallerTrash : MonoInstaller
    {
        [Inject] private TrashPrefab trashPrefab;
        public override void InstallBindings()
        {
            Container.BindFactory<Trash0, Trash0.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash0);
            Container.BindFactory<Trash1, Trash1.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash1);
            Container.BindFactory<Trash2, Trash2.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash2);
           Container.BindFactory<Trash3, Trash3.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash3);
           Container.BindFactory<Trash4, Trash4.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash4);
           Container.BindFactory<Trash5, Trash5.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash5);
           Container.BindFactory<Trash6, Trash6.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash6);
           Container.BindFactory<Trash7, Trash7.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash7);
           Container.BindFactory<Trash8, Trash8.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash8);
           Container.BindFactory<Trash9, Trash9.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash9);
        }
    }
}

