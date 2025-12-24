using UnityEngine;

public class SometimeRandomPrefap : MonoBehaviour
{
    public GameObject newPrefab;
    public float intervalSec = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("CreatePrefab", intervalSec, intervalSec);
    }

    void CreatePrefab() 
    {
        // 스프라이트의 크기를 알수있는 방법

        Vector3 area = GetComponent<SpriteRenderer>().bounds.size;
        Vector3 newPos = transform.position;
        newPos.x += Random.Range(-area.x / 2, area.x / 2);
        newPos.y += Random.Range(-area.y / 2, area.y / 2);
        newPos.z = 1f;

        GameObject newGameObject = Instantiate(newPrefab);
        newGameObject.transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
