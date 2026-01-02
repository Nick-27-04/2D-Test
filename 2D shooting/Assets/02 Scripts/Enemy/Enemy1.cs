using UnityEngine;

public class Enemy1 : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Move();
    }

    // Update is called once per frame
  public override  void Move()
   {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
   }

}
