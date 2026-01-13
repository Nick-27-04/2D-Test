using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //오브젝트의 Rigidbody 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); // 시작할 때 애니메이터 가져오기
    }

    // Update is called once per frame
    void Update()
    {    

        //스페이스바를 누르고 + 바닥에 있는 상태일 때 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isGrounded = false; //점프하는 순간 바닥에서 떨어짐
            anim.SetBool("isJumping", true); // ( 선택사항) = 점프 애니메이션이 있다면 추가
        }
    }

    private void FixedUpdate()
    {
        float x = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            x = -1f; 
        }



        //애니메이션 컨트롤 부분
        {
            if (Mathf.Abs(x)> 0.1f) // 이동 입력이 있다면
            {
                anim.SetBool("isRunning", true); //뛰는 애니메이션 켜기

                // 캐릭터가 이동 방향을 바라보게 회전 
                transform.rotation = Quaternion.LookRotation(new Vector3(x, 0f, 0f));
            }
            else 
            {
                anim.SetBool("isRunning", false); //뛰는 애니메이션 끄기
            }
            //---------------------------------------
        }

        Vector3 vel = rb.linearVelocity;
        vel.x = x * moveSpeed;
        rb.linearVelocity = vel;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //1. 충돌한 물체가 'Ground' 태그를 가지고 있다면 다시 점프 가능
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded=true;
            anim.SetBool("isJumping",false); //바닥에 닿았으니 점프 스위치를 끈다!
        }

        //2.블록 체크
        if (collision.gameObject.CompareTag("Block")) // 블록 태그 확인
        {
            if (collision.contacts[0].normal.y<0.7f)
            {

                Debug.Log("블록을 쳤다");
                //머리를 박으면 상승이 멈추니 여기서도 점프 애니메이션을 꺼주는 게 자연스러울지도
                Block block = collision.gameObject.GetComponent<Block>();
                if (block != null)
                {

                    block.OnHit();
                }


                anim.SetBool("isJumping", false);

            }

        }
    }
}
