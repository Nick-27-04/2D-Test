using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    Text musicNameText;
    [SerializeField]
    AudioClip[] backMusicClips;
    AudioSource backAudio;

    [SerializeField]
    Slider playerHpSlider;
    public float playerHP = 100f;
    public bool isGame = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backAudio = GetComponent<AudioSource>();
        backAudio.clip = backMusicClips[StartManager.MusicNum];
        backAudio.Play();
        musicNameText.text = StartManager.MusicName;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGame)
        {
            playerHpSlider.value = playerHP;

            if (playerHP <= 0)
            {
                isGame = false;
                SceneManager.LoadScene("End");

            }
        }
    }


}
