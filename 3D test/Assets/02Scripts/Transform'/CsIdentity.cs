using UnityEngine;

public class CsIdentity : MonoBehaviour
{
    public float rotSpeed = 120f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float amtRot = rotSpeed*Time.deltaTime;
        float h = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * h * amtRot);

        if (Input.GetButtonDown("Fire1"))
        {
        this.transform.rotation = Quaternion.identity;


        } 

    }
}
