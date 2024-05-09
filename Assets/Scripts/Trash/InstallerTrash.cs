using Zenject;

namespace Trash
{
    public class InstallerTrash : MonoInstaller
    {
        [Inject] private TrashPrefab trashPrefab;
        public override void InstallBindings()
        {
            Container.BindFactory<Trash1, Trash1.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash1);
            Container.BindFactory<Trash2, Trash2.Factory>().FromComponentInNewPrefab(trashPrefab.SetTrash2);
            //Container.BindFactory<PlayerRif, PlayerRif.Factory>().FromComponentInNewPrefab(playerBullPrefab.SetRifObject);
            //Container.BindFactory<PlayerTurnSleeve, PlayerTurnSleeve.Factory>().FromComponentInNewPrefab(playerBullPrefab.SetTurnSleeveObject);
            //Container.BindFactory<PlayerRifSleeve, PlayerRifSleeve.Factory>().FromComponentInNewPrefab(playerBullPrefab.SetRifSleeveObject);
        }
    }
}

