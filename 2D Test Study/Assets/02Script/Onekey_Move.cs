using UnityEngine;

public class Onekey_Move : MonoBehaviour
{
    public float speed = 2f;

    float vx = 0;
    float vy = 0;
    bool leftflag = false;

    Rigidbody2D rbody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    // Update is called once per frame
    void Update()
    {
        vx = 0;
        vy = 0;

        if (Input.GetKey("right"))
        {
            vx = speed;
            leftflag = false;
        }
        if (Input.GetKey("left"))
        {
            vx = -speed;
            leftflag = true;
        }
        if (Input.GetKey("up"))
        {
            vx = speed;
            leftflag = true;
        }
        if (Input.GetKey("down"))
        {
            vx = -speed;
            leftflag = false;
        }

    }

    private void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2(vx, vy);
        this.GetComponent<SpriteRenderer>().flipX = leftflag;
        // rbody.AddForce(new Vector2(vx, vy));    
    }
}