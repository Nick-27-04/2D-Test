using UnityEngine;

public class monster : MonoBehaviour

{
    public float moveSpeed = 2f;
    public float bounceForce = 8f;

    private Rigidbody2D rb;
    private bool isDead = false;

    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * moveSpeed;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        // �÷��̾�� �浹���� ��
        if (collision.gameObject.CompareTag("Player"))
        {
            // �浹 ���� Ȯ��
            float playerY = collision.transform.position.y;
            float enemyY = transform.position.y;

            if (playerY > enemyY + 0.3f)
            {
                Die();

                // �÷��̾� ���� �ݵ�
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
            }
            else
            {
                // �÷��̾� ������ (�ϴ� �α�)
                Debug.Log("�÷��̾� ������!");
            }
        }
    }

    void Die()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.3f);
    }
}
