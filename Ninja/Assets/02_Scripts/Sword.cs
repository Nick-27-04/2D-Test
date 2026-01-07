using UnityEngine;
using NUnit;
using System.Collections;
public class Sword : MonoBehaviour
{
    public int Damage = 1;
    public float DamageCooldown = 0.5f;

    List<Collider2D> _hitMonster = new List<Collider2D> ();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            if(!_hitMonster.Contains(collision))
            {
                MonsterController monster = collision.GetComponent<MonsterController>();

                if (monster ! =null)
                {
                    monster.TakeDamage(Damage);
                }
                
            }


            hitMonster.Add(collision);
            StartCoroutine(RemoveFromHitList(collision, DamageCooldown));

        }
    }

    IEnumerator RemoveFromHitList(Collider2D)




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
