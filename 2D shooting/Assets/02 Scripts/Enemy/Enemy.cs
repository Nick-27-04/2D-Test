using UnityEngine;

public class Enemy : MonoBehaviour
{

    float health = 50f;
   protected float speed = 100f;

    public float Health
   { 
        get  { return health; }
      //  set { health = value; }
    
    }

    private void Start()
    {
        Move();    
    }

    void TakeDamage(float Value)
    {
        health -= Value;

        if (health <= 0)
        {
            Die();
        }
    }


    /*
    public float GetHealth()
    { 
      return health;
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        { 
         TakeDamage(10);
         TakeDamage(10f);
         Debug.Log("health :" + health);
         collision.gameObject.SetActive(false);
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }

    public virtual void Move()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);

    }

}

