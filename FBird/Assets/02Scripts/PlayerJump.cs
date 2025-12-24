using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJump : MonoBehaviour
{
    public float jumpPower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0f,jumpPower,0f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
