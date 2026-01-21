using System.Collections;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce = 5f;
    public float rotateSpeed = 2f;
    private Rigidbody rb;
    private bool isGrounded;
    //PlayTime playTime;
    bool touchMonster = false;
    public bool rotateCount = false;
    public float ratateSpeed = 10f;
    bool getMushroom = false;
    public Material normalMaterial;   // 평소 모습
    public Material powerUpMaterial;  // 파워업 모습
    bool getItem = false;
    MeshRenderer renderer;
    GameObject fire;
    private Animator anim;
    void Start()
    {
        //오브젝트의 Rigidbody 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); // 시작할 때 애니메이터 가져오기
        renderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {

        //스페이스바를 누르고 + 바닥에 있는 상태일 때 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 힘을 가함
            isGrounded = false; //점프하는 순간 바닥에서 떨어짐
            //anim.SetBool("isJumping", true); // ( 선택사항) = 점프 애니메이션이 있다면 추가
        }
        //바닥이 아닌 상태에서 x키를 누르면 한바퀴 회전하며 아래로 힘을 가함
        if (Input.GetKeyDown(KeyCode.X) && !isGrounded)
        {
            StartCoroutine(RotateCharacter(0.5f));
            rotateCount = false;


        }
        if (Input.GetKeyDown(KeyCode.Z) && getItem)
        {
            if (gameObject.tag == "FireMario")
            {
                Instantiate(fire, transform.position, Quaternion.identity);
                fire.transform.Translate(Vector3.forward);
            }
        }
        if (/*playTime.timeOver ||*/ touchMonster)
        {
            if (getMushroom == false)
            {
                Die();
            }
        }
    }
    IEnumerator RotateCharacter(float duration)  // 엉덩방아 코루틴
    {
        rotateCount = true;
        float elapsed = 0f;
        Vector3 startRotation = transform.eulerAngles;

        // 설정한 지속 시간(duration) 동안 반복
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime; // 매 프레임의 시간을 더함

            // Mathf.Lerp를 이용해 0도에서 360도 사이의 값을 시간 비율(0~1)에 따라 계산
            // elapsed / duration은 시간이 흐를수록 0에서 1로 변합니다.
            float zRotation = Mathf.Lerp(0, 360, elapsed / duration);

            // 계산된 z축 회전 값을 캐릭터의 transform에 적용
            // (기존 x, y 각도는 유지하고 z값만 변경)
            transform.eulerAngles = new Vector3(startRotation.x, startRotation.y, zRotation);
            rb.AddForce(Vector3.down * jumpForce * 2, ForceMode.Impulse);

            // 다음 프레임까지 실행을 멈추고 대기 (이게 있어야 애니메이션처럼 보임)
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        float x = 0f;
        float z = 0f;

        // 키 입력 
        if (Input.GetKey(KeyCode.RightArrow)) x = 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) x = -1f;
        if (Input.GetKey(KeyCode.UpArrow)) z = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) z = -1f;

        // --- 애니메이션 및 회전 로직 시작 ---
        if (Mathf.Abs(x) > 0.01f || Mathf.Abs(z) > 0.01f)
        {
            anim.SetBool("isRunning", true);
            float angle = transform.eulerAngles.y; // 기본값 유지

            // 1. [중요] 대각선 체크를 가장 먼저 해야 함!
            if (Mathf.Abs(x) > 0.01f && Mathf.Abs(z) > 0.01f)
            {
                if (z > 0) angle = (x > 0) ? 45f : -45f;
                else angle = (x > 0) ? 135f : -135f;
            }
            // 2. 그 다음 상하 체크
            else if (Mathf.Abs(z) > 0.01f)
            {
                angle = (z > 0) ? 0f : 180f;
            }
            // 3. 마지막으로 좌우 체크
            else if (Mathf.Abs(x) > 0.01f)
            {
                angle = (x > 0) ? 90f : -90f;
            }

            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        // 물리 이동 
        Vector3 vel = rb.linearVelocity;
        vel.x = x * moveSpeed;
        vel.z = z * moveSpeed;
        rb.linearVelocity = vel;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //1. 충돌한 물체가 'Ground' 태그를 가지고 있다면 다시 점프 가능
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //anim.SetBool("isJumping",false); //바닥에 닿았으니 점프 스위치를 끈다!
            Debug.Log("바닥에 닿음");
        }

        //2.블록 체크
        if (collision.gameObject.CompareTag("Block")) // 블록 태그 확인
        {
            Debug.Log("블록을 쳤다");
            //머리를 박으면 상승이 멈추니 여기서도 점프 애니메이션을 꺼주는 게 자연스러울지도
            Block block = collision.gameObject.GetComponent<Block>();
            if (block != null)
            {
               block.OnHit(transform.position.y);
            }
            anim.SetBool("isJumping", false);
            //anim.SetBool("isJumping", false);

        }
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            StartCoroutine("GetMushroom", 3f);
            Destroy(collision.gameObject);
            getMushroom = true;
        }
        if (collision.gameObject.CompareTag("FireFlower"))
        {
            Destroy(collision.gameObject);
            FireFlower();  // 불 꽃 함수 실행
        }
    }
    IEnumerator GetMushroom(float duration)  //버섯 먹을때 연출
    {
        Vector3 startRotation = transform.eulerAngles;

        // 설정한 지속 시간(duration) 동안 반복
        while (10 < duration)
        {
            duration += Time.deltaTime; // 매 프레임의 시간을 더함

            // 계산된 z축 회전 값을 캐릭터의 transform에 적용
            // (기존 x, y 각도는 유지하고 z값만 변경)
            transform.localScale = new Vector3(duration, duration, duration);

            // 다음 프레임까지 실행을 멈추고 대기 (이게 있어야 애니메이션처럼 보임)
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)  //몬스터와 터치여부 확인
    {
        touchMonster = true;  // tirger범위 안으로 들어오면 실행
    }
    void Die()  //죽는 경우
    {
        moveSpeed = 0f;
        GetComponent<Collider>().enabled = false; // 콜라이더를 꺼서 바닥 아래로 추락 유도
        rb.linearVelocity = new Vector3(0, 8f, 0);
        anim.SetBool("isJumping", true);
    }
    public void FireFlower()
    {
        gameObject.tag = "FireMario";  // 태그를 불마리오로 설정
        getItem = true;  //아이템을 먹은 상태로 바꿔줌
        renderer.material = powerUpMaterial;  //  불마리오 머티리얼로 바꿔줌
    }
}
