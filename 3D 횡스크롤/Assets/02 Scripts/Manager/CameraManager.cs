using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;// 따라갈 주인공 
    public Vector3 offset = new Vector3(0, 7, -10); //주인공과의 거리(위치 값 조절해라)
    public float smoothTime = 0.125f; //따라가는 부드러움 정도 (낮을수록 부드러움)

    private Vector3 velocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null) return;
        Vector3 targetPosition = target.position + offset;

        targetPosition.y = Mathf.Lerp(transform.position.y, target.position.y + offset.y, 0.05f);
        

        //SmoothDamp는 Lerp보다 물리적 진동에 훨씬 강함
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity,smoothTime);

    }
}
