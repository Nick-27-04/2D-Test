using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
  
  
    // 진격거 많관부

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if(hit.collider!=null)
            {
                if(hit.collider.tag == "Enemy")
                {
                    Destroy(hit.collider.gameObject);

                }
               

            }
        }
    }
}
