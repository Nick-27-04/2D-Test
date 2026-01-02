using UnityEngine;

public class Player : MonoBehaviour
{
    float health = 100f;

    void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Enemy")

        {
         TakeDamage(10);
         Debug.Log("health:" + health);
         Destroy(collision.gameObject);
        }
    }

}
