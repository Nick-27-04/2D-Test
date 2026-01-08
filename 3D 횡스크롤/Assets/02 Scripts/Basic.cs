using Unity.VisualScripting;
using UnityEngine;

public class Basic : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right *moveSpeed* Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 위로 팍! 때려주는 힘 (Impulse 방식)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // 점프했으니까 이제 땅이 아니야!
            isGrounded = false;
        }
    }
   

}
