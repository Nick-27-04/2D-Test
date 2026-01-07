using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HighScoreText;

    int _currenScore = 0;
    int _highScore = 0;

    const string HIGH_SCORE_KEY = "HighScore";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currenScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);

        
    }

    private void UpdateScoreUI()
    {
        if (ScoreText != null)
        {
            ScoreText.text = "점수: "+ _currenScore;
        }
        if (HighScoreText != null) 
        {
            HighScoreText.text = "최고점수:" + _highScore;
        }

    }
   public void AddScore(int points)
    {
        _currenScore += points;

        if (_currenScore> _highScore)
        {
            _highScore = _currenScore;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, _highScore);
            PlayerPrefs.Save();
        }

        UpdateScoreUI();
    }
}
