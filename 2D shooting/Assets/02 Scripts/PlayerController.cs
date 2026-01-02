using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player º¯¼ö
    public float moveSpeed = 11;
    public GameObject bulletPrefab;

    public float bulletspeed;
    public int bulletCount;
    public float spacing = 0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                Vector3 bulletPos = transform.position;
                bulletPos.y += spacing*i;
                bullet.transform.position = bulletPos;

                bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * bulletspeed);
            }

        }

    }
}
