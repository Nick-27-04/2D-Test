using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 3;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    public float timeBetSpawn;

    public float yMin = -3.5f;
    public float yMax = 1.5f;
    public float xPos = 20f;

    GameObject[] platforms;
    int currentIndex = 0;

    Vector2 poolPosition = new Vector2 (0, -25f);
    float lastSpawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameover) return;

        //오브젝트 풀링 처리
        if(Time.time>=lastSpawnTime+timeBetSpawn)
        {
            lastSpawnTime = Time.time;
       

           timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

           float yPos = Random.Range(yMin, yMax);

           platforms[currentIndex].SetActive(false);
           platforms[currentIndex].SetActive(true);

           platforms[currentIndex ].transform.position = new Vector2 (xPos, yPos);

            currentIndex++;

            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
