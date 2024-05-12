using UnityEngine;
using Zenject;

namespace MainMenu
{
    public class SwitchPanels : MonoBehaviour
    {
        [SerializeField] private GameObject gndPanel;
        [SerializeField] private bool isOffObjectGnd;
        [SerializeField] private GameObject settPanel;
        [SerializeField] private bool isOffObjectSett;
        [SerializeField] private GameObject trainingPanel;
        [SerializeField] private bool isOffObjectTraining;
        [SerializeField] private GameObject infoPanel;
        [SerializeField] private bool isOffObjectInfo;
        [SerializeField] private GameObject menuButtonsPanel;
        [SerializeField] private bool isOffObjectMenu;

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
                MenuButtonsPanel = menuButtonsPanel,
                isOffObjectGndPanel=isOffObjectGnd,
                isOffObjectSettPanel=isOffObjectSett,
                isOffObjectInfoPanel=isOffObjectInfo,
                isOffObjectTrainingPanel=isOffObjectTraining,
                isOffObjectMenuButtonsPanel= isOffObjectMenu
            };
            panels.SetPanels(panel);
        }
    }
}

