using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int hp = 3;
    public float speed = 0.5f;
    //반응거리

    public float reactionDistance = 4f;

    public string idleAnime = "EnemyIdle";
    public string upAnime = "EnemyUp";
    public string downAnime = "EnemyDown";
    public string rightAnime = "EnemyRight";
    public string leftAnime = "EnemyLeft";
    public string deadAnime = "EnemyDead";

    string nowAnime = "";
    string oldAnime = "";

    float axisH;
    float axisV;
    Rigidbody2D rbody;

    bool isActive = false;
    public int arranged = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null )
        {
            if(isActive)
            {
                //플레이어와의 각도 구하기
                float dx =player.transform.position.x - transform.position.x;
                float dy = player.transform.position.y - transform.position.y;
                float rad =Mathf.Atan2(dy,dx);
                float angle = rad*Mathf.Rad2Deg;

                if(angle > -45f && angle <= 45f)
                {

                    nowAnime = rightAnime;
               
                }
                else if (angle > 45f && angle <= 135f)
                {
                    nowAnime = upAnime;
                }
                else if (angle > -135f && angle < -45f)
                {

                    nowAnime = downAnime;
                }
                else
                {
                    nowAnime = leftAnime;
                }

                axisH = Mathf.Cos(rad) * speed;
                axisV = Mathf.Sin(rad) * speed;

            }
            else
            {
                float dist = Vector2.Distance(transform.position, player.transform.position);
                if (dist < reactionDistance)
                {
                     isActive = true;
                
                }
            }
            else if (isActive)
            {
                isActive =false;
                rbody.linearVelocity = Vector2.zero;

            }
        }
    }
}
