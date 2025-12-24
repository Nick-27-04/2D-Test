using UnityEngine;
using UnityEngine.InputSystem;

public class OnkeyPress : MonoBehaviour
{
    public float Speed = 1f;
    float vx;
    float vy;

    void Update()
    {
        vx = 0f;
        vy = 0f;

        if (Keyboard.current.rightArrowKey.isPressed)
            vx = Speed;

        if (Keyboard.current.leftArrowKey.isPressed)
            vx = -Speed;

        if (Keyboard.current.upArrowKey.isPressed)
            vy = Speed;

        if (Keyboard.current.downArrowKey.isPressed)
            vy = -Speed;

        transform.Translate(new Vector3(vx, vy, 0f) * Time.deltaTime);

        GetComponent<SpriteRenderer>().flipX = vx < 0;
    }
}