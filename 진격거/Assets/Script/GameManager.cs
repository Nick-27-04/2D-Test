using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [Header("UI")]
    [SerializeField] GameObject winText;
    [SerializeField] GameObject gameOverText;

    bool isGameOver;

    void Awake()
    {
        I = this;
        Time.timeScale = 1f;
        if (winText) winText.SetActive(false);
        if (gameOverText) gameOverText.SetActive(false);
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Win()
    {
        if (isGameOver) return;
        isGameOver = true;
        if (winText) winText.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        if (gameOverText) gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }
}
