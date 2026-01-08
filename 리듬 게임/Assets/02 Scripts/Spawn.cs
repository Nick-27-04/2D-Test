using UnityEngine;

public class Spawn : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(5, 13);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
