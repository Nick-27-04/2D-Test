using UnityEngine;
using UnityEngine.UI;

public class MissPoint : MonoBehaviour
{
    AudioSource missAudio;
    public AudioClip missAudioClip;

    [SerializeField]
    MainManager mainManager;


    [SerializeField]
    Text infoText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        missAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Point")
        {
            if(mainManager.isGame)
            {
                ScorePoint.missPoint++;
                mainManager.playerHP -= 5f;
                Destroy(collision.gameObject);
                missAudio.PlayOneShot(missAudioClip);

                infoText.text = "Miss!";
                Invoke("TextInit" , 1.5f);
            }
        }
    }

    // Update is called once per frame
   void TextInit()
    {
        infoText.text = "";
    }
}
