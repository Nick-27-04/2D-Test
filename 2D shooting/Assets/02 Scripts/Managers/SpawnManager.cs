using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    public Point[] Points = {
        new Point(0,0),
        new Point(1,1),
        new Point(1,-1),
        new Point(-1,1),
        new Point(-1,-1),
        new Point(2,2),
        new Point(2,-2),
        new Point(-2,2),
        new Point(-2,-2),
        new Point(3,3),
        new Point(3,-3),
        new Point(-3,3),
        new Point(-3,-3),
    };





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(GameObject prefab,Vector3 _position)
    {
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = _position;
        enemy.GetComponent<Enemy>().Move();
    }

    public void SpawnRandom()
    {
        GameObject prefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        Vector2 pos = Points[Random.Range(0, Points.Length)].GetPos();
        SpawnEnemy(prefab, pos);
        Invoke("SpawnRandom", 0.3f);
    }
}

