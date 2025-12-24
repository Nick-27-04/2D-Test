using Unity.VisualScripting;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //진격의 거인 다시보기
    //나루토 다시보기
    //사이버펑크 엣지러너 다시보기

    public GameObject applePrefab;
    public float speed = 1f;
    float edge;
    float changeDir = 0.1f;
    float appleDropTime = 1f;
    float count;
    public float maxCount =2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var height = 2*Camera.main.orthographicSize;
        edge = (height * Camera.main.aspect) / 2;

        InvokeRepeating("DropApple",appleDropTime,appleDropTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //  transform.position += Vector3.left * speed * Time.deltaTime;
        //  transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (pos.x < -edge)
        {
            speed = Mathf.Abs(speed);

        }
        else if (pos.x > edge)
        { 
          speed = -Mathf.Abs(speed);    
        
        }

         

    }
    private void FixedUpdate()
    {
        count += Time.deltaTime;
        if (count > maxCount) 
        {
          if(Random.value < changeDir)
            {
                speed *= -1; 

            }

            count = 0f;

        }
    }

    void DropApple()
    {
        Instantiate(applePrefab,transform);

    }
}
