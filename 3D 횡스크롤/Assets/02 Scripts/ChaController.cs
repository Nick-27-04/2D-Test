using UnityEngine;

public class ChaController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 5f; // 점프 힘
    [SerializeField] private bool isGrounded;    // 땅에 닿아있는지 확인

    void Start()
    {
        //리짓바티를 쓰겠다.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //오른쪽으로 이동
        transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);

        // 1. 스페이스바를 눌렀고 + 땅에 닿아 있을 때만 점프


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 위쪽(Vector3.up) 방향으로 즉각적인 힘(Impulse)을 가함
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // 점프하는 순간 땅에서 떨어짐
        }

    }
    // 바닥과 부딪히는 순간을 감지
    private void OnCollisionEnter(Collision collision)
    {
        // 바닥의 태그가 "Ground"인 경우에만 다시 점프 가능하게 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}

