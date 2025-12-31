using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [Header("적 설정")]
    public GameObject[] enemyPrefabs;
    public int maxEnemyCount = 15;
    public float spawnInterval = 2f;

    [Header("스폰 영역")]
    public RectTransform spawnArea;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < maxEnemyCount / 2; i++)
        {
            SpawnEnemy();
        }
        StartCoroutine(AutoSpawnRoutine());
    }

    IEnumerator AutoSpawnRoutine()
    {
        while (true)
        {
            Skill_Jotaro jotaro = FindObjectOfType<Skill_Jotaro>();
            Skill_Kakyoin kakyoin = FindObjectOfType<Skill_Kakyoin>();

            // [자동 스폰 조건] 
            // 1. 죠타로가 시간을 멈추지 않았을 때
            // 2. 혹은 카쿄인이 결계를 쓰고 있을 때 (결계 중엔 계속 보충되어야 함)
            bool canSpawn = (jotaro == null || !jotaro.isTimeStopped) || (kakyoin != null && kakyoin.barrierActive);

            if (canSpawn)
            {
                int currentEnemyCount = FindObjectsOfType<SimpleEnemy>().Length;
                if (currentEnemyCount < maxEnemyCount)
                {
                    SpawnEnemy();
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0 || spawnArea == null) return;

        // --- ⭐ 핵심 수정 포인트: 즉시 소환 제한 해제 ---
        Skill_Jotaro jotaro = FindObjectOfType<Skill_Jotaro>();
        Skill_Kakyoin kakyoin = FindObjectOfType<Skill_Kakyoin>();

        // 죠타로가 시간을 멈췄더라도, 카쿄인이 결계 스킬을 쓰고 있다면 소환을 허용함
        if (jotaro != null && jotaro.isTimeStopped)
        {
            // 카쿄인 스킬이 꺼져있을 때만 리턴 (소환 차단)
            if (kakyoin == null || !kakyoin.barrierActive)
            {
                return;
            }
        }
        // --------------------------------------------

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject selectedPrefab = enemyPrefabs[randomIndex];
        if (selectedPrefab == null) return;

        GameObject newEnemy = Instantiate(selectedPrefab, spawnArea);
        newEnemy.transform.localScale = Vector3.one;
        newEnemy.transform.SetAsLastSibling();

        float width = spawnArea.rect.width;
        float height = spawnArea.rect.height;
        float randomX = Random.Range(-width / 2f, width / 2f);
        float randomY = Random.Range(-height / 2f, height / 2f);

        newEnemy.transform.localPosition = new Vector3(randomX, randomY, 0);
    }
}