using UnityEngine;
using UnityEngine.UI;

public class CsSlider : MonoBehaviour
{
    Text txt;
    Slider slider1;
    Slider slider2;
    int fontSize;

    Text lbl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txt = GameObject.Find("Title text").GetComponent<Text>();
        fontSize = txt.fontSize;

        lbl = GameObject.Find("LBL").GetComponent<Text>();

        slider1 = GameObject.Find("Slider 1"). GetComponent<Slider>();
        slider2 = GameObject.Find("Slider 2") .GetComponent<Slider>();
      
       // slider2.onValueChanged.AddListener(ChangeSliderValue)
    }

    public void ChangeSliderValue(float value)
    {
        float val = slider2.value;
        slider1.value = val;
        txt.fontSize = fontSize + (int)val*100;

        lbl.text = (int)val+"%";
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
