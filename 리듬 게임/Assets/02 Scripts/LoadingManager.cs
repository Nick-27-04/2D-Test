using System.Collections;
using UnityEngine;
using UnityEngine.UI;


using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    Slider loadingBar;
    [SerializeField]
    float loadingSpeed;
    [SerializeField]
    Text musicNameText;

    private void Start()
    {
        musicNameText.text = StartManager.MusicName;
        LoadingStart("Main");
    }

    public void LoadingStart(string v)
    {
        StartCoroutine(Loading(name));
    }

    IEnumerator Loading(string name)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(name);
        loadingOperation.allowSceneActivation = false;
        //로딩이 완료되는 대로 씬을 활성화 하는 여부

        while (loadingOperation.isDone)
        {
            loadingBar.value += loadingSpeed * Time.deltaTime;
         
            if(loadingBar.value>=1f)
            {
                loadingOperation.allowSceneActivation=true;
            }

            yield return null;

        }
    }
}
