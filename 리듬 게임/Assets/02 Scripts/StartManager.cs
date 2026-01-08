using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public AudioSource playerAudio;
    [SerializeField]
    AudioClip[] selectAudioclips;

    [SerializeField]
    int SelectNum;
    [SerializeField]
    Slider voluumeSlider;
    [SerializeField]
    GameObject[] MusicSelects;

    public static string MusicName;
    public static int MusicNum;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.PlayOneShot(selectAudioclips[SelectNum]);
    }

    public void MusicBtn(string BtnName)
    {
        if(BtnName =="Next")
        {
            //다음
            if (SelectNum < MusicSelects.Length - 1)
            {
                playerAudio.Stop();
                MusicSelects[SelectNum].SetActive(false);
                SelectNum++;
                MusicSelects[SelectNum].SetActive(true);
                playerAudio.PlayOneShot(selectAudioclips[SelectNum]);

            }

        }
        else
        {
            //이전
            if (SelectNum > 0)
            {
                playerAudio.Stop();
                MusicSelects[SelectNum].SetActive(false);
                SelectNum--;
                MusicSelects[SelectNum].SetActive(true);
                playerAudio.PlayOneShot(selectAudioclips[SelectNum]);

            }

        }

    }

    //1. 뮤직선택
    //2. 로딩씬으로 전환
    //3. 선택한 음악의 정보를 전달
    //4. 스태틱 (번호,이름) -> 로딩( 곡 정보를 노출)
    public void LoadingBtn()
    {
        MusicNum = SelectNum;
        MusicName = MusicSelects[SelectNum].transform.GetChild(1).GetComponent<Text>().text;
        SceneManager.LoadScene("Loading");
    }

}
