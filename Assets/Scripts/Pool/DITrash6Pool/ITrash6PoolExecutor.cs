using UnityEngine;

namespace Pools
{
    public interface ITrash6PoolExecutor
    {
        GameObject GetObject(float direction, Transform containerTransform);
        void ReternObject(int _hash);
    }
}