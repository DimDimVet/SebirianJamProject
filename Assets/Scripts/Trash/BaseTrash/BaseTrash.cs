using UnityEngine;

namespace Trash
{
    public class BaseTrash : MonoBehaviour
    {
        [SerializeField] private Vector2 inputDirection;
        [SerializeField][Range(-20, 20)] protected float inputDirectionRotZ;
        [SerializeField][Range(0, 20)] protected float moveSpeed = 5f;
        [SerializeField][Range(0, 1)] protected float speedTurn = 0.1f;
        private Vector3 rotDirection;
        private Quaternion directionRotation;
        private Rigidbody2D rbThisObject;

        private bool isRun = false, isStopRun = false;
        void Start()
        {
            SetStart();
        }
        protected virtual void SetStart()
        {
            moveSpeed = Random.Range(5, 10f);
            speedTurn = Random.Range(0, 1f);
            inputDirectionRotZ = Random.Range(-8, 8);
        }
        protected virtual void GetRun()
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
        protected virtual void Move()
        {
            rbThisObject.velocity = inputDirection * moveSpeed;

            rotDirection.z = inputDirectionRotZ;
            directionRotation = Quaternion.Euler(rotDirection * speedTurn);
            rbThisObject.MoveRotation(rbThisObject.transform.rotation * directionRotation);
        }
    }
}

