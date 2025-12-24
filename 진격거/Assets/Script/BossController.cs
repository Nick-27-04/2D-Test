using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] Transform player;

    [Header("Stats")]
    [SerializeField] int maxHp = 50;
    [SerializeField] float moveSpeed = 2f;
    [Header("UI")]
    [SerializeField] DamagePopup damagePopupPrefab;
    [SerializeField] Vector3 popupOffset = new Vector3(0f, 1.2f, 0f);


    int hp;
    Rigidbody2D rb;

    public int MaxHP => maxHp;
    public int HP => hp;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 p = player.position;
        Vector2 t = rb.position;

        t.x = Mathf.MoveTowards(t.x, p.x, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(t);
    }

    public void SetPlayer(Transform p)
    {
        player = p;
    }

    public void TakeHit(int dmg)
    {
        if (damagePopupPrefab != null)
        {
            DamagePopup p = Instantiate(damagePopupPrefab, transform.position + popupOffset, Quaternion.identity);
            p.Set(dmg);
        }

        hp -= dmg;
        if (hp < 0) hp = 0;

        if (hp == 0)
        {
            if (GameManager.I) GameManager.I.Win();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        // 플레이어랑 닿으면 게임오버
        if (c.collider.GetComponent<PlayerController>() != null)
        {
            if (GameManager.I) GameManager.I.GameOver();
        }
    }
}
