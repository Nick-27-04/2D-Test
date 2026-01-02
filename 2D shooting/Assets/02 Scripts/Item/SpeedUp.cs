using UnityEngine;
using Items;
public class SpeedUp : Item ,IEffect
{
    void DestroyThis()
    {
        Destroy(gameObject);
    }
    public override void DestroyAfterTime()
    {
        Invoke("GetOpaque", 3f);
        Invoke("DestroyThis", 5f);
    }

    public override void ApplyItem()
    {
       GameObject playerObj = GameObject.Find("Player");
       PlayerController playerController = playerObj.GetComponent<PlayerController>();
       playerController.moveSpeed *= 1.25f;
       DestroyThis();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ApplyItem();


        }
    }

    public void GetOpaque()
    {
        Color32 color = GetComponent<SpriteRenderer>().color;
        color.a *= 50;
        GetComponent<SpriteRenderer>().color = color;
    }
}
