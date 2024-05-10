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
        private ITrash0PoolExecutor trash0Pool;
        private ITrash1PoolExecutor trash1Pool;
        private ITrash2PoolExecutor trash2Pool;
        private ITrash3PoolExecutor trash3Pool;
        private ITrash4PoolExecutor trash4Pool;
        private ITrash5PoolExecutor trash5Pool;
        private ITrash6PoolExecutor trash6Pool;
        private ITrash7PoolExecutor trash7Pool;
        private ITrash8PoolExecutor trash8Pool;
        private ITrash9PoolExecutor trash9Pool;
        [Inject]
        public void Init(IGameExecutor _games, ITrash0PoolExecutor _trash0Pool,
                         ITrash1PoolExecutor _trash1Pool, ITrash2PoolExecutor _trash2Pool,
                         ITrash3PoolExecutor _trash3Pool,ITrash4PoolExecutor _trash4Pool,
                         ITrash5PoolExecutor _trash5Pool, ITrash6PoolExecutor _trash6Pool,
                         ITrash7PoolExecutor _trash7Pool, ITrash8PoolExecutor _trash8Pool,
                         ITrash9PoolExecutor _trash9Pool)
        {
            trash0Pool = _trash0Pool;
            trash1Pool = _trash1Pool;
            trash2Pool = _trash2Pool;
            trash3Pool = _trash3Pool;
            trash4Pool = _trash4Pool;
            trash5Pool = _trash5Pool;
            trash6Pool = _trash6Pool;
            trash7Pool = _trash7Pool;
            trash8Pool = _trash8Pool;
            trash9Pool = _trash9Pool;
            games = _games;
        }
        private void OnEnable()
        {
            games.OnSetCollisionHash += SetCollisionHash;
        }
        private void SetCollisionHash(int _hash)
        {
            trash0Pool.ReternObject(_hash);
            trash1Pool.ReternObject(_hash);
            trash2Pool.ReternObject(_hash);
            trash3Pool.ReternObject(_hash);
            trash4Pool.ReternObject(_hash);
            trash5Pool.ReternObject(_hash);
            trash6Pool.ReternObject(_hash);
            trash7Pool.ReternObject(_hash);
            trash8Pool.ReternObject(_hash);
            trash9Pool.ReternObject(_hash);
         }

        void Start()
        {
            defaultTime = currentTime;
        }
        private void RespawnObject()
        {
            nomerTrash = Random.Range(0, 10);
            if (nomerTrash == 0) { trash0Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 1) { trash1Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 2) { trash2Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 3) { trash3Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 4) { trash4Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 5) { trash5Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 6) { trash6Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 7) { trash7Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 8) { trash8Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerTrash == 9) { trash9Pool.GetObject(gameObject.transform.localScale.x, poolTransform); }
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

