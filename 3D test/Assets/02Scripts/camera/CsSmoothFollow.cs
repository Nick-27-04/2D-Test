using UnityEngine;
using UnityEngine.UIElements;

public class CsSmoothFollow : MonoBehaviour
{
    public Transform target;

    public float distance = 15f;
    public float height = 5f;

    public float heightDamping = 3f;
    public float rotateDamping = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            // 가려는 위치,각도
            float wantedRotationAngle = target.eulerAngles.y;
            float wantedHeight =target.position.y + height;

            //현제 위치,각도
            float currentHeight = this.transform.position.y;
            float currentRotationAngle = this.transform.eulerAngles.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotateDamping * Time.deltaTime);


            currentHeight = Mathf.Lerp(currentHeight, wantedHeight,heightDamping * Time.deltaTime);

            Quaternion curentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            Vector3 pos = target.position;
            pos -= curentRotation * Vector3.forward * distance;
            pos.y = currentHeight;

            transform.position = pos;

            transform.LookAt(target);

        }
    }
}
