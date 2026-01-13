using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public PlayerData PData;

    GameObject[] Monster;
    Rigidbody2D rig;


    public bool Home = true;
    public bool Back = false;
    public Vector3 OriPos;


    Animator ani;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Monster = GameObject.FindGameObjectsWithTag("Monster");
        rig = GetComponent<Rigidbody2D>();
        OriPos = transform.position;
        ani = GetComponent<Animator>();

    }

    public void NormalAttack()
    {
        if(GameManager.instance.CurrTurn==false&&Home)
        {
            StartCoroutine("NormalAttack");
        }
    }

    IEnumerator NormalAttackCT()
    {
        Monster = GameObject.FindGameObjectsWithTag("Monster");
        Back = false;
        int r =Random.Range(0, Monster.Length); //몬스터를 랜덤하게 타겟팅!

        while (true)
        {
            if (Monster[r] != null)
            {
                Home = false;
                rig.MovePosition(Vector3.Lerp(transform.position, Monster[r].transform.position, moveSpeed * Time.deltaTime));
            }

            if (Vector3.Distance(transform.position, Monster[r].transform.position) <= 0.5f)
            {
                ani.SetTrigger("Attack");

                yield return new WaitForSeconds(0.3f);
                Back = true;
                break;

            }

        }
        yield return null;

    }

    public void Damage(int Attack)
    {
        PData.Hp -= Attack;
        ani.SetTrigger("Damage");

        if(PData.Hp < 0)
        {
            GameManager.instance.D_Player.Remove(PData.Job);
            Destroy(gameObject);
        }

    }


    // Update is called once per frame
    void Update()
    {
        if(Back==true)
        {
            rig.MovePosition(Vector3.Lerp(transform.position, OriPos, moveSpeed * Time.deltaTime));

            if(Vector3.Distance(transform.position,OriPos)<= 0.5f)
            {
                transform.position = OriPos;
                Home = true;

            }

        }


    }
}
