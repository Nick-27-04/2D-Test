using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,2f);
        //Invoke("함수명", 2f);
        StartCoroutine("함수명");
    }

    /*
    IEnumerator Test()
    {
        yield return null;
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
