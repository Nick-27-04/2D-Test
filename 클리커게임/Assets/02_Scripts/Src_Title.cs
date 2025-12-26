using UnityEngine;
using UnityEngine.SceneManagement;

public class Src_Title : MonoBehaviour
{
  public void Press_Play()
    {
        SceneManager.LoadScene("Scene_Game");

    }

    public void Press_Quit()
    {
       Application.Quit();
        Debug.Log("Quit");

        
;    }


}
