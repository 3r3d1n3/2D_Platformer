using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum InputType {Keyboard, Joystick}
    public InputType inputType;
    public SpriteRenderer playerSR;
    public Animator playerAnim;
    private Rigidbody2D playerRb;
    private CapsuleCollider2D playerCollider;
    
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private bool isGrounded;
    private int facingDirection = 1;

    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] private float jumpPower = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputType == InputType.Keyboard)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
        
        
        moveSpeed = verticalInput < 0 ? 1.5f : 3f;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        
        SetPlayerAnim();
    }

    public void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        playerAnim.SetTrigger("Jump");
    }
    

    private void Move()
    {
        if (horizontalInput != 0)
        {
            playerRb.linearVelocityX = moveSpeed * horizontalInput;
        }
        else
        {
            playerRb.linearVelocityX = 0;
        }
    }

    private void SetPlayerAnim()
    {
        if (horizontalInput != 0)
        {
            facingDirection = horizontalInput > 0 ? 1 : -1;
            playerSR.flipX = facingDirection == -1;
        }

        if (verticalInput <0)
        {
            playerCollider.offset = new Vector2(playerCollider.offset.x, 0.6f);
            playerCollider.size = new Vector2(playerCollider.size.x, 1.1f);
        }
        else
        {
            playerCollider.offset = new Vector2(playerCollider.offset.x, 0.8f);
            playerCollider.size = new Vector2(playerCollider.size.x, 1.5f);
        }
        
        playerAnim.SetFloat("AxisX", horizontalInput);
        playerAnim.SetFloat("AxisY", verticalInput);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAnim.SetBool("IsGrounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            playerAnim.SetBool("IsGrounded", false);
        }
    }

    public void InputJoystick(float h, float v)
    {
        if (inputType == InputType.Joystick)
        {
            if (v > 0.45f)
            {
                verticalInput = 1f;
            }
            else if (v < -0.45f)
            {
                verticalInput = -1f;
            }
            else
            {
                verticalInput = 0f;
            }

            if (h > 0.45f)
            {
                horizontalInput = 1f;
            }
            else if (h < -0.45f)
            {
                horizontalInput = -1f;
            }
            else horizontalInput = 0f;
        }
        
    }
}
