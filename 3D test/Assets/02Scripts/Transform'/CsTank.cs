using UnityEngine;

public class CsTank : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    public GameObject turret;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //이동 중일때는 본체가 회전 (이동과 회전)
        //그렇지 않을때(멈췄을 때 )는 터렛만 회전
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        h = h * rotateSpeed * Time.deltaTime;
        v = v * moveSpeed * Time.deltaTime;

        if (v==0 ) //이동 중이라면... //이동 중이 아니라면...
        {

            //터렛(회전)
            turret.transform.Rotate(Vector3.up * h);
        }
        else //이동중이 아니라면... //이동중이라면...
        {
            //(이동 회전(body)
            this.transform.Translate(Vector3.forward * v);
            this.transform.Rotate(Vector3.up * h);
        }
    }
}
