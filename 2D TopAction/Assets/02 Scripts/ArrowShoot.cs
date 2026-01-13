using System;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float shootSpeed = 12.0f;
    public float shootDelay = 0.25f;
    public GameObject bowPrefab;
    public GameObject arrowPrefab;

    bool inAttack = false;
    GameObject bowObj;

    PlayerController plmv;
   // Rigidbody2D rbody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 pos = transform.position;
        bowObj = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObj.transform.SetParent(transform);
        plmv = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire3"))
        {
            Attack();
        }
        float bowZ = -1f;
        if (plmv.angleZ > 30 && plmv.angleZ<150) 
        {
            bowZ = 1f;
        }

        bowObj.transform.rotation =Quaternion.Euler( 0f, 0f,plmv.angleZ);
        bowObj.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);
    }

    private void Attack()
    {
        if(ItemKeeper.hasArrows>0 && inAttack ==false)
        {
            ItemKeeper.hasArrows -= 1;
            inAttack = true;
            float angleZ = plmv.angleZ;
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position, r);

            float x = Mathf.Cos(angleZ*Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ*Mathf.Deg2Rad);

            Vector3 v = new Vector2(x, y)*shootSpeed;
            arrowObj.GetComponent<Rigidbody2D>().AddForce(v,ForceMode2D.Impulse);
            // rbody.AddForce(v,ForceMode2D.Impulse);

            Invoke("StopAttack", shootDelay);
        }
    }

    public void StopAttack()
    {
        inAttack = false;

    }
}
