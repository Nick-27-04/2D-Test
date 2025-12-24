using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    Rigidbody bulletRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 3f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //¥Ÿ»Ò
           PlayerController playerController = other.GetComponent<PlayerController>();

            playerController .Die();

        }


    }


   
}
