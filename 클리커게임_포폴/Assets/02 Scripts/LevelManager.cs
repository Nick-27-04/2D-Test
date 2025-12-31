using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class LevelData
{
    public string charName;          // 영문 이름 (예: JOTARO, AVDOL)
    public GameObject charObject;
    public long upgradeThreshold;
}

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public LevelData[] levels;
    public int currentLevelIndex = 0;

    [Header("UI Connections")]
    public TextMeshProUGUI levelNameText;
    public Slider levelProgressBar;
    public TextMeshProUGUI progressText;
    public Button upgradeButton;
    public TextMeshProUGUI upgradeButtonText;

    void Awake() => instance = this;

    void Start()
    {
        UpdateCharacterDisplay();
        RefreshProgress();
    }

    void UpdateCharacterDisplay()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i].charObject != null)
            {
                // 캐릭터 전환 시 로직 (Active 상태 변경)
                levels[i].charObject.SetActive(i == currentLevelIndex);
            }
        }

        if (currentLevelIndex < levels.Length)
        {
            // 한글 대신 영문으로 표시
            levelNameText.text = $"Lv.{currentLevelIndex + 1} {levels[currentLevelIndex].charName.ToUpper()}";
        }
    }

    public void RefreshProgress()
    {
        if (levels == null || levels.Length == 0) return;

        // MAX LEVEL Check
        if (currentLevelIndex >= levels.Length - 1)
        {
            levelProgressBar.value = 1f;
            progressText.text = "MAX LEVEL REACHED";
            upgradeButton.interactable = false;
            upgradeButtonText.text = "FINAL FORM";
            return;
        }

        long target = levels[currentLevelIndex].upgradeThreshold;
        long current = GameManager.instance.totalPoints;

        levelProgressBar.value = (float)current / target;
        progressText.text = $"{current:N0} / {target:N0}";

        // Button State
        if (current >= target)
        {
            upgradeButton.interactable = true;
            upgradeButtonText.text = "EVOLVE!"; // 한글 대신 영문
        }
        else
        {
            upgradeButton.interactable = false;
            upgradeButtonText.text = "NEED MORE POINTS"; // 한글 대신 영문
        }
    }

    public void OnUpgradeButtonClick()
    {
        if (currentLevelIndex >= levels.Length - 1) return;

        // 포인트 차감 및 레벨업
        GameManager.instance.totalPoints -= levels[currentLevelIndex].upgradeThreshold;
        currentLevelIndex++;

        UpdateCharacterDisplay();
        RefreshProgress();

        Debug.Log($"Evolved to {levels[currentLevelIndex].charName}!");
    }
}