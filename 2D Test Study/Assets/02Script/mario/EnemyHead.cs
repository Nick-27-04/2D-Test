using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    monster enemy;

    void Start()
    {
        enemy = GetComponentInParent<monster>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SendMessage("Die");
        }
    }
}
