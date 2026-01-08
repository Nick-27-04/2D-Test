
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700f;

    int jumpCount = 0;
    bool isGround = false;
    bool isDead = false;

    Rigidbody2D playerRigidbody;
    Animator animator;

    AudioSource audioSource;
    public AudioClip deathClip;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        audioSource = GetComponent<AudioSource>();

        //초기화
    }

    private void Update()
    {
        Debug.Log(isDead);
        Debug.Log(isGround);
        Debug.Log(jumpCount);

        if (isDead) return;

        if (Input.GetMouseButtonDown(0) && jumpCount <2)
        {
            Debug.Log("jump");
            jumpCount++;
            playerRigidbody.linearVelocity = Vector3.zero;
            playerRigidbody.AddForce(new Vector2(0f, jumpForce));
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.linearVelocity.y>0)
        {
            Debug.Log("jump2");
            playerRigidbody.linearVelocity = playerRigidbody.linearVelocity * 0.5f;
        }

        animator.SetBool("Grounded", isGround);

    }

    void Die()
    {

        animator.SetTrigger("DIe");
        audioSource.clip = deathClip;
        audioSource.Play();

        playerRigidbody.linearVelocity =Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead();
        //사망 처리
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //장애물과 충돌 감지
        if(coll.tag =="Dead"&& !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {


        if (coll.contacts[0].normal.y>0.7)
        {
            isGround = true;
            jumpCount = 0;
        }
        //바닥에 닿았음을 감지.
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //바닥에서 벗어났음을 감지.
        isGround=false;
    }
    //
}
