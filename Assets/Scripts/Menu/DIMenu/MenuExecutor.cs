using System;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public struct Panels
    {
        public GameObject GamePanel;
        public GameObject GndPanel;
        public GameObject SettPanel;
        public GameObject TrainingPanel;
        public GameObject InfoPanel;
        public GameObject MenuButtonsPanel;
        //
        public bool isOffObjectGamePanel;
        public bool isOffObjectGndPanel;
        public bool isOffObjectSettPanel;
        public bool isOffObjectTrainingPanel;
        public bool isOffObjectInfoPanel;
        public bool isOffObjectMenuButtonsPanel;
    }
    public struct AudioGame
    {
        public AudioClip AudioClipGnd;
        public AudioClip AudioClipButton;
        public float MuzVol;
        public float EfectVol;
        public bool isLoopMuz;
        public bool isLoopEfect;
    }
    public struct ScreenGame
    {
        public Vector2[] Resolution;
    }
    public class MenuExecutor : IMenuExecutor
    {
        private Panels panels;
        private AudioGame audioGame;
        private ScreenGame screenGame;
        //
        public Action OnSceneGame { get { return onSceneGame; } set { onSceneGame = value; } }
        private Action onSceneGame;
        public Action OnSceneMainMenu { get { return onSceneMainMenu; } set { onSceneMainMenu = value; } }
        private Action onSceneMainMenu;
        public Action OnSceneReBoot { get { return onSceneReBoot; } set { onSceneReBoot = value; } }
        private Action onSceneReBoot;
        public Action OnSceneExit { get { return onSceneExit; } set { onSceneExit = value; } }
        private Action onSceneExit;
        public Action OnOverScene { get { return onOverScene; } set { onOverScene = value; } }
        private Action onOverScene;
        public Action OnVictoryScene { get { return onVictoryScene; } set { onVictoryScene = value; } }
        private Action onVictoryScene;
        public Action<Resolution> OnSetResolution { get { return onSetResolution; } set { onSetResolution = value; } }
        private Action<Resolution> onSetResolution;
        public Action<AudioGame> OnParametrAudio { get { return onParametrAudio; } set { onParametrAudio = value; } }
        private Action<AudioGame> onParametrAudio;
        public Action<float, float, float> OnGetClock { get { return onGetClock; } set { onGetClock = value; } }
        private Action<float, float, float> onGetClock;
        //Screen
        private List<string> textScreen;
        public List<string> TextScreen { get { return textScreen; } }
        private int indexCurrentScreen;
        public int IndexCurrentScreen { get { return indexCurrentScreen; } }
        private Resolution currentScreen;
        private Resolution[] resolutions, tempResolutions;
        #region PanelsScene
        public void SetPanels(Panels _panels)
        {
            panels = _panels;
        }
        public void MenuOther()
        {
            panels.GndPanel.SetActive(true);
            GameTimer(false);
        }
        public void MenuPause()
        {
            panels.GamePanel.SetActive(true);
            panels.GndPanel.SetActive(false);
            panels.SettPanel.SetActive(false);
            panels.TrainingPanel.SetActive(false);
            panels.InfoPanel.SetActive(false);
            panels.MenuButtonsPanel.SetActive(false);
            GameTimer(true);
        }
        public bool MainPanels(bool isPause = false)
        {
            panels.GndPanel.SetActive(true);
            panels.SettPanel.SetActive(false);
            panels.TrainingPanel.SetActive(false);
            panels.InfoPanel.SetActive(false);
            panels.MenuButtonsPanel.SetActive(true);
            GameTimer(isPause);
            return panels.isOffObjectMenuButtonsPanel;
        }
        public bool SettPanels()
        {
            panels.GndPanel.SetActive(false);
            panels.SettPanel.SetActive(true);
            panels.TrainingPanel.SetActive(false);
            panels.InfoPanel.SetActive(false);
            panels.MenuButtonsPanel.SetActive(false);
            return panels.isOffObjectSettPanel;
        }
        public bool TrainingPanels()
        {
            panels.GndPanel.SetActive(false);
            panels.SettPanel.SetActive(false);
            panels.TrainingPanel.SetActive(true);
            panels.InfoPanel.SetActive(false);
            panels.MenuButtonsPanel.SetActive(false);
            return panels.isOffObjectTrainingPanel;
        }
        public bool InfoPanels()
        {
            panels.GndPanel.SetActive(false);
            panels.SettPanel.SetActive(false);
            panels.TrainingPanel.SetActive(false);
            panels.InfoPanel.SetActive(true);
            panels.MenuButtonsPanel.SetActive(false);
            return panels.isOffObjectInfoPanel;
        }
        public void SceneGame()
        {
            onSceneGame?.Invoke();
        }
        public void GameReBoot()
        {
            onSceneReBoot?.Invoke();
        }
        public void ReturnMainMenu()
        {
            onSceneMainMenu?.Invoke();
        }
        public void SceneExit()
        {
            onSceneExit?.Invoke();
        }
        public void OverScene()
        {
            onOverScene?.Invoke();
        }
        public void VictoryScene()
        {
            onVictoryScene?.Invoke();
        }
        #endregion
        #region Audio
        public void SetAudio(AudioGame _audioGame)
        {
            audioGame = _audioGame;
            GetAudioParametr();
            if (audioGame.MuzVol == 0 & audioGame.EfectVol == 0)
            {
                audioGame.MuzVol = _audioGame.MuzVol;
                audioGame.EfectVol = _audioGame.EfectVol;
            }
            SetNewAudio(audioGame);
        }
        public void SetNewAudio(AudioGame _audioGame)
        {
            SetAudioParametr(_audioGame.MuzVol, _audioGame.EfectVol);
            onParametrAudio?.Invoke(_audioGame);
        }
        #endregion
        #region Screen
        public void DataScreen(ScreenGame _screenGame)
        {
            screenGame = _screenGame;
        }
        public void ScreenSet(Resolution[] _resolutions, Resolution currentResolution)
        {
            textScreen = new List<string>();
            tempResolutions = _resolutions;
            int hz = tempResolutions[0].refreshRate;

            for (int i = 0; i < tempResolutions.Length; i++)
            {
                for (int j = 0; j < screenGame.Resolution.Length; j++)
                {
                    if (tempResolutions[i].width == screenGame.Resolution[j].x &
                        tempResolutions[i].height == screenGame.Resolution[j].y &
                        tempResolutions[i].refreshRate == hz)
                    {
                        resolutions = CreatResolution(tempResolutions[i], resolutions);
                        textScreen.Add($"{tempResolutions[i].width}x{tempResolutions[i].height}");
                    }
                }
            }

            currentScreen = GetResolution();

            for (int i = 0; i < resolutions.Length; i++)
            {
                if (resolutions[i].width == currentScreen.width & resolutions[i].height == currentScreen.height)
                {
                    indexCurrentScreen = i; break;
                }
                else
                {
                    currentScreen.width = (int)screenGame.Resolution[0].x;
                    currentScreen.height = (int)screenGame.Resolution[0].y;
                }
            }

            SetCurrentResolution(currentScreen);
        }

        private Resolution[] CreatResolution(Resolution intObject, Resolution[] massivObject)
        {
            if (massivObject != null)
            {
                int newLength = massivObject.Length + 1;
                Array.Resize(ref massivObject, newLength);
                massivObject[newLength - 1] = intObject;
                return massivObject;
            }
            else
            {
                massivObject = new Resolution[] { intObject };
                return massivObject;
            }
        }
        private void SetCurrentResolution(Resolution _currentScreen)
        {
            if (_currentScreen.width == 0 & _currentScreen.height == 0)
            {
                _currentScreen.width = (int)screenGame.Resolution[0].x;
                _currentScreen.height = (int)screenGame.Resolution[0].y;
            }
            onSetResolution?.Invoke(_currentScreen);
        }
        public void SetNewResolution(int indexDrop)
        {
            currentScreen.width = resolutions[indexDrop].width;
            currentScreen.height = resolutions[indexDrop].height;
            SetResolution(currentScreen);

            SetCurrentResolution(currentScreen);
        }
        #endregion
        #region EPROM
        private void SetResolution(Resolution currentScreen)
        {
            PlayerPrefs.SetInt("CurrentWidth", currentScreen.width);
            PlayerPrefs.SetInt("CurrentHeight", currentScreen.height);
        }
        private Resolution GetResolution()
        {
            Resolution temp = new Resolution();
            temp.width = PlayerPrefs.GetInt("CurrentWidth");
            temp.height = PlayerPrefs.GetInt("CurrentHeight");

            return temp;
        }
        private void SetAudioParametr(float muzVol, float efectVol)
        {
            PlayerPrefs.SetFloat("CurrentMuzVol", muzVol);
            PlayerPrefs.SetFloat("CurrentEfectVol", efectVol);
            audioGame.MuzVol = muzVol;
            audioGame.EfectVol = efectVol;
        }
        private void GetAudioParametr()
        {
            audioGame.MuzVol = PlayerPrefs.GetFloat("CurrentMuzVol");
            audioGame.EfectVol = PlayerPrefs.GetFloat("CurrentEfectVol");
        }
        #endregion
        #region Clock
        public void SetClock(float secund, float minute, float hour)
        {
            onGetClock?.Invoke(secund, minute, hour);
        }
        #endregion
        private void GameTimer(bool isRun)
        {
            if (isRun) { Time.timeScale = 1; }
            else { Time.timeScale = 0; }
        }
    }
}

