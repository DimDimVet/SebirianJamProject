using UnityEngine;

namespace Pools
{
    public interface ITrash9PoolExecutor
    {
        GameObject GetObject(float direction, Transform containerTransform);
        void ReternObject(int _hash);
    }
}