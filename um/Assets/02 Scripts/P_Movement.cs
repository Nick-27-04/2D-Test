using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class P_MOvement : MonoBehaviour
{
    [Header("#Movement Settings")]
    public float moveSpeed = 5f;

    [Space(20f)]
    [Header("#Mouse Rotation")]
    public LayerMask groundLayer;
    public float rotateSpeed = 10f;


    CharacterController controller;
   // Animatior animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit hit,Mathf.Infinity, groundLayer))
        {
            Vector3 targetPosition = hit.point;
            Vector3 direction = (targetPosition - transform.position).normalized;

            if (direction != Vector3.zero) 
            {
                 
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                    targetRotation, rotateSpeed*Time.deltaTime);

            }
        }

    }


    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0.01f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();
        Vector3 moveDirection = cameraRight*horizontal + cameraForward*vertical;
        controller.Move(moveDirection*moveSpeed*Time.deltaTime);
        float currentSpeed = moveDirection.magnitude*moveSpeed;
      //  animator.SetFloat("a_Speed",currentSpeed);
    }
}
