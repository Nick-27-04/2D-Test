using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameover==false)
        {
            // 왼쪽으로 평행 이동
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
       
    }
}
