using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Shoot")]
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireCooldown = 0.15f;

    Rigidbody2D rb;
    SpriteRenderer sr;

    float nextFire;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 발사
        if (Input.GetMouseButton(0) && Time.time >= nextFire)
        {
            nextFire = Time.time + fireCooldown;
            Shoot();
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 v = new Vector2(x, y).normalized * moveSpeed;
        rb.linearVelocity = v;

        // 좌/우 바라보기(플립)
        if (x > 0.01f) sr.flipX = false;
        else if (x < -0.01f) sr.flipX = true;
    }

    void Shoot()
    {
        if (ballPrefab == null || firePoint == null) return;

        Vector3 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m.z = 0f;

        Vector2 dir = (m - firePoint.position).normalized;

        GameObject b = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
        Ball ball = b.GetComponent<Ball>();
        if (ball != null) ball.Init(dir);
    }

    // 보스에 닿으면 죽기
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.GetComponent<BossController>() != null)
        {
            if (GameManager.I) GameManager.I.GameOver();
        }
    }
}
