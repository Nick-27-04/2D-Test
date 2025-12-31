using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillVisualEffect : MonoBehaviour
{
    public static SkillVisualEffect instance;
    public RectTransform skillCutInRect;
    public RectTransform canvasRect;

    [Header("속도 설정 (낮을수록 빠름)")]
    public float slideInSpeed = 0.1f;
    public float slideOutSpeed = 0.1f;

    void Awake()
    {
        instance = this;
        if (canvasRect == null)
            canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    void Start()
    {
        if (skillCutInRect != null)
            skillCutInRect.gameObject.SetActive(false);
    }

    public void ShowSkillCutIn(Sprite characterSprite, float holdTime)
    {
        StopAllCoroutines();
        StartCoroutine(DynamicSlideRoutine(characterSprite, holdTime));
    }

    IEnumerator DynamicSlideRoutine(Sprite characterSprite, float holdTime)
    {
        if (skillCutInRect == null || canvasRect == null) yield break;

        // ---------------------------------------------------------
        // 0. 시간 멈춤 (타임스케일을 0으로 설정)
        // ---------------------------------------------------------
        Time.timeScale = 0f;

        // 이미지 설정 및 활성화
        Image img = skillCutInRect.GetComponent<Image>();
        img.sprite = characterSprite;
        skillCutInRect.gameObject.SetActive(true);

        float screenWidth = canvasRect.rect.width;
        Vector2 startPos = new Vector2(-screenWidth, 0);
        Vector2 centerPos = Vector2.zero;
        Vector2 endPos = new Vector2(screenWidth, 0);

        // 1. 왼쪽 -> 중앙 (진입)
        float elapsed = 0f;
        while (elapsed < slideInSpeed)
        {
            // 시간은 멈춰있으므로 DeltaTime 대신 unscaledDeltaTime을 써야 애니메이션이 돌아갑니다.
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / slideInSpeed;
            t = t * (2 - t);
            skillCutInRect.anchoredPosition = Vector2.Lerp(startPos, centerPos, t);
            yield return null;
        }

        // 2. 중앙 대기 (시간이 멈춰있으므로 WaitForSecondsRealtime 사용)
        yield return new WaitForSecondsRealtime(holdTime);

        // 3. 중앙 -> 오른쪽 (퇴장)
        elapsed = 0f;
        while (elapsed < slideOutSpeed)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / slideOutSpeed;
            t = t * t;
            skillCutInRect.anchoredPosition = Vector2.Lerp(centerPos, endPos, t);
            yield return null;
        }

        skillCutInRect.gameObject.SetActive(false);

        // ---------------------------------------------------------
        // 4. 시간 다시 재생 (연출이 끝났으므로 원래 속도로 복구)
        // ---------------------------------------------------------
        Time.timeScale = 1f;
    }
}