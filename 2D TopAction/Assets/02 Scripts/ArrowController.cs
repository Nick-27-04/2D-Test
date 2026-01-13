using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float deleteTime = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,deleteTime);
    }

    // Update is called once per frame
    private void OnCOllisionEnter2D(Collider2D collision)
    {
        transform.SetParent(collision.transform);
        {
            transform.SetParent (collision. transform);

            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody2D>().simulated =false;

        }
    }
}
