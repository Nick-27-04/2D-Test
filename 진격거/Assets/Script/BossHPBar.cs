using UnityEngine;
using UnityEngine.UI;

public class BossHPBarUI : MonoBehaviour
{
    [SerializeField] BossController boss;
    [SerializeField] Transform anchor;
    [SerializeField] Slider slider;
    [SerializeField] float smooth = 10f;

    float v;
    RectTransform rt;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        Refresh();
    }

    void OnEnable()
    {
        Refresh();
    }

    void Refresh()
    {
        if (boss == null || slider == null) return;

        slider.minValue = 0f;
        slider.maxValue = boss.MaxHP;
        v = boss.HP;              // ✅ 현재 HP로 시작(=풀피)
        slider.value = v;
    }

    void Update()
    {
        if (boss == null || anchor == null || slider == null) return;

        // ✅ Screen Space(Overlay)에서도 맞게 따라가게
        Vector3 s = Camera.main.WorldToScreenPoint(anchor.position);
        rt.position = s;

        float target = boss.HP;
        v = Mathf.Lerp(v, target, Time.deltaTime * smooth);
        slider.value = v;
    }

    public void Bind(BossController b, Transform a)
    {
        boss = b;
        anchor = a;
        Refresh();
    }
}
