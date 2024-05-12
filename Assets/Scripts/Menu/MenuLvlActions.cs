using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace MainMenu
{
    public class MenuLvlActions : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private string victorySceneName;
        [SerializeField] private string overSceneName;

        private IMenuExecutor panels;
        [Inject]
        public void Init(IMenuExecutor _panels)
        {
            panels = _panels;
        }
        private void OnEnable()
        {
            panels.OnSceneMainMenu += OpenScene;
            panels.OnSceneReBoot += SceneReBoot;
            panels.OnSceneExit += Exit;
            panels.OnOverScene += OverScene;
            panels.OnVictoryScene += VictoryScene;
        }
        private void SceneReBoot()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        private void OpenScene()
        {
            SceneManager.LoadScene(sceneName);
        }
        private void VictoryScene()
        {
            SceneManager.LoadScene(victorySceneName);
        }
        private void OverScene()
        {
            SceneManager.LoadScene(overSceneName);
        }
        private void Exit()
        {
            Application.Quit();
        }
    }
}

