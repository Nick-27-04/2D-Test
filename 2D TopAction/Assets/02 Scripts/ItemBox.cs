using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Sprite openImage;
    public GameObject itemPrefabs;

    public bool isClosed = true;
    public int arrangeld = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isClosed && collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = openImage;
            isClosed = false;
            if (itemPrefabs != null)
            { 
                Instantiate(itemPrefabs,transform.position, Quaternion.identity);

            }
        }
    }
}
