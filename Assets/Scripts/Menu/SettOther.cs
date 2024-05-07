using System;
using UnityEngine;
using Zenject;

namespace MainMenu
{
    public class SettOther : MonoBehaviour
    {

        [Header("Звуковой файл - кнопка")]
        [SerializeField] private AudioClip audioClipButton;
        [Header("Звуковой файл - фон")]
        [SerializeField] private AudioClip audioClipGnd;
        [Header("Уровень музыки"), Range(0, 1)]
        [SerializeField] private float muzVol = 0.5f;
        [Header("Уровень эффектов"), Range(0, 1)]
        [SerializeField] private float efectVol = 0.5f;

        private AudioGame audioGame;
        private IMenuExecutor panels;
        [Inject]
        public void Init(IMenuExecutor _panels)
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
            audioGame = new AudioGame()
            {
                AudioClipGnd = audioClipGnd,
                AudioClipButton = audioClipButton,
                MuzVol = muzVol,
                EfectVol = efectVol
            };
            panels.SetAudio(audioGame);
        }
        private void AudioControl(float valueMuz, float valueEffect)
        {
            audioGame.MuzVol = valueMuz;
            audioGame.EfectVol = valueEffect;
        }
    }
}

