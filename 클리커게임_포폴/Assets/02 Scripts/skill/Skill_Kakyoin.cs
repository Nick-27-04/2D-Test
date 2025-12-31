using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Skill_Kakyoin : MonoBehaviour
{
    [Header("스킬 설정")]
    public float barrierDuration = 2f;
    public float cooldownTime = 15f;
    public Vector2 barrierSize = new Vector2(800f, 150f);
    public float attackInterval = 0.2f;

    [Header("시각 효과")]
    public Sprite kakyoinCutInSprite;    // ⭐ 카쿄인 컷인 이미지 등록
    public float cutInDisplayTime = 0.5f;
    public GameObject emeraldBoxPrefab;
    public GameObject hitEffectPrefab;

    [Header("Status")]
    public bool barrierActive = false;
    private bool isCooldown = false;
    private float currentCooldown = 0f;

    [Header("UI 연결")]
    public TextMeshProUGUI cooldownText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !barrierActive && !isCooldown)
        {
            StartCoroutine(ActivateBoxBarrier());
        }
        UpdateUI();
    }

    IEnumerator ActivateBoxBarrier()
    {
        isCooldown = true; // 쿨타임 먼저 시작 (연타 방지)

        // 1. ⭐ 카쿄인 컷인 연출 호출
        if (SkillVisualEffect.instance != null && kakyoinCutInSprite != null)
        {
            SkillVisualEffect.instance.ShowSkillCutIn(kakyoinCutInSprite, cutInDisplayTime);
            // 컷인이 끝날 때까지 대기 (Time.timeScale이 0이 되므로 Realtime 대기 필요)
            yield return new WaitForSecondsRealtime(cutInDisplayTime + 0.2f);
        }

        barrierActive = true;
        GameObject visualBox = null;

        if (emeraldBoxPrefab != null && EnemySpawner.instance != null)
        {
            visualBox = Instantiate(emeraldBoxPrefab, EnemySpawner.instance.spawnArea);
            visualBox.transform.localPosition = Vector3.zero;
            RectTransform rt = visualBox.GetComponent<RectTransform>();
            if (rt != null) rt.sizeDelta = barrierSize;
        }

        float timer = 0f;
        float lastAttackTime = 0f;

        while (timer < barrierDuration)
        {
            if (timer >= lastAttackTime)
            {
                StartCoroutine(KillEnemiesSequentially());
                lastAttackTime += attackInterval;
            }

            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        if (visualBox != null) Destroy(visualBox);
        barrierActive = false;

        StopCoroutine("CooldownRoutine");
        StartCoroutine(CooldownRoutine());
    }

    IEnumerator KillEnemiesSequentially()
    {
        if (EnemySpawner.instance == null) yield break;

        SimpleEnemy[] allEnemies = FindObjectsOfType<SimpleEnemy>();
        float halfWidth = barrierSize.x / 2f;
        float halfHeight = barrierSize.y / 2f;

        foreach (SimpleEnemy enemy in allEnemies)
        {
            if (enemy == null) continue;
            Vector3 localPos = enemy.transform.localPosition;

            if (localPos.x >= -halfWidth && localPos.x <= halfWidth &&
                localPos.y >= -halfHeight && localPos.y <= halfHeight)
            {
                if (hitEffectPrefab != null)
                {
                    GameObject fx = Instantiate(hitEffectPrefab, enemy.transform.position, Quaternion.identity);
                    fx.transform.localScale = Vector3.one * 1.5f;
                    Destroy(fx, 0.5f);
                }

                enemy.OnClickEnemy();
                yield return new WaitForSecondsRealtime(0.02f);
            }
        }
    }

    IEnumerator CooldownRoutine()
    {
        // currentCooldown 설정은 ActivateBoxBarrier 끝에서 넘어온 시점부터 남은 시간 계산
        currentCooldown = cooldownTime;

        while (currentCooldown > 0)
        {
            currentCooldown -= Time.unscaledDeltaTime;
            yield return null;
        }

        currentCooldown = 0f;
        isCooldown = false;
    }

    void UpdateUI()
    {
        if (cooldownText == null) return;

        if (barrierActive)
            cooldownText.text = "에메랄드 스플래시!";
        else if (isCooldown)
            cooldownText.text = Mathf.Max(0, currentCooldown).ToString("F1") + "s";
        else
            cooldownText.text = "READY";
    }
}