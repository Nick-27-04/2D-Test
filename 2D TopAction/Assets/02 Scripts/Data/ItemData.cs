using UnityEngine;

public enum ItemType
{
    arrow,
    key,
    life,

}
public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;
    public int arraged = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(type ==ItemType.key)
            {
                ItemKeeper.hasKeys += 1;

            }

            else if (type == ItemType.key)
            {
                ArrowShoot shoot = collision.gameObject.GetComponent<ArrowShoot>();
                ItemKeeper.hasKeys += count;

            }
            else if(type == ItemType.life)
            {
                if(PlayerController.hp<3)
                {
                    PlayerController.hp++;
                    PlayerPrefs.SetInt("PlayerHp",PlayerController.hp);
                }
            }

            //¾ÆÀÌÅÛ È¹µæ ¿¬Ãâ
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
            itemBody.gravityScale = 2.5f;
            itemBody.AddForce(new Vector2(0,6),ForceMode2D.Impulse);
            Destroy(gameObject, 0.5f);

        }
    }

}
