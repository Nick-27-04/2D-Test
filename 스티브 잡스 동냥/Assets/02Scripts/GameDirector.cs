using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
  //GameObject timerText;
   Text timeText;
    
    Text scoreText;
    public float time = 60f;
    public int point = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeText = GameObject.Find("Time txt").GetComponent <Text>();
        scoreText = GameObject.Find("Score txt ").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "TIme:" + time.ToString("F1");
        scoreText.text = "Score:" + point.ToString(); 




    }

    public void GetApple()
    {
        point += 100;
    }

    public void GetBomb()
    {
        point /= 2;

    }

}
