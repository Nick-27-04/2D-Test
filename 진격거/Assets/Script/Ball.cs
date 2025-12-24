using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    [SerializeField] float lifeTime = 3f;
    [SerializeField] int damage = 1;

    Rigidbody2D rb;
    Vector2 dir;
    bool h;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 d)
    {
        dir = d.normalized;
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        if (rb) rb.linearVelocity = dir * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (h) return;

        // ✅ 플레이어랑 닿으면 무시(바로 삭제되던 문제 방지)
        if (other.GetComponent<PlayerController>() != null) return;

        // ✅ 보스면 데미지 주고 삭제
        BossController boss = other.GetComponentInParent<BossController>();
        if (boss != null)
        {
            h = true;
            boss.TakeHit(damage);
            Destroy(gameObject);
            return;
        }

        // ✅ 그 외(바닥/벽 등) 닿으면 삭제
        if (!other.isTrigger)
        {
            h = true;
            Destroy(gameObject);
        }
    }
}
