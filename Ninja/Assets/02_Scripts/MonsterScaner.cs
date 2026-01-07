using UnityEngine;

public class MonsterScaner : MonoBehaviour
{
    public float ScanRange = 10f;
    public LayerMask EnemyLayer;

    Collider2D[] _hitResults = new Collider2D[10];  //스캔 결과를 저장할 변수


    public Transform GetNearesEnemy()
    {
        //스캔 중심 위치

        int hitCount = Physics2D.OverlapCircleNoneAlloc(
                        transform.position,
                        ScanRange,
                        _hitResults,
                        EnemyLayer

            );

        if( hitCount <= 0 )
        {
            return null;
        }

        //담진 첫번째 obj를 임의에 기준으로 잡는다.

        Transform nearest = _hitResults[0]. transform;
        Debug.Log
        float minDistance = Vector2.Distance(transform.position, nearest.position);  
        //임의에 최소거리 기준이 되는 값

        for ( int i = 1; i< _hitResults.Length;i++)
        {
            Transform enemy = _hitResults[i]. transform;
            float distance =
                Vector2.Distance(transform.position,enemy.position);
            if(distance< minDistance)
            {
                nearest = enemy;
                minDistance = distance;
            }

        }
        return nearest;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
