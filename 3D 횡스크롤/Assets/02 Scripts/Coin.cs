using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //생성되자마자 점프 연출 시작
        StartCoroutine(CoinJump());
    }

    IEnumerator CoinJUmp()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos +

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
