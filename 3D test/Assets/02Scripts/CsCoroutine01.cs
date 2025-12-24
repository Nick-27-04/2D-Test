using System.Collections;
using UnityEngine;

public class CsCoroutine01 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire")) 
        {
            StartCoroutine("Exam1");
        }


        IEnumerator Exam()
        {
            yield return new WaitForEndOfFrame();

            FirstCall();

            yield return new WaitForSeconds(2.0f);

            SecondCall();

            void FirstCall() 
            {
                Debug.Log("First");

            }

            void SecondCall()
            {
                Debug.Log("Second");
            }

        }
    }

   

}
