using UnityEngine;

public class Apple : MonoBehaviour
{
    public float bottomY = -10f;
    public GameObject aPicker;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aPicker = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<bottomY)
        {
            Destroy(gameObject);

          
            aPicker.GetComponent<ApplePicker>().AppleDestroyed();
        }
    }
}
