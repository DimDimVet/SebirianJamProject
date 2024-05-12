using MainMenu;
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
        private IMenuExecutor panels;
        [Inject]
        public void Init(IGameExecutor _games,IMenuExecutor _panels)
        {
            games = _games;
            panels = _panels;
        }

        private void Start()
        {
            hashPlayer = games.GetHashPlayer();

        }

        private void SetAudio()
        {
           // audioSourceButton = gameObject.AddComponent<AudioSource>();
            {
             //   audioSourceButton.clip = audioClip;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (hashPlayer == collision.gameObject.GetHashCode())
            { games.RaisingSpeed(deBafSpeed); }
        }
    }
}

