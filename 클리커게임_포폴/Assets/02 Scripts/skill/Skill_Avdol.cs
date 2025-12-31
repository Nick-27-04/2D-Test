using UnityEngine;
using System.Collections;
using TMPro;

public class Skill_Avdol : MonoBehaviour
{
    [Header("스킬 설정")]
    public float cooldownTime = 15f;    // 쿨타임 (초)
    public float destructionDelay = 0.05f; // 적들이 차례로 터지는 간격

    [Header("시각 효과")]
    public Sprite avdolCutInSprite;    // 압둘 컷인 이미지 등록
    public float cutInDisplayTime = 0.5f;
    public GameObject fireEffectPrefab; // 불꽃 파티클 프리팹
    public float effectScale = 100f;

    [Header("UI 연결")]
    public TextMeshProUGUI cooldownText;

    private float currentCooldown = 0f;
    private bool isCooldown = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isCooldown)
        {
            StartCoroutine(UseCrossFireRoutine());
        }
        UpdateUI();
    }

    IEnumerator UseCrossFireRoutine()
    {
        isCooldown = true;

        // 1. ⭐ 압둘 컷인 연출 시작
        if (SkillVisualEffect.instance != null && avdolCutInSprite != null)
        {
            SkillVisualEffect.instance.ShowSkillCutIn(avdolCutInSprite, cutInDisplayTime);
            // 컷인 연출 동안 게임이 멈추므로, 연출이 끝날 때까지 여기서 기다려줍니다.
            yield return new WaitForSecondsRealtime(cutInDisplayTime + 0.2f);
        }

        Debug.Log("크로스 파이어 허리케인 스페셜!");

        // 2. 화면에 있는 모든 적 찾기
        SimpleEnemy[] enemies = FindObjectsOfType<SimpleEnemy>();

        foreach (SimpleEnemy enemy in enemies)
        {
            if (enemy == null) continue;

            // --- 파티클 생성 ---
            if (fireEffectPrefab != null)
            {
                GameObject effect = Instantiate(fireEffectPrefab, enemy.transform.position, Quaternion.identity);
                effect.transform.SetParent(enemy.transform.parent);
                effect.transform.localScale = Vector3.one * effectScale;
                Destroy(effect, 3f);
            }

            // --- 적 제거 및 포인트 추가 ---
            // 직접 Destroy 하는 대신 적 스크립트의 로직을 태우는 것이 가장 안전합니다.
            enemy.OnClickEnemy();

            // 연쇄 폭발 연출
            if (destructionDelay > 0)
                yield return new WaitForSeconds(destructionDelay);
        }

        // 3. UI 갱신 (OnClickEnemy에서 처리하지만 확실히 하기 위해 한 번 더 호출)
        if (LevelManager.instance != null) LevelManager.instance.RefreshProgress();

        // 4. 쿨타임 시작
        StartCoroutine(CooldownRoutine());
    }

    IEnumerator CooldownRoutine()
    {
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
        if (isCooldown) cooldownText.text = currentCooldown.ToString("F1") + "s";
        else cooldownText.text = "READY";
    }
}