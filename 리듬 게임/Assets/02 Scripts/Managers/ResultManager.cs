using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    Text perfectTxt;
    [SerializeField]
    Text goodTxt;
    [SerializeField]
    Text badTxt;
    [SerializeField]
    Text missTxt;
    [SerializeField]
    Text rankTxt;
    string rank;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        perfectTxt.text =ScorePoint.perfectPoint.ToString();
        goodTxt.text =ScorePoint.goodPoint.ToString();
        badTxt.text =ScorePoint.badPoint.ToString();
        missTxt.text =ScorePoint.missPoint.ToString();

        //·©Å©
        if (ScorePoint.score>200)
        {
            rank = "A";
        }
        else if (ScorePoint.score < 200 && ScorePoint.score >150)
        {
             rank="B";
        }
        else if (ScorePoint.score < 150 && ScorePoint.score > 100)
        {
            rank = "C";
        }
        else if (ScorePoint.score < 100 && ScorePoint.score > 50)
        {
            rank = "D";
        }
        else
        {
            rank = "F";
        }

        rankTxt.text = rank;
    }

    // Update is called once per frame
    public void Home()
    {
        ScorePoint.perfectPoint = 0;
        ScorePoint.goodPoint = 0;
        ScorePoint.badPoint = 0;
        ScorePoint.missPoint = 0;
        ScorePoint.score = 0;

        SceneManager.LoadScene("Start");

    }
}
