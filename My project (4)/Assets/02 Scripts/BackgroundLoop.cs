using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    float width;

    private void Awake()
    {
        //가로 길이를 측정
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        width = box.size.x;
    }
   

    // Update is called once per frame
    void Update()
    {
        //현제 위치가 원점에서 왼쪽으로 width 이상 이동했을떄 위치를 리셋
        if( transform.position.x <= -width )
        {
            Reposition();
        }
    }

    //위치리셋 함수(메서드)
    void Reposition()
    {
        Vector2 offset = new Vector2( width*2 , 0f );
        transform.position =(Vector2)transform.position + offset;
    }
}
