using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager  instance;

    public Dictionary<string,GameObject>D_Player =new Dictionary<string,GameObject>();

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    public GameObject[] Status;
    Text[] swordmanText,priestText,witchText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        D_Player.Add("검사", Player1);
        D_Player.Add("신관", Player2);
        D_Player.Add("마법사", Player3);

        Status = GameObject.FindGameObjectsWithTag("Status");

        swordmanText = Status[0].GetComponentsInChildren<Text>();
        priestText = Status[1].GetComponentsInChildren<Text>();
        witchText = Status[2].GetComponentsInChildren<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        StatussShow();
    }

    private void StatussShow()
    {
        if(D_Player.ContainsKey("검사"))
        {
            Player P = D_Player["검사"].GetComponent<Player>();
            if(P!=null)
            {
                swordmanText[0].text = P.PData.Job;
                swordmanText[1].text = "레벨:"+ P.PData.Level.ToString();
                swordmanText[2].text = "경험치"+ P.PData.Exp;
                swordmanText[3].text = "HP"+P.PData.Hp+"/"+P.PData.MaxHp;
                swordmanText[4].text = "MP"+P.PData.Mp + "/" + P.PData.MaxMp;
            }


        }
        if (D_Player.ContainsKey("신관"))
        {
            Player P = D_Player["신관"].GetComponent<Player>();


        }
        if (D_Player.ContainsKey("마법사"))
        {
            Player P = D_Player["마법사"].GetComponent<Player>();


        }
    }
}
