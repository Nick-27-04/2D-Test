using UnityEngine;
using TMPro;
using System.Collections;

public class BlinkingText : MonoBehaviour
{
    private TextMeshProUGUI targetText;

    [Header("설정")]
    public float blinkInterval = 0.5f; // 깜빡이는 속도 (초)

    void Awake()
    {
        targetText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        // 오브젝트가 켜질 때 깜빡임 시작
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // 1. 텍스트 투명도를 0으로 (안 보이게)
            targetText.alpha = 0f;
            yield return new WaitForSecondsRealtime(blinkInterval);

            // 2. 텍스트 투명도를 1로 (보이게)
            targetText.alpha = 1f;
            yield return new WaitForSecondsRealtime(blinkInterval);
        }
    }
}