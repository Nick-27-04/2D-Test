using UnityEngine;
using System.Collections;
using Unity.VisualScripting; // 코루틴을 쓰려면 이게 꼭 필요해!

public class BlockJH : MonoBehaviour
{
    [Header("블록 설정")]


    public bool isInfinite = false; //true면 무한,false면 hitCount만큼만
    public int hitCount = 1;        //칠 수 있는 횟수 (islnfinite가 false일 때만 작동)

    private bool isAnimating = false; //중복 실행 방지용
    private bool isUsed = false; // 완전히 다 썼는지 확인

    public Color usedColor = Color.blue; //다 쓰면 변할 색상
    private Renderer blockRenderer; //블록 외형(색상)을 담당하는 컴포넌트

    public GameObject mushroom;

    PlayerJH player;

    private void Start()
    {
        //시작할 때 Renderer찾기
        blockRenderer = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerJH>();
    }

    public void OnHit()
    {
        if (isAnimating || isUsed) return; // 이미 쳤다면 무시

        StartCoroutine(BounceStep()); //애니메이션 시작

        if (!isInfinite)
        {
            hitCount--;
            if (hitCount == 0)
            {
                isUsed = true;

                Debug.Log("이 블록은 다 사용함");
                ChangeBlockColor();
                Instantiate(mushroom);
                player.rotateCount = false;
                if (mushroom != null)
                {

                    Instantiate(mushroom, transform.position + Vector3.up, Quaternion.identity);
                }
            }
        }
    }

    void ChangeBlockColor()
    {
        if (blockRenderer != null)
        {
            //메테리얼의 색상을 직접 변경합니다.
            blockRenderer.material.color = usedColor;
        }
    }
    IEnumerator BounceStep()
    {
        isAnimating = true;
        float duration = 0.1f;
        float time = 0f;
        Vector3 startPos = transform.position;
        Vector3 targetPos;

        // 플레이어가 아래로 떨어지는 중(Y 속도가 음수)이면서 회전 중일 때만 '찍기'로 판정
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        //bool isSlamming = player.rotateCount && (playerRb);

        if (/*isSlamming*/player.rotateCount)
        {
            // 위에서 찍었을 때: 블록이 아래로 내려갔다 올라옴
            targetPos = startPos + new Vector3(0, -0.5f, 0);
        }
        else
        {
            // 아래에서 머리로 쳤을 때: 블록이 위로 올라갔다 내려옴
            targetPos = startPos + new Vector3(0, 0.5f, 0);
        }

        // 1. 목표 지점으로 이동 (튕기기 시작)
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        // 2. 아주 잠깐 대기
        yield return new WaitForSeconds(0.02f);

        // 3. 원래 위치로 복귀
        time = 0f;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(targetPos, startPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos;
        isAnimating = false;
    }
}