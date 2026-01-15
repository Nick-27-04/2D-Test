using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool isDead = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isDead) // 죽었을 때는 이동 중지
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    public void Die()
    {
        if (isDead) return; // 중복 죽음 방지
        isDead = true;

        // 1. 애니메이션 트리거 (스위치 켜기)
        GetComponent<Animator>().SetTrigger("isDead");

        // 2. 물리 연출: 찌그러뜨리기 (Scale 변경)
        transform.localScale = new Vector3(1.2f, 0.2f, 1.2f);

        // 3. 물리 연출: 위로 팝! 튀어 오르기
        if (rb != null)
        {
            GetComponent<Collider>().enabled = false; // 콜라이더를 꺼서 바닥 아래로 추락 유도
            rb.linearVelocity = new Vector3(0, 8f, 0); // 위로 점프
        }

        // 4. 부모가 있으면 부모까지 포함해서 삭제
        GameObject targetToDestroy = transform.parent != null ? transform.parent.gameObject : gameObject;
        Destroy(targetToDestroy, 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            // 작성하신 normal.y 판정 로직
            if (collision.contacts[0].normal.y < -0.7f)
            {
                Die();

                // 플레이어 튕겨주기
                Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
                if (playerRb != null)
                {
                    playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 7f, 0);
                }
            }
            else
            {
                Debug.Log("플레이어 피격!");
            }
        }
    }
}