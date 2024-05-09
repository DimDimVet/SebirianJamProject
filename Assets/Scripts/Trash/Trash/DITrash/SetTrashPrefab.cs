using UnityEngine;
using Zenject;

namespace Trash
{
    [CreateAssetMenu(fileName = "SetTrashPrefab", menuName = "Installers/SetTrashPrefab")]
    public class SetTrashPrefab : ScriptableObjectInstaller<SetTrashPrefab>
    {
        public TrashPrefab TrashPrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TrashPrefab>().FromInstance(TrashPrefab).AsSingle();
        }
    }
}

