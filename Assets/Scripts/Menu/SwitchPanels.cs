using UnityEngine;
using Zenject;

namespace MainMenu
{
    public class SwitchPanels : MonoBehaviour
    {
        [SerializeField] private GameObject gndPanel;
        [SerializeField] private GameObject settPanel;
        [SerializeField] private GameObject trainingPanel;
        [SerializeField] private GameObject infoPanel;
        [SerializeField] private GameObject menuButtonsPanel;

        private IMenuExecutor panels;
        [Inject]
        public void Init(IMenuExecutor _panels)
        {
            panels = _panels;
        }
        private void Start()
        {
            Panels panel = new Panels()
            {
                GndPanel = gndPanel,
                SettPanel = settPanel,
                TrainingPanel=trainingPanel,
                InfoPanel = infoPanel,
                MenuButtonsPanel = menuButtonsPanel
            };
            panels.SetPanels(panel);
        }
    }
}

