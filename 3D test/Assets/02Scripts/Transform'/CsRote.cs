using UnityEngine;

public class CsRote : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        h = h*rotateSpeed*Time.deltaTime;   
        v = v*rotateSpeed*Time.deltaTime;

        transform.Translate(Vector3.forward * v);
        transform.Rotate(Vector3.up * h);
    }
}
