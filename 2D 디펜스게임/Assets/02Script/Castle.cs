using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    float maxHp;
    float damage;
    public Image guageBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHp = 10;
        damage = 1f;
        guageBar = GameObject.Find("Hp gage").GetComponent<Image>();
        guageBar.fillAmount = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if(guageBar.fillAmount<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        guageBar.fillAmount -= damage / maxHp;

        Destroy(collision.gameObject);
    }
}
