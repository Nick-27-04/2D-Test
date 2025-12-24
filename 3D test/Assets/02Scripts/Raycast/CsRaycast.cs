using UnityEngine;

public class CsRaycast : MonoBehaviour
{
    public float speed = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float amtMove = speed*Time.deltaTime;
        float h = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * h * amtMove);

        Debug.DrawRay(transform.position, transform.forward*8,Color.red);
        /*
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.forward, out hit, 8)) 
        {
          Debug.Log(hit.collider.gameObject.name);


        }
        */

        RaycastHit[] hits;

        hits = Physics.RaycastAll(transform.position, transform.forward, 8);

        for (int i = 0; i < hits.Length; i++) 
        {
         RaycastHit hit = hits[i];

            Debug.Log(hit.collider.gameObject.name);

        
        }

    }
}
