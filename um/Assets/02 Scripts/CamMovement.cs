using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float PosX;
    [SerializeField] float PosY;
    [SerializeField] float PosZ;

    [SerializeField] float m_Speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position,
                                               new Vector3(player.position.x + PosX,
                                                             player.position.x + PosY,
                                                             player.position.y + PosZ),
                                                       Time.deltaTime * m_Speed);

    }
}
