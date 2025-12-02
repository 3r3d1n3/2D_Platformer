using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer playerSR;
    public Animator playerAnim;
    private Rigidbody2D playerRb;
    
    private float horizontalInput;
    private float verticalInput;
    private bool isGrounded;
    private int facingDirection = 1;

    [SerializeField] private float moveSpeed = 7f;

    [SerializeField] private float jumpPower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        moveSpeed = verticalInput < 0 ? 3.5f : 7f;
        
        SetPlayerAnim();
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
        
        playerAnim.SetFloat("AxisX", horizontalInput);
        playerAnim.SetFloat("AxisY", verticalInput);
    }
}
