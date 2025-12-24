using UnityEngine;

public class BasketController : MonoBehaviour
{
    GameObject gameDirector;
    GameDirector gd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gd =GameObject.Find("ItemGenerator").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) 
            {
               float x = Mathf.RoundToInt( hit.point.x);
               float y = Mathf.RoundToInt(hit.point.z);

                transform.position =new Vector3(x,0f,y);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Apple")
        {
            Debug.Log("Apple");
            gd.GetApple();

        }
        else if(other.gameObject.tag=="Bomb")
        {
            Debug.Log("Bomb");
            gd.GetBomb();
        }


            Destroy(other.gameObject);
    }
}
