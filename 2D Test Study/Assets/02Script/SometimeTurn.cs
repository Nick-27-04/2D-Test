using UnityEngine;

public class SometimeTurn : MonoBehaviour
{
    public float speed = 1.0f;//속도
    public float angle = 90.0f; //각도

    public int maxCount = 60;//빈도

    int count = 0; //카운트용 초기값

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() //1초에 50프레임으로 고정
    {
        this.transform.Translate(Vector3.right * speed*Time.fixedDeltaTime);
        count++;
     //   count = count + 1;
     //   count += 1;
     //  Debug.Log(count);
     if (count > maxCount)
        {
            this.transform.Rotate(Vector3.forward * angle);
            count = 0;
        }
    }
}
