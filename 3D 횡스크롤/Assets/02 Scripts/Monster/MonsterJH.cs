using UnityEngine;

public class MonsterJH : MonoBehaviour
{
    public float moveSpeed = 2f;  // 각 몬스터 이동속도
    private bool isDead = false;  // 죽었나 확인
    private Rigidbody rb;  //움직이는게 가능하게 만들기
    public GameObject back;  // 거북이 등껍질 오브젝트

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isDead) // 죽었을 때는 이동 중지
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
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

        /*if (isDead) return; // 중복 죽음 방지
        isDead = true;

        // 1. 애니메이션 트리거 (스위치 켜기)
        GetComponent<Animator>().SetTrigger("isDead");

        // 2. 물리 연출: 찌그러뜨리기 (Scale 변경)
        transform.localScale = new Vector3(1.2f, 0.2f, 1.2f);

        // 3. 물리 연출: 위로 팝! 튀어 오르기
        if (rb != null)
        {
            GetComponent<Collider>().enabled = false; // 콜라이더를 꺼서 바닥 아래로 추락 유도
            rb.linearVelocity = new Vector3(0, 8f, 0); // 위로 점프
        }

        // 4. 부모가 있으면 부모까지 포함해서 삭제
        GameObject targetToDestroy = transform.parent != null ? transform.parent.gameObject : gameObject;
        Destroy(targetToDestroy, 1.0f);*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

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
      //  else if (collision.gameObject.CompareTag("Fire"))
        {
       //     GumbaManager(true);
       //     Die();
        }
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
    public void TurtleManager()  // 거북이 메니져
    {
        Instantiate(back, transform.position, Quaternion.identity); // 그 자리에 등껍질 생성
        Destroy(gameObject);  // 바로 삭제        
    }
    public void FlowerManager()  // 꽃 메니져
    {
        GetComponent<Collider>().enabled = false;  //콜라이더를 꺼서 마리오와 겹칠 수 있도록 유도
        GetComponent<Rigidbody>().useGravity = false;  //토관에 걸치는 연출을 위해 아래로 추락은 못하게 함
        GetComponent<Animator>().SetTrigger("isDead");
        Destroy(gameObject, 2f);  // 2초 뒤 삭제
    }
}