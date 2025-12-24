using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f,dropSpeed*Time.deltaTime, 0f);

        if (transform.position.y < -1f)
        {
            Destroy(gameObject);

        }
    }
}
