using Input;
using UnityEngine;
using Zenject;

namespace MainMenu
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private Vector2 sizeOnHover;
        [SerializeField] private CustomButton playButton;
        [SerializeField] private CustomButton settButton;
        [SerializeField] private CustomButton trainingButton;
        [SerializeField] private CustomButton infoButton;
        [SerializeField] private CustomButton exitButton;
        [SerializeField] private CustomButton settReturnButton;
        [SerializeField] private CustomButton trainingReturnButton;
        [SerializeField] private CustomButton infoReturnButton;

        private Vector2 tempVector2;
        private GameObject tempButton;
        private AudioSource audioSourceGnd;
        private AudioSource audioSourceButton;
        private AudioGame audioGame;
        //
        private IInputPlayerExecutor inputs;
        private IMenuExecutor panels;
        [Inject]
        public void Init(IInputPlayerExecutor _inputs, IMenuExecutor _panels)
        {
            inputs = _inputs;
            panels = _panels;
        }
        private void OnEnable()
        {
            inputs.Enable();
            //inputs.OnMousePoint += MousePoint;
            //inputs.OnStartPressMouse += StartPressMouse;

            //inputs.OnMoveButton += MoveButton;
            //inputs.OnStartPressButton += StartPress;
            //inputs.OnCancelPressButton += CancelPress;

            playButton.OnFocusMouse += ButtonSize;
            playButton.onClick.AddListener(SceneStart);

            settButton.OnFocusMouse += ButtonSize;
            settButton.onClick.AddListener(SettPanels);

            trainingButton.OnFocusMouse += ButtonSize;
            trainingButton.onClick.AddListener(TrainingPanels);

            infoButton.OnFocusMouse += ButtonSize;
            infoButton.onClick.AddListener(InfoPanels);

            exitButton.OnFocusMouse += ButtonSize;
            exitButton.onClick.AddListener(ExitGame);

            settReturnButton.OnFocusMouse += ButtonSize;
            settReturnButton.onClick.AddListener(MainPanels);

            trainingReturnButton.OnFocusMouse += ButtonSize;
            trainingReturnButton.onClick.AddListener(MainPanels);

            infoReturnButton.OnFocusMouse += ButtonSize;
            infoReturnButton.onClick.AddListener(MainPanels);

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
            if (audioSourceGnd == null & audioSourceButton == null)
            {
                SetAudio();
            }
            AudioVolum();
        }

        //private void MoveButton(InputButtonData data)
        //{
        //    Debug.Log($"нажатьWASD {data.WASD}");
        //}
        //private void MousePoint(Vector2 hit)
        //{
        //    tempVector2 = hit;
        //}
        //private void StartPressMouse(InputMouseData _inputMouseData)
        //{
        //    //pointer.position = tempVector2;
        //    Debug.Log($"нажата мыш {_inputMouseData.MouseLeftButton} {_inputMouseData.MouseRightButton} {_inputMouseData.MouseMiddleButton}");
        //}
        //private void StartPress(InputButtonData data)
        //{
        //    Debug.Log($"нажать Esc - Space {data.Esc} {data.Space}");
        //}
        //private void CancelPress(InputButtonData data)
        //{
        //    Debug.Log($"отжать Esc - Space {data.Esc} {data.E}");
        //}

        private void Start()
        {
            MainPanels();
        }
        private void ButtonSize(bool _flag, GameObject _objectButton)
        {
            tempButton = _objectButton;
            if (_flag) { tempButton.transform.localScale = sizeOnHover; }
            else { tempButton.transform.localScale = new Vector3(1, 1, 0); }
        }
        private void MainPanels()
        {
            panels.MainPanels();
            if (tempButton != null) { ButtonSize(false, tempButton); }
            AudioClick();
        }
        private void SetAudio()
        {
            audioSourceGnd = gameObject.AddComponent<AudioSource>();
            audioSourceButton = gameObject.AddComponent<AudioSource>();
            {
                audioSourceGnd.clip = audioGame.AudioClipGnd;
                audioSourceGnd.Play();

                audioSourceButton.clip = audioGame.AudioClipButton;
            }
        }
        private void AudioVolum()
        {
            audioSourceGnd.volume = audioGame.MuzVol;
            audioSourceButton.volume = audioGame.EfectVol;
        }
        private void AudioClick()
        {
            if (audioSourceButton != null) { audioSourceButton.Play(); }
        }
        private void SceneStart()
        {
            panels.SceneGame();
            AudioClick();
        }
        private void SettPanels()
        {
            panels.SettPanels();
            ButtonSize(false, tempButton);
            AudioClick();
        }
        private void TrainingPanels()
        {
            panels.TrainingPanels();
            ButtonSize(false, tempButton);
            AudioClick();
        }
        private void InfoPanels()
        {
            panels.InfoPanels();
            ButtonSize(false, tempButton);
            AudioClick();
        }
        private void ExitGame()
        {
            panels.SceneExit();
            AudioClick();
        }
    }
}

