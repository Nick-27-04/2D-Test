using UnityEngine;

public class SometimeFilp : MonoBehaviour

{
    public float speed = 1.0f;
    bool flipped = false;

    public int maxCount = 100;
    int count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // this.GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        count++;
        if (count > maxCount)
        {
            speed = -speed;
            flipped = !flipped;
            count = 0;  
        }

        this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        this.GetComponent<SpriteRenderer>().flipX = flipped;
    }
}
