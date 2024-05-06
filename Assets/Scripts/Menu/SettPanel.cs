using Input;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainMenu
{
    public class SettPanel : MonoBehaviour
    {
        [Header("Dropdown разрешений")]
        [SerializeField] private Dropdown screenDropdown;
        [SerializeField] private Vector2[] resolution;

        [Header("Звуковой файл - кнопка")]
        [SerializeField] private AudioClip audioClipButton;
        [Header("Звуковой файл - фон")]
        [SerializeField] private AudioClip audioClipGnd;
        [Header("Slider звука")]
        [SerializeField] private Slider muzSlider;
        [SerializeField] private Slider effectSlider;
        [Header("Уровень музыки"), Range(0, 1)]
        [SerializeField] private float muzVol = 0.5f;
        [Header("Уровень эффектов"), Range(0, 1)]
        [SerializeField] private float efectVol = 0.5f;

        private AudioGame audioGame;
        private ScreenGame screenGame;
        private IMenuExecutor panels;
        [Inject]
        public void Init(IInputPlayerExecutor _inputs, IMenuExecutor _panels)
        {
            panels = _panels;
        }
        private void OnEnable()
        {
            panels.OnParametrAudio += ParametrAudio;
            panels.OnSetResolution += SetResolution;
        }
        private void SetResolution(Resolution _resolution)
        {
            Screen.SetResolution(_resolution.width, _resolution.height, true);
        }
        private void ParametrAudio(AudioGame _audioGame)
        {
            audioGame = _audioGame;
            AudioControl(audioGame.MuzVol, audioGame.EfectVol);
        }
        private void Start()
        {
            screenGame = new ScreenGame()
            {
                Resolution=resolution
            };
            panels.DataScreen(screenGame);

            Resolution currentResolution = Screen.currentResolution;
            panels.ScreenSet(Screen.resolutions, currentResolution);

            screenDropdown.ClearOptions();
            screenDropdown.AddOptions(panels.TextScreen);
            screenDropdown.value = panels.IndexCurrentScreen;
            //
            audioGame = new AudioGame()
            {
                AudioClipGnd = audioClipGnd,
                AudioClipButton = audioClipButton,
                MuzVol = muzVol,
                EfectVol = efectVol
            };
            panels.SetAudio(audioGame);

            SetEventButton();
        }
        private void SetEventButton()
        {
            screenDropdown.onValueChanged.AddListener(NewResolution);

            muzSlider.onValueChanged.AddListener(AudioContolValueMuz);
            effectSlider.onValueChanged.AddListener(AudioContolValueEffect);
        }
        private void NewResolution(int indexDrop)
        {
            panels.SetNewResolution(indexDrop);
        }
        private void AudioContolValueMuz(float value)
        {
            AudioControl(value, audioGame.EfectVol);
            audioGame.MuzVol = value;
            panels.SetNewAudio(audioGame);
        }
        private void AudioContolValueEffect(float value)
        {
            AudioControl(audioGame.MuzVol, value);
            audioGame.EfectVol = value;
            panels.SetNewAudio(audioGame);
        }
        private void AudioControl(float valueMuz, float valueEffect)
        {
            audioGame.MuzVol = valueMuz;
            audioGame.EfectVol = valueEffect;
            muzSlider.value = valueMuz;
            effectSlider.value = valueEffect;
        }
    }
}

