using UnityEngine;

public class CsMatSetActive : MonoBehaviour
{
    public GameObject boots;
    public GameObject pants;
    public GameObject shirts;
    public GameObject helmet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetActiveOff();
    }

    public void SetActiveOff()
    {
        boots.SetActive(false);
        pants.SetActive(false);
        shirts.SetActive(false);    
        helmet.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
