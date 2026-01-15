using UnityEngine;

public class CS_PlayerMove : MonoBehaviour
{
    float axisH;
    float axisV;
    public float moveSpeed = 3f;
    CS_Joystick joystick;
    bool isMoving = false;
    Rigidbody2D rbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");              
        }
    }
    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
    private void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2(axisH, axisV) * moveSpeed;
    }
}
