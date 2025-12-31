using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Skill_Jotaro : MonoBehaviour
{
    [Header("스킬 수치 설정")]
    public float stopDuration = 8f;     // 정지 지속 시간
    public float cooldownTime = 25f;    // 쿨타임
    public float timeSlowAmount = 0.01f;

    [Header("UI 및 연출 연결")]
    public Sprite jotaroCutInSprite;    // ⭐ 죠타로 컷인 이미지 등록
    public float cutInDisplayTime = 0.5f;
    public TextMeshProUGUI cooldownText;
    public Image grayscaleOverlay;      // 흑백 패널
    public Image flashOverlay;          // 스킬 발동 시 번쩍이는 패널

    [HideInInspector] public bool isTimeStopped = false;
    private bool isCooldown = false;
    private float currentCooldown = 0f;

    void Start()
    {
        if (grayscaleOverlay != null) grayscaleOverlay.gameObject.SetActive(false);
        if (flashOverlay != null) flashOverlay.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTimeStopped && !isCooldown)
        {
            StartCoroutine(TheWorld());
        }
        UpdateUI();
    }

    IEnumerator TheWorld()
    {
        isCooldown = true;

        // 1. ⭐ 죠타로 컷인 연출 (시간이 멈추기 직전에 호출)
        if (SkillVisualEffect.instance != null && jotaroCutInSprite != null)
        {
            SkillVisualEffect.instance.ShowSkillCutIn(jotaroCutInSprite, cutInDisplayTime);
            // 컷인이 진행되는 동안 대기 (ShowSkillCutIn 내부에서 이미 timescale을 0으로 만듦)
            yield return new WaitForSecondsRealtime(cutInDisplayTime + 0.2f);
        }

        isTimeStopped = true;

        // 2. 강렬한 번쩍임 효과 (Flash)
        if (flashOverlay != null)
        {
            flashOverlay.gameObject.SetActive(true);
            flashOverlay.color = Color.white;
            StartCoroutine(FadeOutFlash());
        }

        // 3. 흑백 세상 전환
        if (grayscaleOverlay != null)
        {
            grayscaleOverlay.gameObject.SetActive(true);
            grayscaleOverlay.color = new Color(0.1f, 0.1f, 0.1f, 0.7f);
        }

        // 4. 시간 정지 실행 (SkillVisualEffect가 1로 되돌린 timescale을 다시 slow로 설정)
        Time.timeScale = timeSlowAmount;
        Debug.Log("스타 플래티나! 더 월드!");

        yield return new WaitForSecondsRealtime(stopDuration);

        // 5. 복구
        Time.timeScale = 1f;
        if (grayscaleOverlay != null) grayscaleOverlay.gameObject.SetActive(false);

        // --- 리스폰 보충 로직 ---
        if (EnemySpawner.instance != null)
        {
            int currentEnemyCount = FindObjectsOfType<SimpleEnemy>().Length;
            int spawnCount = EnemySpawner.instance.maxEnemyCount - currentEnemyCount;

            for (int i = 0; i < spawnCount; i++)
            {
                EnemySpawner.instance.SpawnEnemy();
            }
        }

        isTimeStopped = false;
        StartCoroutine(CooldownRoutine());
    }

    IEnumerator FadeOutFlash()
    {
        float alpha = 1.0f;
        while (alpha > 0)
        {
            alpha -= Time.unscaledDeltaTime * 2.0f;
            flashOverlay.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        flashOverlay.gameObject.SetActive(false);
    }

    IEnumerator CooldownRoutine()
    {
        currentCooldown = cooldownTime;
        while (currentCooldown > 0)
        {
            currentCooldown -= Time.unscaledDeltaTime;
            yield return null;
        }
        isCooldown = false;
    }

    void UpdateUI()
    {
        if (cooldownText == null) return;
        if (isTimeStopped) cooldownText.text = "TIME STOPPED";
        else if (isCooldown) cooldownText.text = currentCooldown.ToString("F1") + "s";
        else cooldownText.text = "READY";
    }
}