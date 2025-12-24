using UnityEngine;

public class ChaseCameraH : MonoBehaviour
{
    public Transform taget; //플레이어.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = 
            new Vector3(taget.position.x ,transform.position.y,transform.position.z);  
    }
}
