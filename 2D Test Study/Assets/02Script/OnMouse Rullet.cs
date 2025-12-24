using UnityEngine;

public class OnMouseRullet : MonoBehaviour
{
    public float maxspeed = 50f;

    float rotateAngle = 0;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {
        rotateAngle = maxspeed; 
    }

    // Update is called once per frame
    private void Update()
    {
        // rotateAngle--;
        // if (rotateAngle < 0) rotateAngle = 0;   
         
        rotateAngle = rotateAngle * (0.98f);

        this.transform.Rotate(0,0,rotateAngle);
    }
}
