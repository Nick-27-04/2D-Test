using System;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       if(DateTime.Now.Hour<12)
        {
            Debug.Log("오전임");

        }

        if (12 <= DateTime.Now.Hour) ;
        {
            Debug.Log("오후임");

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
