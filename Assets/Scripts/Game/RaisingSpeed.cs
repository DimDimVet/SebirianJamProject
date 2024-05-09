using UnityEngine;
using Zenject;

namespace Game
{
    public class RaisingSpeed : MonoBehaviour
    {
        [SerializeField][Range(0, 10)] private int bafSpeed = 1;
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
            { games.RaisingSpeed(bafSpeed); }
        }
    }
}

