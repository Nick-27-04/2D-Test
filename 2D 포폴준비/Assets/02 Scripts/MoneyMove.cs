using UnityEngine;
using UnityEngine.UI;

public class MoneyMove : MonoBehaviour
{
    public Vector2 point;
    Text txt;
    SpriteRenderer sr;

    public float moneySpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     sr=GetComponent<SpriteRenderer>();

        txt = transform.GetComponentInChildren<Text>();
        txt.text = "+" + GameManager.gm.moneyIncreaseAmount.ToString("###,###");
        Destroy(this.gameObject, 3f);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, point, Time.deltaTime * moneySpeed);

        sr.color = new Color(sr.color.r, sr.color.b, sr.color.g, sr.color.a - 0.01f);
       txt.color = new Color(txt.color.r, txt.color.b, txt.color.g, txt.color.a - 0.01f);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(point, 0.2f);
    }
}
