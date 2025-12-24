using System.Collections;

using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    Transform target;
    float spawnRate;
    float timeAfterSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;

        // ¾Æ Áý°¡°í ½Í´Ù~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Àú³á ¹¹ ¸ÔÁö..
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate) 
        {
           timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);

            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);


        }
    }
}
