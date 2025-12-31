using System.Collections;
using UnityEngine;

public class AutoWork : MonoBehaviour
{
    public static long autoMoneyIncreaseAmount = 10;
    public static long autoIncreasePrice = 1000;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Work());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator Work()
    {
        while (true)
        {
            GameManager.gm.money += autoMoneyIncreaseAmount;

            yield return new WaitForSeconds(1f);
        }
    }
}
