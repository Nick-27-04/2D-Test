using UnityEngine;

public class OnCollision_CountAndHide : MonoBehaviour
{

    public string targetObjectname;
    public int addValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == targetObjectname) 
        {
            GameCotnter.value += addValue;

            this.gameObject.SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
