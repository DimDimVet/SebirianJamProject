using Trash;
using UnityEngine;
using Zenject;

namespace Pools
{
    public class Trash7PoolExecutor : ITrash7PoolExecutor
    {
        private Pool pool;
        [Inject]
        private Trash7.Factory trash7;
        private void AddPull(Transform containerTransform)
        {
            BaseTrash rezult = trash7.Create();
            pool = new Pool(rezult.gameObject, containerTransform, true);
        }

        public GameObject GetObject(float direction, Transform containerTransform)
        {
            if (pool == null) { AddPull(containerTransform); }
            GameObject tempGameObject = pool.GetObjectFabric(containerTransform);

            if (tempGameObject != null) { return tempGameObject; }
            else
            {
                BaseTrash rezult = trash7.Create();
                pool.NewObjectQueue(rezult.gameObject);
                return pool.GetObjectFabric(containerTransform);
            }
        }

        public void ReternObject(int _hash)
        {
            if (pool != null) { pool.ReternObject(_hash); }
        }
    }
}

