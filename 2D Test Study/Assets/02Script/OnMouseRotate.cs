using UnityEngine;

public class OnMouseRotate : MonoBehaviour
{
    public float angle = 360;
    float rotateAngle = 0;


    private void OnMouseDown()
    {
        rotateAngle = angle;
    }
    private void OnMouseUp()
    {
        rotateAngle = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0,0,rotateAngle*Time.deltaTime);
    }
}
