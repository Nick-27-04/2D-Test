using UnityEngine;

public class CsMove : MonoBehaviour
{
    public float speed = 20f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        h = h * speed*Time.deltaTime;
        v = v * speed * Time.deltaTime;


        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.forward * v);

       // transform.Translate(new Vector3(h, 0f, v));


    }
}
