using UnityEngine;
using Zenject;

namespace Game
{
    public class ReducingSpeed : MonoBehaviour
    {
        [SerializeField][Range(-10, 0)] private int deBafSpeed = -1;
        private int hashPlayer;
        //
        private IGameExecutor games;
        [Inject]
        public void Init(IGameExecutor _games)
        {
            games = _games;
        }
        private void Start()
        {
            hashPlayer = games.GetHashPlayer();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (hashPlayer == collision.gameObject.GetHashCode())
            { games.RaisingSpeed(deBafSpeed); }
        }
    }
}

