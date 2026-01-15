using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class CS_Joystick : CS_PlayerMove
{
    RectTransform joystickSize;
    public GameObject joystick;
    GameObject prefab;
    float joystickRadious;
    Vector2 inputPosition;
    public GameObject joystickController;
    public GameObject cnavas;
    void Start()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick");
        joystickSize = joystick.GetComponent<RectTransform>();
        joystickRadious = joystickSize.rect.width * 0.5f;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))  // 마우스 클릭
        {
            if (Vector2.Distance(joystickSize.position, inputPosition) <= joystickRadious)// UI범위 안에서
            {
                if (joystickController == null)
                {
                    Instantiate(joystickController, joystick.transform);
                    
                    joystickController.transform.SetParent(cnavas.transform);
                    joystickController.transform.position = Input.mousePosition;
                    joystickController.transform.position = inputPosition;
                }
                else
                {
                    joystickController.transform.Translate(inputPosition);
                }
            }
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            Destroy(joystickController);
        }
        
    }
}
