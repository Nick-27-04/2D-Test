using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public long totalPoints = 0;
    public TextMeshProUGUI scoreText; // 화면 어딘가에 현재 보유 포인트 표시

    void Awake() => instance = this;

    // 빌런을 잡았을 때 호출
    public void AddScore(int amount)
    {
        totalPoints += amount;
        scoreText.text = "TOTAL: " + totalPoints.ToString("N0");

        // 포인트가 오를 때마다 레벨 매니저의 게이지와 버튼 상태 확인
        LevelManager.instance.RefreshProgress();
    }
}