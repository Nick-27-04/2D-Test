using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    public float ScaleSpeed = 5.0f;
    public float ScaleAmount = 0.05f;

    Vector3 _originScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _originScale =transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float scaleProgress = Mathf.PingPong(Time.time * ScaleSpeed, 1f);

        float scaleChange = (scaleProgress * 2 - 1) * ScaleAmount;

        Vector3 newScale = _originScale * (1 + scaleChange);

        transform.localScale = newScale;
    }
}
