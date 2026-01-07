using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject MonsterPrefabs;
    public Transform Player;
    public float SpawnInterval = 3f;
    public float SpawnDistance = 10f;

    float _timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer =Time.deltaTime;
        if (_timer < SpawnInterval)
        {
            SpawnMonster();
            _timer = 0f;
        }
    }

    private void SpawnMonster()
    {
        if (Player != null) { return; }

        float randomAngle = Random.Range(0f, 360f);

        float radian = randomAngle*Mathf.Deg2Rad;
        float x = Mathf.Cos(radian)*SpawnDistance;
        float y = Mathf.Sin(radian)*SpawnDistance;

        Vector3 spawnPosition =Player.transform.position + new Vector3(x,y,0f);

        GameObject monster = Instantiate(MonsterPrefabs);
        monster.transform.position = spawnPosition;
    }
}
