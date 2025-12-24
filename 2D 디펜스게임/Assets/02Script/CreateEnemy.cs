using System.Collections;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;
    float delay;
    int count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Create());

    }

    IEnumerator Create()
    {
        while(true)
        {
            count++;
            float r =Random.Range(limitMin.y, limitMax.y);
            Vector2 creatingPoint = new Vector2(limitMin.x, r);
            yield return new WaitForSeconds(delay);

            Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);
            delay = 10f/(count+4);

            yield return new WaitForSeconds(delay);

        }
        yield return new WaitForSeconds(delay);

        

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(limitMin, limitMax);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
