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

    public Slider Turn;
    public Text Turntxt;
    public float TurnTIme = 10f;

    CoolTime ct;

    public bool PlayerTurn = true;
    public bool MonsterTurn = false;
    // 다른 클래스에서 판별할 현재 턴 (false : 플레이어턴,true :몬스터턴)
    public bool CurrTurn = false;

    //몬스터 처리
    public List<GameObject> L_Monster = new List<GameObject>();
    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        ct =new CoolTime();
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

        L_Monster.Add(Monster1);
        L_Monster.Add(Monster2);
        L_Monster.Add(Monster3);

    }

    // Update is called once per frame
    void Update()
    {
        Turn.value = ct.Timer(TurnTIme);
        if(Turn.value == 0)
        {
            PlayerTurn = !PlayerTurn; //true -> false => CurrTurn (True)
            CurrTurn = !PlayerTurn;

            if(PlayerTurn)
            {
                Turntxt.text = "Player Turn";
                MonsterTurn = false;
            }
            else
            {
                MonsterTurn=true;
                Turntxt.text = "Monster Turn";
            }

        }
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
            Player P2 = D_Player["신관"].GetComponent<Player>();
            if (P2 != null)
            {
                priestText[0].text = P2.PData.Job;
                priestText[1].text = "레벨:" + P2.PData.Level.ToString();
                priestText[2].text = "경험치" + P2.PData.Exp;
                priestText[3].text = "HP" + P2.PData.Hp + "/" + P2.PData.MaxHp;
                priestText[4].text = "MP" + P2.PData.Mp + "/" + P2.PData.MaxMp;
            }


        }
        if (D_Player.ContainsKey("마법사"))
        {
            Player P3 = D_Player["마법사"].GetComponent<Player>();
            if (P3 != null)
            {
                witchText[0].text = P3.PData.Job;
                witchText[1].text = "레벨:" + P3.PData.Level.ToString();
                witchText[2].text = "경험치" + P3.PData.Exp;
                witchText[3].text = "HP" + P3.PData.Hp + "/" + P3.PData.MaxHp;
                witchText[4].text = "MP" + P3.PData.Mp + "/" + P3.PData.MaxMp;
            }

        }
    }
}
