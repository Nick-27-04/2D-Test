using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float jumpHeight = 2.0f;
    public float duration = 0.5f;
    public float rotateSpeed = 720f;

    private bool isSlammed = false; // ✅ 방향 저장용 변수

    // ✅ 블록에서 방향을 설정해줄 함수
    public void SetupDirection(bool slammed)
    {
        isSlammed = slammed;
    }

    void Start()
    {
        StartCoroutine(CoinJump());
        Destroy(gameObject, duration + 0.1f);
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    IEnumerator CoinJump()
    {
        Vector3 startPos = transform.position;
        // ✅ 방향에 따라 목표 위치 설정 (위에서 찍으면 아래로, 아래서 치면 위로)
        Vector3 moveDir = isSlammed ? Vector3.down : Vector3.up;
        Vector3 targetPos = startPos + moveDir * jumpHeight;

        float elapsed = 0f;
        float halfDuration = duration / 2f;

        // 1. 목표 지점까지 이동
        while (elapsed < halfDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / halfDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 2. 다시 원래 위치(블록 안쪽)로 돌아오기
        elapsed = 0;
        while (elapsed < halfDuration)
        {
            transform.position = Vector3.Lerp(targetPos, startPos, elapsed / halfDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}