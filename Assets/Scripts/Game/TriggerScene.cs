using System;
using MainMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class TriggerScene : MonoBehaviour
    {
        [SerializeField] private Button clickOver;
        [SerializeField] private Button clickVictory;
        private int hashPlayer;
        //
        private IMenuExecutor panels;
        private IGameExecutor games;
        [Inject]
        public void Init(IMenuExecutor _panels, IGameExecutor _games)
        {
            games = _games;
            panels = _panels;
        }
        private void OnEnable()
        {
            games.OnFinishOver+=FinishOver;
        }
        private void FinishOver()
        {
            panels.OverScene();
        }
        private void Start()
        {
            hashPlayer = games.GetHashPlayer();
            clickOver.onClick.AddListener(OverScene);
            clickVictory.onClick.AddListener(VictoryScene);
        }
        private void OverScene()
        {
            panels.OverScene();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(hashPlayer==0){hashPlayer = games.GetHashPlayer();}
            if (hashPlayer == other.gameObject.GetHashCode()) { panels.VictoryScene(); }
        }
        private void VictoryScene()
        {
            panels.VictoryScene();
        }
    }
}

