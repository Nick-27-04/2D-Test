using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    public float jumpHeight = 2.0f; //얼마나 높이 튈지
    public float duration = 0.5f; //튀어 올랐다 내려오는 총 시간 duration = 지속시간,지속,소요시간
    public float rotateSpeed = 720f; // 회전 속도


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //생성되자마자 점프 시작!
        StartCoroutine(CoinJump());

        //2.파괴하기
        Destroy(gameObject,duration+0.1f);
    }
   
       // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
      //  transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime);
    }


    IEnumerator CoinJump()
    { 
       Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + Vector3.up * jumpHeight;

        float halfDuration = duration / 2f;
        float elapsed = 0f;

        //1. 위로 포물선 그리며 올라가기 
        while (elapsed < duration / 2)
        { 
          transform.position = Vector3.Lerp(startPos, targetPos, elapsed/(duration/2));
            elapsed += Time.deltaTime;
            yield return null;
        }

        //2.다시 아래로 내려오기
        elapsed = 0;
        while (elapsed < duration / 2)
        {
            transform.position = Vector3.Lerp(targetPos, startPos, elapsed / (duration / 2));
            elapsed += Time.deltaTime;
            yield return null;  
        }
        transform.position = startPos;

       //코인 획득 처리 (점수 추가 등 ) 후 파괴
       Destroy(gameObject);
    }



 
}
