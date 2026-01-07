using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform Target;
    public float ScrollSpeed = 0.1f;

    Material _matBack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _matBack =GetComponent<Renderer>().material;
    }

    // Update is called once per frame
   private void Update()
    {
        if(Target == null) {return;}

        transform.position = Target.position;

        float offsetX = (Target.position.x *ScrollSpeed)%1.0f;
        float offsetY = (Target.position.y * ScrollSpeed) % 1.0f;

        _matBack.mainTextureOffset = new Vector2(offsetX, offsetY);
    }


}
