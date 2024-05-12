using MainMenu;
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
        private IMenuExecutor panels;
        [Inject]
        public void Init(IGameExecutor _games, IMenuExecutor _panels)
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
            //    audioSourceButton.clip = audioClip;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (hashPlayer == collision.gameObject.GetHashCode())
            { games.RaisingSpeed(bafSpeed);  }
        }
    }
}

