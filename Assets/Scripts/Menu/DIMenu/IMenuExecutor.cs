
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public interface IMenuExecutor
    {
        void SetPanels(Panels panels);
        void SetAudio(AudioGame _audioGame);
        void DataScreen(ScreenGame _screenGame);
        void ScreenSet(Resolution[] _resolutions, Resolution currentResolution);
        void SetNewResolution(int indexDrop);
        List<string> TextScreen { get; }
        int IndexCurrentScreen { get; }
        void MenuPause();
        void MainPanels();
        void SettPanels();
        void TrainingPanels();
        void InfoPanels();
        void SceneGame();
        void ReturnMainMenu();
        void SceneExit();
        void SetNewAudio(AudioGame _audioGame);
        Action OnSceneGame { get; set; }
        Action OnSceneMainMenu { get; set; }
        Action OnSceneExit { get; set; }
        Action<Resolution> OnSetResolution { get; set; }
        Action<AudioGame> OnParametrAudio { get; set; }
        Action<float, float, float> OnGetClock { get; set; }
        void SetClock(float secund, float minute, float hour);
        Action OnSceneReBoot { get; set; }
        void GameReBoot();
    }
}

