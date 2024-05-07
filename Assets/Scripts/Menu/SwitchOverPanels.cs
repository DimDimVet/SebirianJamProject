using UnityEngine;
using Zenject;

namespace MainMenu
{
    public class SwitchOverPanels : MonoBehaviour
    {
        [SerializeField] private GameObject gndPanel;

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
                GndPanel = gndPanel
            };
            panels.SetPanels(panel);
        }
    }
}

