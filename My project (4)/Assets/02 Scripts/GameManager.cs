using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public Text scoreText;
    public GameObject gameOverUI;

    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("이미 게임매니저 존재!");
            Destroy(gameObject);
        }
    }

        private void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score : " + score;
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameOverUI.SetActive(true);
    }
}

