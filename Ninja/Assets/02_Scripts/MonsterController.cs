using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public int DamageAmount = 1;
    public int MaxHealth = 3;
    public int CurrentHealth;
    bool _isDead = false;

    // 몬스터 처치 시 점수\
    public int scoreValue = 100;

    Transform _target;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;

    public ScoreManager scoreManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;

        _rigidbody2D =GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null )
        {
            _target = player.transform;
        }
        else
        {
            Debug.LogError("플레이어 없어요!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_isDead || _target == null) return;

        Vector2 direction = (_target.position - transform.position).normalized;

        _rigidbody2D.MovePosition(_rigidbody2D.position + direction * MoveSpeed * Time.fixedDeltaTime);

        if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController pController = GetComponent<PlayerController>();

            if (pController != null)
            {

            }
        }
    }


}



