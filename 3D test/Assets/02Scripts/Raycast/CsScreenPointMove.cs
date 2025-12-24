using UnityEngine;

public class CsScreenPointMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
          RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) 
            {
               Vector3 newPos = new Vector3(hit.point.x,transform.position.y, hit.point.z);
                transform.position = newPos;


            }
            
        }
    }
}
