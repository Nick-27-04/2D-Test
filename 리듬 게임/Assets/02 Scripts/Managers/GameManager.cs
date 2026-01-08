using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    AudioSource bgmAudio;
    [SerializeField]
    AudioSource keySoundAudio;

    [SerializeField]
    Slider backSilder;
    [SerializeField]
    Slider keySilder;

    [SerializeField]
    GameObject GameAudioUI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgmAudio.volume = backSilder.value;
        keySoundAudio.volume = keySilder.value;

        //비활성화 되어있다면 활성화(열기)
        if (GameAudioUI.activeSelf == false) 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                GameAudioUI.SetActive(true);
            }
            
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
                GameAudioUI.SetActive(false);

            }
           
        }

        //활성화 되어있다면 비활성화(닫기)
    }
}
