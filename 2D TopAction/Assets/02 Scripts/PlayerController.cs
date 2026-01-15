using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3f;

    public string upAnime = "PlayerUp";
    public string downAnime = "PlayerDown";
    public string rightAnime = "PlayerRight";
    public string leftAnime = "PlayerLeft";
    public string deadAnime = "PlayerDead";

    string nowAnimation = "";
    string oldAnimation = "";

    float axisH;
    float axisV;
    public float angleZ = -90f;

    Rigidbody2D rbody;
    Animator anime;
    bool isMoving = false;

    //데미지 처리
    public static int hp = 3;
    public static string gameState;
    bool inDamage = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        
        anime = GetComponent<Animator>();

        oldAnimation = downAnime;


        gameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {

        if(gameState != "playing" || inDamage)
        {
            return;

        }


        if(isMoving==false)
        {
            axisH = Input.GetAxis("Horizontal");
            axisV = Input.GetAxis("Vertical");
        }

        //키 입력으로 이동 각도 구하기
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH,fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);

        if (angleZ >= -45 && angleZ < 45)
        {
            nowAnimation = rightAnime;
        }

        else if (angleZ >= -135 && angleZ < -45)
        {
            nowAnimation = downAnime;
        }
        else if (angleZ >= 45 && angleZ < 135)
        {
            nowAnimation = upAnime;
        }

        else
        {
            nowAnimation = leftAnime;
        }

        //애니메이션 전환
        if(nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            anime.Play(nowAnimation);

        }



      /*  float speed = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed = 1f;
        } */
    }

    private void FixedUpdate()
    {
        if(gameState != "playing") { return; }


        //데미지 연출 처리
        if(inDamage)
        {
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0) 
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            return;
        }


        rbody.linearVelocity = new Vector2 (axisH,axisV)*speed;
    }

    public void SetAxis(float h,float v)
    {
        axisH = h;
        axisV = v;
        if(axisH ==0 && axisV ==0 )
        {
            isMoving = false;

        }
        else
        {
            isMoving=true;
        }

    }


    private float GetAngle(Vector2 fromPt, Vector2 toPt)
    {
        float angle;

        if(axisH != 0 || axisV !=0)
        {
            float dx = toPt.x - fromPt.x;    
            float dy = toPt.y - fromPt.y;

            float rad = Mathf.Atan2(dy, dx);
            angle = rad *Mathf.Rad2Deg;

        }
        else
        {
            angle = angleZ;

        }

        return angle;   

          //  throw new NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);

        }
    }

    private void GetDamage(GameObject enemy)
    {
        if(gameState == "playing")
        {
            hp--;
            PlayerPrefs.SetInt("PlayerHP", hp);
        }

        if(hp>0)
        {
            // 히트백 
            rbody.linearVelocity = Vector2.zero;
            Vector2 toPos = (transform.position - enemy.transform.position).normalized;
            rbody.AddForce(toPos * 4, ForceMode2D.Impulse);

            inDamage = true;
            Invoke("DamageEnd", 0.25f);
        }
        else
        {

            GameOver();
        }
    }

    void DamageEnd()
    {
        inDamage = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void GameOver()
    {
        gameState = "gameOver";
        GetComponent<CircleCollider2D>().enabled = false;
        rbody.linearVelocity =Vector2.zero;
        rbody.gravityScale = 1;
        rbody.AddForce(new Vector2(0,5), ForceMode2D.Impulse);

        anime.Play(deadAnime);

        Destroy(gameObject,1f);
    }
}
