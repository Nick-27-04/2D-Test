using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;

public class CsDropDown : MonoBehaviour
{

    public Text txt;

    public Dropdown dropdown;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(delegate { Funcdrop(dropdown); });
    }

    public void Funcdrop(Dropdown dropdown)
    {
        string op = dropdown.options[dropdown.value].text;

        txt.text = op;
    }

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   
}
