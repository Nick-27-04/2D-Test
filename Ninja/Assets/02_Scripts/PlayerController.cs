using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int MaxHealth = 5;
    public int CurrentHealth;

    Rigidbody2D rd;
    Vector2 _moveDirection;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    bool _isDead = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead) { return; }
        float h = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _moveDirection = new Vector2(h, y);

        if (_moveDirection.magnitude > 0)
        {
            _moveDirection.Normalize();

            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }

        if (h != 0)
        {
            _spriteRenderer.flipX = h < 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        rd.MovePosition(rd.position + _moveDirection * speed * Time.deltaTime);
    }

    private void Die()
    {
        _isDead = true;
        _animator.SetTrigger("Death");

        GetComponent<Collider2D>().enabled = false;
    }

    public void TakeDamage(int damageAmount)
    {
        if (_isDead) { return; }

        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log("PlayHp :" + CurrentHealth);
        }
    }
}