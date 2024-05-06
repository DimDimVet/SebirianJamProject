using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace MainMenu
{
    public class MenuActions : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        private IMenuExecutor panels;
        [Inject]
        public void Init(IMenuExecutor _panels)
        {
            panels = _panels;
        }
        private void OnEnable()
        {
            panels.OnSceneGame += OpenScene;
            panels.OnSceneExit += Exit;
        }

        private void OpenScene()
        {
            SceneManager.LoadScene(sceneName);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}

