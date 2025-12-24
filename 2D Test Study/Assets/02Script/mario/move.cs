using UnityEngine;

public class move : MonoBehaviour

{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // ���� ��ȯ (������ó��)
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
