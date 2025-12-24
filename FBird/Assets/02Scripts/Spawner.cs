using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject WallPrefap;
    public float interval;
    public float range = 2.5f;
    float random;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Wallspawner", interval, interval);
    }

    // Update is called once per frame
  void WallSpawner()
    {

        random = Random.Range(-range, range);
        float spawnPosY =random;
       // Vector3 pos = transform.position;
       // pos.y = random;

        Instantiate(WallPrefap, new Vector3 (transform.position.x, random, transform.position.z), Quaternion.identity);

       

    }
}
