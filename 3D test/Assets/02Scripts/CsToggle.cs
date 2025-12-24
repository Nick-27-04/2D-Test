using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CsToggle : MonoBehaviour
{

    GameObject obj;

    Text txt;
    Toggle tgChangeText;
    public string objName;
    //TextMeshProUGUI


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj = GameObject.Find("objName");
        txt = obj.GetComponent<Text>();
        tgChangeText = GameObject.Find("Toggle1").GetComponent<Toggle>();

    }

    public void ChangeText(bool _bool) 
    {
        if (tgChangeText.isOn)
        {
            txt.text = "True";
        }

        else 
        {
             txt.text = "False";
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
