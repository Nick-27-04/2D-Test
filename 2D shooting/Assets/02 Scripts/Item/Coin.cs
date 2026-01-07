using UnityEngine;

public class Coin : Items.Item, IEffect
{
    public override void ApplyItem()
    {
        //coin += 1

       DestroyThis();
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }
    public override void DestroyAfterTime()
    {
        Invoke("GetOpaque", 3f);
        Invoke("DestroyThis", 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("무다다다다닥");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("무다무다");

            ApplyItem();

        }
    }

    public void GetOpaque()
    {
       Color32 color = GetComponent<SpriteRenderer>().color;
        color.a *= 50;
        GetComponent<SpriteRenderer>().color =color;
    }
}
