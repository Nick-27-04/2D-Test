using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 2f;  // 각 몬스터 이동속도
    private bool isDead = false;  // 죽었나 확인
    private Rigidbody rb;  //움직이는게 가능하게 만들기
    public GameObject back;  // 거북이 등껍질 오브젝트
    // public GameObject monster;  //몬스터 오브젝트
    public GameObject player;  //플레이어 오브젝트
    public Transform target;  //타깃위치
    bool attackRag = false;  //공격범위 안으로 들어왔는지 확인
    public float randomMoveTime;  //방향전환 시간 설정
    public float x, z, timer;  //위치 시간값 지정
    Vector3 look;  //  바라보는 방향
    private Animator anim;
    public float ZrandomMoveScale, XrandomMoveScale, XrandomMove, ZrandomMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        target = player.transform;
        // Instantiate(monster);
        anim = GetComponentInChildren<Animator>();

        //1.태그 거북이고, 애니메이터가 있을 때만 걷기 시작
        if (CompareTag("Turtle") && anim != null)
        {

            anim.SetBool("isMoving", true);
        }
    }

    void Update()
    {
        if (!isDead && attackRag) // 죽었을 때가 아니며,인식범위 안으로 들어올 때 작동
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);  //바라보는 방향으로 움직인다
            transform.LookAt(target);  //플레이어를 바라본다
        }
        else if (!isDead)  //죽었을 경우 작동 중지
        {
            GumbaMove();
            TurtleMove();
            FlowerMove();
        }
    }

    public void Die()
    {
        if (CompareTag("Gumba"))  // 태그명이 굼바라면
        {
            GumbaManager(false);
        }
        if (CompareTag("Turtle"))  // 태그명이 거북이라면
        {
            TurtleManager();
        }
        if (CompareTag("Flower"))  //  태그명이 꽃이라면
        {
            FlowerManager();
        }
        else //나머지 일반 몬스터들
        {

        }
    }

    bool isWall = false;
    private void OnTriggerEnter(Collider other)
    {
        attackRag = true;  // tirger범위 안으로 들어오면 실행
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;
        if (collision.gameObject.tag == "Wall")
        {
            isWall = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            // 작성하신 normal.y 판정 로직
            if (collision.contacts[0].normal.y < -0.7f)
            {
                Die();

                // 플레이어 튕겨주기
                Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
                if (playerRb != null)
                {
                    playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 7f, 0);
                }
            }
            else
            {
                Debug.Log("플레이어 피격!");
            }
        }
        /* else if (collision.gameObject.CompareTag("Fire"))
         {
             GumbaManager(true);
             Die();
         }*/
    }
    public void GumbaManager(bool fire)  //굼바메니져
    {
        // 1. 애니메이션 트리거 (스위치 켜기)
        GetComponent<Animator>().SetTrigger("isDead");

        // 2. 물리 연출: 찌그러뜨리기 (Scale 변경)
        if (fire == false)
        {
            transform.localScale = new Vector3(1.2f, 0.2f, 1.2f);
        }

        // 3. 물리 연출: 위로 팝! 튀어 오르기
        if (rb != null)
        {
            GetComponent<Collider>().enabled = false; // 콜라이더를 꺼서 바닥 아래로 추락 유도
            rb.linearVelocity = new Vector3(0, 8f, 0); // 위로 점프
        }
        Destroy(gameObject, 3f);  // 3초 뒤 삭제
    }
    public void GumbaMove()  // 굼바의 움직임 설정
    {
        timer += Time.deltaTime;
        if (timer >= randomMoveTime)
        {
            x = Random.Range(XrandomMoveScale, XrandomMove);
            z = Random.Range(ZrandomMoveScale, ZrandomMove);
            look = new Vector3(x, 0, z);
            transform.rotation = Quaternion.LookRotation(look);
            timer = 0;
        }
        else if (isWall)
        {
            x = Random.Range(XrandomMoveScale, XrandomMove);
            z = Random.Range(ZrandomMoveScale, ZrandomMove);
            look = new Vector3(x, 0, z);
            transform.rotation = Quaternion.LookRotation(look);
            timer = 0;
            isWall = false;
        }
        //굼바는 랜덤으로 움직인다
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
    public void TurtleManager()  // 거북이 메니져
    {
        Instantiate(back, transform.position, Quaternion.identity); // 그 자리에 등껍질 생성
        Destroy(gameObject);  // 바로 삭제        
    }
    public void TurtleMove()  //거북이 움직임 설정
    {
        //  거북이는 굼바와 같이 움직인다
        timer += Time.deltaTime;
        if (timer >= randomMoveTime)
        {
            x = Random.Range(XrandomMoveScale, XrandomMove);
            z = Random.Range(ZrandomMoveScale, ZrandomMove);
            look = new Vector3(x, 0, z);
            transform.rotation = Quaternion.LookRotation(look);
            timer = 0;
        }
        else if (isWall)
        {
            x = Random.Range(XrandomMoveScale, XrandomMove);
            z = Random.Range(ZrandomMoveScale, ZrandomMove);
            look = new Vector3(x, 0, z);
            transform.rotation = Quaternion.LookRotation(look);
            timer = 0;
            isWall = false;
        }
        //거북이는 랜덤으로 움직인다
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    public void FlowerManager()  // 꽃 메니져
    {
        GetComponent<Collider>().enabled = false;  //콜라이더를 꺼서 마리오와 겹칠 수 있도록 유도
        GetComponent<Rigidbody>().useGravity = false;  //토관에 걸치는 연출을 위해 아래로 추락은 못하게 함
        GetComponent<Animator>().SetTrigger("isDead");
        Destroy(gameObject, 2f);  // 2초 뒤 삭제
    }
    bool up = true;
    bool i = true;
    public void FlowerMove()  //꽃 움직임 설정
    {

        timer += Time.deltaTime;
        if (timer >= 2f && i)
        {
            transform.Translate(0, 0, 0);
            up = !up;
            i = false;
        }
        if (up && timer >= 4f)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            timer = 0;
            i = true;
        }
        else if (!up && timer >= 4f)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            timer = 0;
            i = true;
        }
    }
}