using System.Security.Principal;
using UnityEngine;

public class OnMouseprefab : MonoBehaviour
{
    public GameObject newPrefab; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward);


           // Instantiate(newPrefab,Quaternion.Identity);
           GameObject newGameObject = Instantiate(newPrefab);
            newGameObject.transform.position = pos;
            

        }
    }
}
