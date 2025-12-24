using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    public string sceneName;

    float surviveTime;
    bool isGameover;

    private void Start()
    {
        surviveTime = 0f;
        isGameover = false;
    }

    private void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time:" + surviveTime;

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(sceneName);
            }

        }
    }

        //어벤져스 엔드게임

        public void EndGame()
        {
           isGameover=true;
           gameoverText.SetActive(true);

            float bestTime = PlayerPrefs.GetFloat("BestTime");

           if(surviveTime>bestTime)
           {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime," bestTime);


            }

        recordText.text = "BestTIme:"+(int)bestTime;

         }

    }



