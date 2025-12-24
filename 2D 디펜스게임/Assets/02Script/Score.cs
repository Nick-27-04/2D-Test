using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
        float time;
    int int_time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int_time = (int)time;
        scoreText.text = "Score:"+int_time.ToString();
    }
}
