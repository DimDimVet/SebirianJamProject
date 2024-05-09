using Pools;
using UnityEngine;
using Zenject;

namespace Game
{
    public class RespawnTrash : MonoBehaviour
    {
        [SerializeField] private Transform poolTransform;
        [SerializeField][Range(3, 15)] private float currentTime = 5f;

        private float defaultTime;
        private int nomerTrash;
        //
        private IGameExecutor games;
        private ITrash1PoolExecutor trash1Pool;
        private ITrash2PoolExecutor trash2Pool;
        [Inject]
        public void Init(ITrash1PoolExecutor _trash1Pool, ITrash2PoolExecutor _trash2Pool, IGameExecutor _games)
        {
            trash1Pool = _trash1Pool;
            trash2Pool = _trash2Pool;
            games = _games;
        }
        private void OnEnable()
        {
            games.OnSetCollisionHash += SetCollisionHash;
        }
        private void SetCollisionHash(int _hash)
        {
            trash1Pool.ReternObject(_hash);
            trash2Pool.ReternObject(_hash);
        }

        void Start()
        {
            defaultTime = currentTime;
        }
        private void RespawnObject()
        {
            nomerTrash = Random.Range(1, 3);
            
            if (nomerTrash == 1) { trash1Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 2) { trash2Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
        }
        void Update()
        {
            LoadRespawn();
        }
        private void LoadRespawn()
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = defaultTime; RespawnObject();
            }
        }
    }
}

