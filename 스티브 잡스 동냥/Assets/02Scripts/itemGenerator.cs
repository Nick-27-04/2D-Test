using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class itemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float spawn = 1f;
    float delta = 0f;

    public int ratio = 2;

    float speed = -3f;

    public void SetParameter(float spawn, float speed,int ratio)
    {
    this.spawn = spawn;
        this.speed = speed;
        this.ratio = ratio;
    }

    private void Update()
    {
        delta += Time.deltaTime;

        if(delta > spawn )
        {
            delta = 0;
            GameObject item = Instantiate( applePrefab );
            

            float x = Random.Range(-1, 2);
            float z =  Random.Range(-1, 2);
         
            item.transform.position = new Vector3(x,4f,z);
        }

        delta += Time.deltaTime;

        if (delta > spawn)
        {
            delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if(dice<= ratio) 
            {
                item = Instantiate( bombPrefab );
            }
            else
            {
                item = Instantiate(applePrefab);
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);

            item.transform.position = new Vector3(x, 4f, z);

            item.GetComponent<ItemController> ().dropSpeed = speed; 
        }
    }

}
