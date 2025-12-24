using UnityEngine;

public class CsLookat : MonoBehaviour
{

    Transform obj;

    public string goName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj = GameObject.Find(goName).transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(obj);
    }
}
