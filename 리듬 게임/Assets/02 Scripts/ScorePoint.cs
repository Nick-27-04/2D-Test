using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class ScorePoint : MonoBehaviour
{
    public static int missPoint;
    public static int badPoint;
    public static int goodPoint;
    public static int perfectPoint;

    public static int score = 0;

    [SerializeField]
    Text scoreText;

    private void Update()
    {
        scoreText.text = score.ToString();
    }
}


