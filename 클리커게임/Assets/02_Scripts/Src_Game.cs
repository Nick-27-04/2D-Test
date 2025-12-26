using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Src_Game : MonoBehaviour
{
    public TextMeshProUGUI stageVal, creditVal;
    public Image[] stg = new Image[4];

    int stage, credit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        credit = 100;
        stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        stageVal.text = stage.ToString();
        creditVal.text = credit.ToString();
    }
}
