using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TestMoveGravity : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 8f;
    public GameObject newPrefab;

    public float throwX = 4f;
    public float throwY = 8f;
    public float offsetY = 1f;
    public Sprite kim;
    float vx = 0f;

    bool groundflag = false;
    bool leftFlag = false;

    Vector2 newPos;

    Rigidbody2D rbody;

    GameObject newGameObject;

  



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        if (Input.GetKey("right")) 
        {
            vx = speed;
            leftFlag = false;
        }

       
        if (Input.GetKey("left"))
        {
            vx = -speed;
            leftFlag = true;    
        }

        if (Input.GetButtonDown("Jump") && groundflag)
        {
            rbody.AddForce(new Vector2(0f, jumpPower),ForceMode2D.Impulse);


        }

        if (Input.GetMouseButtonDown(0)) 
        {
          //  rbody.AddForce(new Vector2());
          newPos = this.transform.position;
            newPos.y += offsetY;


            newGameObject = Instantiate(newPrefab);
            newGameObject.transform.position = newPos;

         Rigidbody2D rbody2 =  newGameObject.GetComponent<Rigidbody2D>();

            if (leftFlag) 
            {
                rbody2.AddForce(new Vector2(-throwX,throwY),ForceMode2D.Impulse);
            }
            else 
            {
                rbody2.AddForce(new Vector2(throwX, throwY), ForceMode2D.Impulse);
            }
        }


        rbody.linearVelocity = new Vector2(vx, rbody.linearVelocity.y);
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
        this.GetComponent<SpriteRenderer>().sprite = kim;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        groundflag = true;
    
    }
  

    private void OnCollisionExit2D(Collision2D collision)
    {
        groundflag = false;
    }

    private void OnBecameInvisible()
    {
        Destroy(newGameObject);
    }
}
