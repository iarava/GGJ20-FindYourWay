using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]
    private float speed = 3f;

    private bool isMoveLeft;
    private bool isMoveRight;

    private MoveController moveController;
    private Rigidbody2D rb;

    private void Awake()
    {
        moveController = GetComponent<MoveController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        moveController.MoveLeft += OnMoveLeft;
        moveController.MoveRight += OnMoveRight;
    }

    private void OnMoveLeft()
    {
            isMoveLeft = true;
    }

    private void OnMoveRight()
    {
            isMoveRight = true;
    }

    private void FixedUpdate()
    {
        var pos = Vector3.zero;

        if (isMoveLeft)
        {
            rb.MovePosition(transform.position + Vector3.left * Time.fixedDeltaTime * speed);
            isMoveLeft = false;
        }

        if (isMoveRight)
        {
            rb.MovePosition(transform.position + Vector3.right * Time.fixedDeltaTime * speed);
            isMoveRight = false;
        }
            
    }

    private void OnDestroy()
    {
        moveController.MoveLeft -= OnMoveLeft;
        moveController.MoveRight -= OnMoveRight;
    }
}
