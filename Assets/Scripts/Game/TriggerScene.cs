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
        private IMenuExecutor panels;
        [Inject]
        public void Init(IMenuExecutor _panels)
        {
            panels = _panels;
        }
        private void OnEnable()
        {

        }
        private void Start()
        {
            clickOver.onClick.AddListener(OverScene);
            clickVictory.onClick.AddListener(VictoryScene);
        }
        private void OverScene()
        {
            panels.OverScene();
        }
        private void VictoryScene()
        {
            panels.VictoryScene();
        }
    }
}

