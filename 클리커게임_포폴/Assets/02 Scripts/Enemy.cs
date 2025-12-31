using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("적 정보")]
    public string enemyName;
    public long maxHp = 100;
    public long currentHp;
    public long goldReward = 50; // 처치 시 주는 포인트

    [Header("UI 연결")]
    public Slider hpSlider;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI enemyNameText;

    void Start()
    {
        ResetEnemy();
    }

    // 적이 클릭되었을 때 실행 (버튼이나 온클릭 이벤트로 연결)
    public void OnDamaged()
    {
        // 현재 공격력만큼 체력 차감 (GameManager에 공격력 변수가 있다고 가정)
        // 만약 공격력 변수가 없다면 일단 10씩 깎이게 해둘게요!
        long damage = 10;

        currentHp -= damage;
        UpdateUI();

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{enemyName} 처치! {goldReward} 포인트를 얻었습니다.");

        // GameManager의 totalPoints 증가
        GameManager.instance.totalPoints += goldReward;

        // 레벨 매니저에게 포인트가 변했다고 알려줌 (게이지 갱신용)
        LevelManager.instance.RefreshProgress();

        // 적 재생성 (체력 회복 및 다음 적 등장 연출 가능)
        ResetEnemy();
    }

    void ResetEnemy()
    {
        currentHp = maxHp;
        enemyNameText.text = enemyName;
        UpdateUI();
    }

    void UpdateUI()
    {
        hpSlider.value = (float)currentHp / maxHp;
        hpText.text = $"{currentHp:N0} / {maxHp:N0}";
    }
}