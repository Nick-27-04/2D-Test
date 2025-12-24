using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    GameObject obj;
    Text txtscore;

    int totScore;
    public int score = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj = GameObject.Find("Score txt");
        txtscore = obj.GetComponent<Text>();
        DispScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
        // transform.position = new Vector3(pos.x,transform.position.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;

        if(go.tag == "Apple")
        {
            Destroy(go);
            DispScore(score);

        }
    }

    public void DispScore(int score)
    {
        totScore += score;

        txtscore.text = "Score:"+totScore.ToString();

    }    
}
