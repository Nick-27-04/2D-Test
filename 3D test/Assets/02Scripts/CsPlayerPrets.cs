using UnityEngine;
using UnityEngine.UI;

public class CsPlayerPrets : MonoBehaviour
{
    public InputField inputID;
    public InputField inputPass;

    public void Save()
    {
        PlayerPrefs.SetString("ID", inputID.text);
        PlayerPrefs.SetInt("pass",int.Parse (inputPass.text));
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey("ID"))
        {
            inputID.text = PlayerPrefs.GetString("ID");
            inputPass.text = PlayerPrefs.GetInt("Pass").ToString();
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
