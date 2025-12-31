using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skill_Stand : MonoBehaviour
{
    public enum StandType { Polnareff, Avdol }

    [Header("스탠드 설정")]
    public StandType standType;      // 인스펙터에서 어떤 캐릭터인지 선택
    public string skillName;         // 스킬 이름 (로그 확인용)
    public float cooldown = 5f;      // 스킬 쿨타임

    [Header("화면 흔들기 설정")]
    public float shakeDuration = 0.2f;  // 흔들리는 시간
    public float shakeMagnitude = 0.1f; // 흔들리는 강도

    private bool isReady = true;     // 쿨타임 체크용
    private Image myImage;           // 캐릭터 색상 변경용

    void Start()
    {
        myImage = GetComponent<Image>();
    }

    void Update()
    {
        // 스페이스바를 누르고, 쿨타임이 아닐 때만 발동
        if (Input.GetKeyDown(KeyCode.Space) && isReady)
        {
            ExecuteSkill();
        }
    }

    void ExecuteSkill()
    {
        isReady = false;
        Debug.Log($"{skillName} 발동!");

        // 1. 화면 흔들기 실행 (아까 만든 CameraShake 호출)
        if (CameraShake.instance != null)
        {
            CameraShake.instance.Shake(shakeDuration, shakeMagnitude);
        }

        // 2. 캐릭터별 고유 로직 실행
        switch (standType)
        {
            case StandType.Polnareff:
                StartCoroutine(PolnareffSkill());
                break;
            case StandType.Avdol:
                AvdolSkill();
                break;
        }

        // 3. 쿨타임 시작
        StartCoroutine(CooldownRoutine());
    }

    // --- 폴나레프 로직: 3초간 데미지 강화 ---
    IEnumerator PolnareffSkill()
    {
        // 시각적 효과: 이미지를 빨갛게
        if (myImage != null) myImage.color = Color.red;

        // 여기에 데미지 강화 상태를 알리는 변수를 넣으면 좋습니다.
        // 예: PlayerStats.instance.isPowerUp = true;

        yield return new WaitForSeconds(3f);

        if (myImage != null) myImage.color = Color.white;
    }

    // --- 압둘 로직: 화면의 모든 적 즉시 소탕 ---
    void AvdolSkill()
    {
        SimpleEnemy[] enemies = FindObjectsOfType<SimpleEnemy>();
        int count = enemies.Length;

        for (int i = 0; i < count; i++)
        {
            // 적을 파괴하고 보상 지급
            GameManager.instance.totalPoints += enemies[i].goldReward;
            Destroy(enemies[i].gameObject);

            // 지운 만큼 다시 스폰
            EnemySpawner.instance.SpawnEnemy();
        }
    }

    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldown);
        isReady = true;
        Debug.Log($"{skillName} 준비 완료!");
    }
}