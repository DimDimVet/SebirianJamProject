using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace MainMenu
{
    public class MenuLvlActions : MonoBehaviour
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
            panels.OnSceneMainMenu += OpenScene;
            panels.OnSceneReBoot += SceneReBoot;
            panels.OnSceneExit += Exit;
        }
        private void SceneReBoot()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

