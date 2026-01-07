using UnityEngine;

public class Shurikan : MonoBehaviour
{
    public float speed = 10f;
    public int Damage = 1;
    public float LifeTime = 3f;

    Vector2 _direction;
    float _timer = 0f;
    float _rotateSpeed = 720f;

    //표창 초기화 (방향설정)
    public void Init(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
        transform.Translate(_direction*speed*Time.deltaTime,Space.World);

        _timer += Time.deltaTime;
        if (_timer >= LifeTime)
        {
             Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            MonsterController monster = collision.GetComponent<MonsterController>();
            if (monster != null)
            {
                monster.TakeDamage(Damage);
            }
        }

        Destroy(gameObject); 
    }
}
