using UnityEngine;
using UnityEngine.UI;

public class CS_Profile : MonoBehaviour
{   
    public Text PlayerName;
    public Text Type;
    public Text Hp;
    public Text MaxHp;
    public Text Attack;
    public Text Level;
    public Text Mp;
    public Text MaxMp;
    public Text Exp;
    public CS_Data pData;
    public GameObject playerProfile;
    public Text[] profile;

    private void Start()
    {
        playerProfile.SetActive(false);
    }
    private void Update()
    {
        Type.text = pData.Type;
        Hp.text = pData.Hp.ToString();
        MaxHp.text = pData.MaxHp.ToString();
        Attack.text = pData.Attack.ToString();
        Level.text = pData.Level.ToString();
        Mp.text = pData.Mp.ToString();
        MaxMp.text = pData.MaxMp.ToString();
        Exp.text = pData.Exp.ToString();
    }

    public void PlayerProfileON()
    {
        playerProfile.SetActive(true);
        profile[0].text = "속성 : " + Type;
        profile[1].text = "Level : " + Level;
        profile[2].text = "경험치 : " + Exp;
        profile[3].text = "HP : " + Hp + "/" + MaxHp;
        profile[4].text = "MP : " + Mp + "/" + MaxMp;
    }
    public void PlayerProfileOff()
    {
        playerProfile.SetActive(false);
    }
}
