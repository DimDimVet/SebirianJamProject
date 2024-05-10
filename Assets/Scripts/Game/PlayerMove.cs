using Input;
using MainMenu;
using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField][Range(0, 10)] private float moveSpeed = 5f;
        [SerializeField][Range(0, 1f)] private float defaultSpeed = 0.5f;
        [SerializeField][Range(0, 100)] private float speedTurn = 10f;
        [SerializeField][Range(0, 1)] private float dividerInertia = 0.99f;
        [SerializeField][Range(0, 15)] private float speedReductionTime = 15f;

        [SerializeField] private float minSpeed = 0.5f;
        [SerializeField] private float maxSpeed = 5f;

        private float defaultTime;

        private float baseSpeed;
        private Rigidbody2D rbThisObject;
        private Vector2 inputDirection, residualDirection, tempInputDirection;
        private Vector3 moveDirection;
        private Quaternion deltaRotation, directionRotation;
        //
        private bool isRun = false, isStopRun = false;
        //
        private IInputPlayerExecutor inputs;
        private IMenuExecutor panels;
        private IGameExecutor games;
        [Inject]
        public void Init(IInputPlayerExecutor _inputs, IMenuExecutor _panels, IGameExecutor _games)
        {
            inputs = _inputs;
            //panels = _panels;
            games = _games;
        }
        private void OnEnable()
        {
            inputs.Enable();
            //inputs.OnMousePoint += MousePoint;
            //inputs.OnStartPressMouse += StartPressMouse;

            inputs.OnMoveButton += MoveButton;
            //inputs.OnStartPressButton += StartPress;
            //inputs.OnCancelPressButton += CancelPress;
            games.OnRaisingSpeed += ControlRaisingSpeed;
        }
        private void ControlRaisingSpeed(int _speed)
        {
            moveSpeed += _speed;
        }
        private void MoveButton(InputButtonData data)
        {
            inputDirection = data.WASD;
        }
        private void Start()
        {
            games.SetHashPlayer(this.gameObject.GetHashCode());
            defaultTime = speedReductionTime;
        }
        private void GetRun()
        {
            if (!isRun)
            {
                rbThisObject = GetComponent<Rigidbody2D>();
                if (!(rbThisObject is Rigidbody2D)) { this.gameObject.AddComponent<Rigidbody2D>(); }
                isRun = true;
            }
        }
        void FixedUpdate()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); return; }
            Move();
        }
        private void Move()
        {
            if (inputDirection.x == 0 && inputDirection.y == 0)
            {
                tempInputDirection.x = defaultSpeed;
                tempInputDirection.y = 0;
                MoveExecutor(tempInputDirection);
            }

            if (inputDirection.x == 0 && inputDirection.y > 0)
            {
                tempInputDirection.x = 0.71f;
                tempInputDirection.y = 0.71f;
                MoveExecutor(tempInputDirection);
            }

            if (inputDirection.x == 0 && inputDirection.y < 0)
            {
                tempInputDirection.x = 0.71f;
                tempInputDirection.y = -0.71f;
                MoveExecutor(tempInputDirection);
            }

            if (inputDirection.x > 0 && inputDirection.y == 0)
            {
                tempInputDirection.x = inputDirection.x;
                tempInputDirection.y = inputDirection.y;
                MoveExecutor(tempInputDirection);
            }

            if (inputDirection.x > 0 && inputDirection.y != 0)
            {
                tempInputDirection.x = inputDirection.x;
                tempInputDirection.y = inputDirection.y;
                MoveExecutor(tempInputDirection);
            }

            games.SpeedIndikator(rbThisObject.velocity.magnitude,minSpeed,maxSpeed);
            if(rbThisObject.velocity.magnitude<=0.02f){games.FinishOver();}
        }
        private void MoveExecutor(Vector2 _direction)
        {
            rbThisObject.velocity = _direction * moveSpeed;
            residualDirection = _direction;
            baseSpeed = moveSpeed;
            //
            moveDirection = rbThisObject.velocity;
            deltaRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            directionRotation = Quaternion.RotateTowards(transform.rotation, deltaRotation, speedTurn);
            rbThisObject.MoveRotation(directionRotation);
        }
        private void Update()
        {
            LoadRespawn();
        }
        private void LoadRespawn()
        {
            speedReductionTime -= Time.deltaTime;

            if (speedReductionTime <= 0)
            {
                speedReductionTime = defaultTime;

                if (moveSpeed <= 0) { moveSpeed = 0; }
                else { moveSpeed = moveSpeed - 0.1f; }
            }
        }

    }
}

