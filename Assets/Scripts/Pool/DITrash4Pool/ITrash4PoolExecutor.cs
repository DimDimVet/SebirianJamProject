using UnityEngine;

namespace Pools
{
    public interface ITrash4PoolExecutor
    {
        GameObject GetObject(float direction, Transform containerTransform);
        void ReternObject(int _hash);
    }
}