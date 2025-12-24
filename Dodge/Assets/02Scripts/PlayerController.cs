using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    public GameObject gameobj;

    GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        gameManager = gameobj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xspeed = speed * xInput;
        float zspeed = speed * zInput;

        Vector3 newVelocity = new Vector3 (xspeed,0f,zspeed);

        playerRigidbody.linearVelocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive (false);
        gameManager.EndGame();

        //wham!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }




}




