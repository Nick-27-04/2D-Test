using UnityEngine;

public class CS_TurtleBackMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 500f; // 회전 속도는 보통 더 높게 잡습니다.

    private bool isMoving = false; // 등껍질이 움직이는 중인지 확인
    private Vector3 moveDirection; // 이동 방향
    Vector3 dir;

    void Update()
    {
        if (isMoving)
        {
            // 1. 앞으로 이동
            transform.Translate(dir * moveSpeed * Time.deltaTime);

            // 2. 등껍질처럼 뱅글뱅글 회전 (시각적 효과)
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어와 부딪혔을 때
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isMoving)
            {
                // 플레이어가 부딪힌 방향의 반대 방향으로 이동 시작
                dir = transform.position - collision.transform.position;
                dir.y = 0; // 공중으로 날아가지 않게 y축 고정
                transform.forward = dir.normalized;

                isMoving = true;
            }
        }

        // 벽(Wall) 레이어에 부딪혔을 때 튕겨나오기
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            // 입사각에 따른 반사각 계산 (물리적인 튕김)
            Vector3 reflectDir = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            reflectDir.y = 0;
            transform.forward = reflectDir;
        }
    }
}
