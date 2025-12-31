using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDrag : MonoBehaviour
{
    Vector2 firstTouch;
    public float limitMinY;
    public float limitMaxY;
    public float dragSpeed = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            Move();
        }

    }


    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 currentTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(firstTouch, currentTouch) > 0.4f)
            {
                if (firstTouch.y < currentTouch.y)
                {
                    if (transform.position.y > limitMinY)
                    {
                        transform.Translate(Vector2.down * dragSpeed);
                    }
                }
                else if (firstTouch.y > currentTouch.y)
                {
                    if (transform.position.y < limitMaxY)
                    {
                        transform.Translate(Vector2.up * dragSpeed);
                    }
                }
            }
        }

    }
}