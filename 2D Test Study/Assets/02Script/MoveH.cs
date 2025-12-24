using UnityEngine;

public class MoveH : MonoBehaviour
{
    public float s = 5f;   // 이동 속도

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // A/D, ←/→
        float z = Input.GetAxis("Vertical");   // W/S, ↑/↓

        Vector3 d = new Vector3(x, 0f, z);
        transform.Translate(d * s * Time.deltaTime, Space.World);
    }
}
