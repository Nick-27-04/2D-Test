using UnityEngine;
using UnityEngine.UI;

public class CsInput : MonoBehaviour
{
    Text txt;

    InputField input;
    Button btn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txt =GameObject.Find("TXT").GetComponent<Text>();
        input = GameObject.Find("Input").GetComponent<InputField>(); ;
        btn = GameObject.Find("Btn").GetComponent <Button>();
    }

    public void ChangeValue()
    {
        txt.text = input.text;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
