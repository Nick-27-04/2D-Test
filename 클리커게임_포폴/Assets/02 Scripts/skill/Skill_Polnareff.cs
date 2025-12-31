using UnityEngine;
using System.Collections;
using TMPro;

public class Skill_Polnareff : MonoBehaviour
{
    [Header("Skill Settings")]
    public float skillDuration = 4f;      // 스킬 지속 시간
    public float cooldownTime = 12f;
    public float attackInterval = 0.05f;
    public int bonusDamage = 50;
    private float lastAttackTime;

    [Header("Visual Effects")]
    public Sprite polnareffCutInSprite;
    public float cutInDisplayTime = 0.5f;
    public GameObject hitEffectPrefab;

    [Tooltip("마우스 타격 이펙트의 크기를 조절합니다.")]
    public float effectScale = 1.0f;

    [Header("Status")]
    public bool isSkillActive = false;
    public bool isCooldown = false;
    private float currentCooldown = 0f;
    private float currentSkillTimer = 0f;

    [Header("UI Connections")]
    public TextMeshProUGUI cooldownText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSkillActive && !isCooldown)
        {
            StartCoroutine(StartSkill());
        }

        if (isSkillActive && Input.GetMouseButton(0))
        {
            if (Time.time - lastAttackTime > attackInterval)
            {
                PerformRapidAttack();
                lastAttackTime = Time.time;
            }
        }

        UpdateCooldownUI();
    }

    IEnumerator StartSkill()
    {
        isSkillActive = true;
        currentSkillTimer = skillDuration;

        if (SkillVisualEffect.instance != null && polnareffCutInSprite != null)
        {
            SkillVisualEffect.instance.ShowSkillCutIn(polnareffCutInSprite, cutInDisplayTime);
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.color = new Color(1, 1, 1, 0.6f);

        while (currentSkillTimer > 0)
        {
            currentSkillTimer -= Time.deltaTime;
            yield return null;
        }

        if (sr != null) sr.color = Color.white;
        isSkillActive = false;
        StartCoroutine(CooldownRoutine());
    }

    void PerformRapidAttack()
    {
        // 1. 마우스 월드 좌표 계산
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        // 2. 이펙트 생성
        if (hitEffectPrefab != null)
        {
            GameObject effect = Instantiate(hitEffectPrefab, mouseWorldPos, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
            effect.transform.localScale = Vector3.one * effectScale;
            Destroy(effect, 0.15f);
        }

        // 3. ⭐ 판정 개선: Collider가 없으므로 모든 적과 마우스 사이의 '거리'를 계산합니다.
        SimpleEnemy[] allEnemies = FindObjectsOfType<SimpleEnemy>();

        // 클릭 판정 허용 범위 (적이 작으면 0.6f, 적이 크면 1.0f 정도로 조절하세요)
        float clickThreshold = 0.8f;

        foreach (SimpleEnemy enemy in allEnemies)
        {
            if (enemy == null) continue;

            // 마우스와 적 사이의 거리 측정
            float distance = Vector2.Distance(mouseWorldPos, enemy.transform.position);

            if (distance <= clickThreshold)
            {
                // 거리 안에 들어왔다면 피격 처리
                enemy.OnClickEnemy();

                // 폴나레프의 정밀 동작 느낌을 주려면 한 번에 한 놈만 베도록 break;
                // 한 번에 뭉쳐있는 적을 다 베고 싶다면 아래 break;를 지우면 됩니다.
                break;
            }
        }
    }

    IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        currentCooldown = cooldownTime;
        while (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            yield return null;
        }
        isCooldown = false;
    }

    void UpdateCooldownUI()
    {
        if (cooldownText == null) return;

        if (isSkillActive)
            cooldownText.text = "RAPID: " + currentSkillTimer.ToString("F1") + "s";
        else if (isCooldown)
            cooldownText.text = currentCooldown.ToString("F1") + "s";
        else
            cooldownText.text = "READY";
    }
}