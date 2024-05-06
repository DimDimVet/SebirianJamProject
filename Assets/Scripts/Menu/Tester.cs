using Input;
using UnityEngine;
using Zenject;

namespace MainMenu
{
    public class Tester : MonoBehaviour
    {
        [SerializeField] private Vector3 sizeOnHover;
        [SerializeField] private CustomButton playButton;
        [SerializeField] private CustomButton exitButton;
        [SerializeField] private MenuActions menuActions;
        [SerializeField] private Transform pointer;
        private Vector2 tempVector2;
        private IInputPlayerExecutor inputs;
        [Inject]
        public void Init(IInputPlayerExecutor _inputs)
        {
            inputs = _inputs;
        }
        private void OnEnable()
        {
            inputs.Enable();
            inputs.OnMousePoint += MousePoint;
            inputs.OnStartPressMouse += StartPressMouse;

            inputs.OnMoveButton += MoveButton;
            inputs.OnStartPressButton += StartPress;
            inputs.OnCancelPressButton += CancelPress;

            //playButton.OnFocusMouse += PlayButtonSize;
            //playButton.onClick.AddListener(SceneStart);

            //exitButton.OnFocusMouse += ExitButtonSize;
            //exitButton.onClick.AddListener(ExitGame);
        }

        private void MoveButton(InputButtonData data)
        {
            Debug.Log($"нажатьWASD {data.WASD}");
        }
        private void MousePoint(Vector2 hit)
        {
            tempVector2 = hit;
        }
        private void StartPressMouse(InputMouseData _inputMouseData)
        {
            pointer.position = tempVector2;
            Debug.Log($"нажата мыш {_inputMouseData.MouseLeftButton} {_inputMouseData.MouseRightButton} {_inputMouseData.MouseMiddleButton}");
        }
        private void StartPress(InputButtonData data)
        {
            Debug.Log($"нажать Esc - Space {data.Esc} {data.Space}");
        }
        private void CancelPress(InputButtonData data)
        {
            Debug.Log($"отжать Esc - Space {data.Esc} {data.E}");
        }
        private void PlayButtonSize(bool flag)
        {
            if (flag) { playButton.transform.localScale = sizeOnHover; }
            else { playButton.transform.localScale = new Vector3(1, 1, 0); }
        }
        private void ExitButtonSize(bool flag)
        {
            if (flag) { exitButton.transform.localScale = sizeOnHover; }
            else { exitButton.transform.localScale = new Vector3(1, 1, 0); }
        }
        private void SceneStart()
        {
            //menuActions.OpenScene();
            Debug.Log("Click");
        }
        private void ExitGame()
        {
            //menuActions.Exit();
            Debug.Log("Click");
        }
        void Start()
        {

        }


    }
}

