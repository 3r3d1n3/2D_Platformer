using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private float h;
    private bool isGround;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (h != 0)
        {
            playerRenderer.flipX = h < 0;
        }
        playerAnimator.SetBool("IsRunning", h != 0);


        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            playerRb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        playerRb.linearVelocityX = moveSpeed * h;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
