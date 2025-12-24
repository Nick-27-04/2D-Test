using UnityEngine;

public class Collision_Flip : MonoBehaviour
{

    public float speed = 1;

    Rigidbody2D rbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        rbody.linearVelocity = Vector3.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed;
        this.GetComponent<SpriteRenderer>().flipX = speed<0;       
        //Time.timeScale = 0;
        this.gameObject.SetActive(false);    
    }
}
