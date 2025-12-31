using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위한 네임스페이스

public class SceneController : MonoBehaviour
{
    // 버튼을 눌렀을 때 호출할 함수
    public void ChangeScene(string sceneName)
    {
        // 입력받은 이름의 씬으로 이동합니다.
        SceneManager.LoadScene(sceneName);
    }
}