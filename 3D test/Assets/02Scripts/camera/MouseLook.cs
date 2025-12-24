using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 500f;
    public float rotationX;
    public float rotationY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationX += mouseMoveValueX * sensitivity * Time.deltaTime;

        rotationY += mouseMoveValueY * sensitivity * Time.deltaTime;

        if(rotationY > 20f) 
        {
            rotationY = 20f;
        }
        if(rotationY < -30f) 
        {
            rotationY = -30f;
        }
        if (rotationX > 90f)
        {
            rotationX = 90f;
        }
        if (rotationX < -90f)
        {
            rotationX = -90f;
        }

        transform.eulerAngles = new Vector3 (-rotationY, rotationX, 0);


    }
}
