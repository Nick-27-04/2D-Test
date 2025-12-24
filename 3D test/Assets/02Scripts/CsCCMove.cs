using UnityEngine;
using UnityEngine.EventSystems;

public class CsCCMove : MonoBehaviour
{

    float moveSpeed = 10f;
    float rotateSpeed = 30f;

    Vector3 moveDirection;

    CharacterController cont;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        moveDirection = new Vector3 (0,0,moveSpeed*v*Time.deltaTime);
        // cont.Move(Vector3.forward *moveSpeed* h * Time.deltaTime);

        moveDirection = transform.TransformDirection(moveDirection);

        cont.Move(moveDirection);

        transform.Rotate(Vector3.up *moveSpeed* h * Time.deltaTime);
 
    }
}
