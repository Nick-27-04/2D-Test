using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public long goldReward = 50;
    private bool isDead = false;

    public void OnClickEnemy()
    {
        // 1. 중복 실행 방지
        if (isDead) return;
        isDead = true;

        // 2. 보너스 데미지/골드 계산 (기존 로직 유지)
        long finalReward = goldReward;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Skill_Polnareff pol = player.GetComponent<Skill_Polnareff>();
            if (pol != null && pol.isSkillActive)
            {
                finalReward += pol.bonusDamage;
            }
        }

        // 3. 데이터 반영
        if (GameManager.instance != null)
            GameManager.instance.totalPoints += finalReward;

        if (LevelManager.instance != null)
            LevelManager.instance.RefreshProgress();

        // ---------------------------------------------------------
        // 4. 새로운 적 소환 (죠타로 시간 정지 시 리스폰 방지 추가)
        // ---------------------------------------------------------
        if (EnemySpawner.instance != null)
        {
            // 죠타로 스크립트를 가진 오브젝트를 찾습니다.
            // (보통 Jotaro라는 이름의 오브젝트나 Player에 붙어있을 겁니다)
            Skill_Jotaro jotaro = FindObjectOfType<Skill_Jotaro>();

            // 죠타로가 없거나, 시간이 멈춘 상태가 아닐 때만 소환 실행
            if (jotaro == null || !jotaro.isTimeStopped)
            {
                EnemySpawner.instance.SpawnEnemy();
            }
            else
            {
                // 시간 정지 중에는 스폰하지 않음
                Debug.Log("The World! 리스폰 중단");
            }
        }

        // 5. 카쿄인 등 메시지 처리
        SendMessage("OnEnemyDeath", SendMessageOptions.DontRequireReceiver);

        // 6. 삭제
        Destroy(gameObject);
    }
}