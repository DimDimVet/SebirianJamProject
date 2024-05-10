using Trash;
using UnityEngine;
using Zenject;

namespace Pools
{
    public class Trash6PoolExecutor : ITrash6PoolExecutor
    {
        private Pool pool;
        [Inject]
        private Trash6.Factory trash6;
        private void AddPull(Transform containerTransform)
        {
            BaseTrash rezult = trash6.Create();
            pool = new Pool(rezult.gameObject, containerTransform, true);
        }

        public GameObject GetObject(float direction, Transform containerTransform)
        {
            if (pool == null) { AddPull(containerTransform); }
            GameObject tempGameObject = pool.GetObjectFabric(containerTransform);

            if (tempGameObject != null) { return tempGameObject; }
            else
            {
                BaseTrash rezult = trash6.Create();
                pool.NewObjectQueue(rezult.gameObject);
                return pool.GetObjectFabric(containerTransform);
            }
        }

        public void ReternObject(int _hash)
        {
            pool.ReternObject(_hash);
        }
    }
}

