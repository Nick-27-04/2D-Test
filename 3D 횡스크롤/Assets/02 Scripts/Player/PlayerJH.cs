using System.Collections;
using UnityEngine;

public class PlayerJH : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    bool die = false;
    bool touchMonster = false;

    bool getMushroom = false;
  //  public Material normalMaterial;   // 평소 모습
  //  public Material powerUpMaterial;  // 파워업 모습
    public bool rotateCount = false;

    // 변수명 변경: 유니티 내부 변수명(renderer)과 충돌 피하기 위함
    private MeshRenderer myRenderer;
    bool getItem = false;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        myRenderer = GetComponent<MeshRenderer>();

        // 자기 자신에 대한 참조는 굳이 Find할 필요 없이 'this'나 변수 생략으로 가능합니다.
    } // <- Start 함수가 여기서 닫혀야 합니다.

    void Update()
    {
        if (die) return;

        // 스페이스바 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            anim.SetBool("isJumping", true);
        }

        // 공중에서 X키 회전 공격 (내려찍기)
        if (Input.GetKeyDown(KeyCode.X) && !isGrounded)
        {
            rotateCount = true;
            StartCoroutine(RotateCharacter(0.5f));
        }
    }

    IEnumerator RotateCharacter(float duration)
    {
        float elapsed = 0f;
        Vector3 startRotation = transform.eulerAngles;

        //rotateCount = true; // 회전 시작 시 true

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            // X축 회전 (내려찍기 느낌)
            float xRotation = Mathf.Lerp(0, 360, elapsed / duration);
            transform.eulerAngles = new Vector3(xRotation, startRotation.y, startRotation.z);
            yield return null;
        }

        // 회전 끝난 후 아래로 강하게 힘을 가함
        rb.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);

        //rotateCount = false; // 회전 종료 시 false
    }

    private void FixedUpdate()
    {
        if (die) return;

        float x = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.RightArrow)) x = 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) x = -1f;
        if (Input.GetKey(KeyCode.UpArrow)) z = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) z = -1f;

        // 애니메이션 및 방향 회전
        if (Mathf.Abs(x) > 0.01f || Mathf.Abs(z) > 0.01f)
        {
            anim.SetBool("isRunning", true);
            float angle = transform.eulerAngles.y;

            if (Mathf.Abs(x) > 0.01f && Mathf.Abs(z) > 0.01f)
            {
                if (z > 0) angle = (x > 0) ? 45f : -45f;
                else angle = (x > 0) ? 135f : -135f;
            }
            else if (Mathf.Abs(z) > 0.01f)
            {
                angle = (z > 0) ? 0f : 180f;
            }
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

        // 이동 물리 연산
        Vector3 vel = rb.linearVelocity;
        vel.x = x * moveSpeed;
        vel.z = z * moveSpeed;
        rb.linearVelocity = vel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 바닥/블록 착지 확인
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block"))
        {
            if (collision.contacts[0].normal.y > 0.5f)
            {
                isGrounded = true;
                anim.SetBool("isJumping", false);
            }
        }

        // 블록 충돌
        if (collision.gameObject.CompareTag("Block"))
        {
            Block block = collision.gameObject.GetComponent<Block>();
            if (block != null)
            {
                // 블록 스크립트의 OnHit 호출 (플레이어 Y값 전달)
                block.OnHit(transform.position.y);
            }
        }

        // 아이템 획득
        if (collision.gameObject.CompareTag("mushroom"))
        {
            transform.localScale = new Vector3(50f, 50f, 50f);
            Destroy(collision.gameObject);
            getMushroom = true;
        }

      //  if (collision.gameObject.CompareTag("FireFlower"))
        {
      //      FireFlower();
      //      Destroy(collision.gameObject);
        }

        // 사망 판정
        if (touchMonster && !getMushroom)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            if (getItem)
            {
                getItem = false;
          //      myRenderer.material = normalMaterial;
            }
            else if (getMushroom)
            {
                getMushroom = false;
                transform.localScale = new Vector3(1f, 1f, 1f); // 원래 크기로 (필요시 조절)
            }
            else
            {
                touchMonster = true;
                Die();
            }
        }
    }
    // PlayerJH.cs에 추가
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block") && rotateCount)
        {
            Block block = collision.gameObject.GetComponent<Block>();
            if (block != null)
            {
                // 블록 위에 서 있는 동안 X키를 눌러 rotateCount가 true가 되면 실행됨!
                block.OnHit(transform.position.y);
            }
        }
    }

    void Die()
    {
        if (die) return;
        die = true;
        moveSpeed = 0f;
        GetComponent<Collider>().enabled = false;
        rb.linearVelocity = new Vector3(0, 5f, 0); // 위로 살짝 튀었다가 추락
        anim.SetBool("isJumping", true);
    }

  //  public void FireFlower()
 //   {
  //      gameObject.tag = "FireMario";
  //      getItem = true;
  //      myRenderer.material = powerUpMaterial;
  //  }
}