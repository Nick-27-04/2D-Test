using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] TMP_Text t;
    [SerializeField] float lifeTime = 0.6f;
    [SerializeField] float upSpeed = 1.2f;

    void Awake()
    {
        if (!t) t = GetComponent<TMP_Text>();
        if (!t) t = GetComponentInChildren<TMP_Text>();
    }

    public void Set(int dmg)   // ✅ 이 함수가 있어야 boss에서 Set(dmg) 호출 가능
    {
        if (t) t.text = dmg.ToString();
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += Vector3.up * upSpeed * Time.deltaTime;
    }
}
