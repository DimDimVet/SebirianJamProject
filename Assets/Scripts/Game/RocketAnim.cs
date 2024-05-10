using UnityEngine;

public class RocketAnim : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    [SerializeField][Range(0.01f, 1)] private float currentTime = 0.05f;

    [SerializeField][Range(-20, 20)] private float inputDirectionRotZ;
    // [SerializeField][Range(0, 20)] private float moveSpeed = 5f;
    [SerializeField][Range(0, 1)] private float speedTurn = 0.1f;
    private Vector3 rotDirection;
    private Quaternion directionRotation;
    private Rigidbody2D rbThisObject;
    private float defaultTime, countTime;
    private SpriteRenderer spriteRenderer;
    private int counFrame = 0;
    void Start()
    {
        SetClass();
    }
    private void SetClass()
    {
        defaultTime = currentTime;
        countTime = defaultTime;
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        //
        rbThisObject = GetComponent<Rigidbody2D>();
        if (!(rbThisObject is Rigidbody2D)) { this.gameObject.AddComponent<Rigidbody2D>(); }
    }
    private void TimerSpeed()
    {
        countTime -= Time.deltaTime;

        if (countTime <= 0)
        {
            counFrame++;
            if (counFrame >= images.Length) { counFrame = 0; }
            PlayFrame(counFrame);
            countTime = defaultTime;
        }
    }
    private void PlayFrame(int _count)
    {
        spriteRenderer.sprite = images[_count];
    }
    private void MoveRot()
    {
        rotDirection.z = inputDirectionRotZ;
        directionRotation = Quaternion.Euler(rotDirection * speedTurn);
        rbThisObject.MoveRotation(rbThisObject.transform.rotation * directionRotation);
    }
    void Update()
    {
        if (currentTime != defaultTime) { defaultTime = currentTime; }
        TimerSpeed();
    }
    void FixedUpdate()
    {
        MoveRot();
    }
}
