using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int n1 = 8;
        int n2 = 20;
        int answer;
        answer = n1 * n2;
        answer += 60;
        answer++;
        answer *= 20;
        answer /= 4420;
        answer--;
        answer++;
        answer++;

        string 준서1 = "험어";
        float 준서2 = 40;
        

         준서1 += 준서2;
        Debug.Log(준서1);


        Debug.Log(answer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
