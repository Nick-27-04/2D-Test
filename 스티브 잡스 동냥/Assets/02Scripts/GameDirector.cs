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

    itemGenerator itemGenerator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeText = GameObject.Find("Time txt").GetComponent <Text>();
        scoreText = GameObject.Find("Score txt ").GetComponent<Text>();
        itemGenerator = GetComponent<itemGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;
        if (time < 0) 
        {
           time = 0;
            itemGenerator.SetParameter(100000f, 0, 0);
        
        } 
        else if (0 <= this.time && this.time <= 5f)
        {
            itemGenerator.SetParameter(0.7f, -4f, 3);
        }
        else if(5<= this.time && this.time <= 10)
        {
            itemGenerator.SetParameter(0.8f, -3f, 4);

        }
        else if (10 <= this.time&& this.time <=20)
        {
            itemGenerator.SetParameter(1f, -3f, 2);

        }


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
