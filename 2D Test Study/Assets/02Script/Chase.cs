using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public string targetObjectName; 
    public GameObject go;
    // public float dis;
    Rigidbody2D rbody; 

    public float speed = 1;
    Vector3 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       go =  GameObject.Find("ballon_1_0");
        rbody = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        Vector3 pos2 =go.transform.position;

       //  this.transform.position = GameObject.Find("ballon_1_0").transform.position;


        // Vector3.Distance(pos, pos2); // °Å¸®   
        // dis = (pos - pos2).magnitude;       

       dir = (pos2 - pos).normalized;
        this.rbody.linearVelocity = dir*speed;

        this.GetComponent<SpriteRenderer>().flipX = dir.x < 0;


    }
}
