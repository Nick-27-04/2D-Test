using UnityEngine;
using System.Collections; // 코루틴을 쓰려면 이게 꼭 필요해!

public class Block : MonoBehaviour
{
    [Header("블록 설정")]

  
    public bool isInfinite = false; //true면 무한,false면 hitCount만큼만
    public int hitCount = 1;        //칠 수 있는 횟수 (islnfinite가 false일 때만 작동)

    private bool isAnimating = false; //중복 실행 방지용
    private bool isUsed = false; // 완전히 다 썼는지 확인

    public Color usedColor = Color.blue; //다 쓰면 변할 색상
    private Renderer blockRenderer; //블록 외형(색상)을 담당하는 컴포넌트

    private void Start()
    {
        //시작할 때 Renderer찾기
        blockRenderer = GetComponent<Renderer>();
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
                isUsed =true;
                
                Debug.Log("이 블록은 다 사용함");
                ChangeBlockColor();
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
        isAnimating =true;

        Vector3 startPos = transform.position; //현제 위치 저장
        Vector3 targetPos = startPos + new Vector3(0, 0.5f, 0); //
        // 1. 위로 이동하는 로직
        float duration = 0.1f;
        float time = 0f;

        while (time < duration)
        {
            //Lerp는 'A에서 B까지 비율(time)만큼 이동'하는 함수
            transform.position = Vector3.Lerp(startPos, targetPos, time/ duration);
            time += Time.deltaTime;  //프레임마다 시간 더하기
            yield return null; //다음 프레임까지 대기
        }
        transform.position = targetPos;

        // 2. 잠시 아주 잠깐 대기
        yield return new WaitForSeconds(0.02f);

        time = 0f;
        while(time < duration)
        {
            transform.position = Vector3.Lerp(targetPos, startPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos; // 원래 위치인 startPos로 고정

        isAnimating = false;
        
    }
}