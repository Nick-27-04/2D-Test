using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //오브젝트의 Rigidbody 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        //스페이스바를 누르고 + 바닥에 있는 상태일 때 점프
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isGrounded = false; //점프하는 순간 바닥에서 떨어짐
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체가 'Ground' 태그를 가지고 있다면 다시 점프 가능
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded=true;
        }
    }
}
