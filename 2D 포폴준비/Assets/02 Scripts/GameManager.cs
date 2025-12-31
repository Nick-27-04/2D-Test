using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    private void Awake()
    {
        gm = this;
    }

    public long money;
    public long moneyIncreaseAmount;

    public Text textMoney;
    public Text textEmployee;

    public GameObject prefabMoney;

    private void Update()
    {
        ShowInfo();
        MoneyIncrease();

        //UpdateUpgradePanel();
        ButtonActiveCheck();
        ButtonRecruitActiveCheck();

        UpdateRecruitPanelText();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void OnApplicationQuit()
    {
        //PlayerPrefs.SetString("MONEY", money.ToString());
        Save();
    }


    void ShowInfo()
    {
        if (money == 0)
        {
            textMoney.text = "0";
        }
        else
        {
            textMoney.text = money.ToString("###,###") + "원";
        }

        if (employeeCount != 0)
        {
            textEmployee.text = employeeCount.ToString("###,###") + "명";
        }
        else
        {
            textEmployee.text = "0 명";
        }
    }

    void MoneyIncrease()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Vector2 mousePosition =
                    Camera.main.ScreenToWorldPoint(Input.mousePosition);

                GameObject moneyObj =
                    Instantiate(prefabMoney, mousePosition, Quaternion.identity);

                money += moneyIncreaseAmount;
            }
        }
    }


    public long moneyIncreaseLevel;
    public long moneyIncreasePrice;


    public GameObject panelPrice;
    Text textPrice;

    private void Start()
    {
        textPrice = panelPrice.transform.GetComponentInChildren<Text>();
        textRecruit = panelRecruit.transform.GetComponentInChildren<Text>();
        //string moneyString = PlayerPrefs.GetString("MONEY");
        // money = long.Parse(moneyString);
        string path = Application.persistentDataPath + "/save.xml";

        if (System.IO.File.Exists(path))
        {
            Load();
            //불러온 데이터를 통해 직원이 생성될 수 있는 [함수]를 호출!!
            FillEmployee();

        }

    }

    void FillEmployee()
    {
        //employeeCount = 5;
        GameObject[] employees = GameObject.FindGameObjectsWithTag("Employee");

        if (employeeCount  != employees.Length)
        {

            for (int i = 0; i < employeeCount; i++)
            {
                Vector2 bossSpot = GameObject.Find("Boss").transform.position;
                float spotX = bossSpot.x + (i % width) * space;
                float spotY = bossSpot.y - (i / width) * space;
                Instantiate(prefabEmployee, new Vector2(spotX, spotY), Quaternion.identity);
                CreatFloor();
            }
        }
    }


    public void UpdateUpgradePanel()
    {
        if (panelPrice.activeSelf == true)
        {
            textPrice.text = "Lv." + moneyIncreaseLevel + "단가 상승\n";
            textPrice.text += "외주 당 단가 >\n";
            textPrice.text += moneyIncreaseAmount.ToString("###,###") + "원\n";
            textPrice.text += "업그레이드 가격 >\n";
            textPrice.text += moneyIncreasePrice.ToString("###,###") + "원";
        }

    }

    public void UpgradePrice()
    {
        if (money >= moneyIncreasePrice)
        {
            money -= moneyIncreasePrice;
            moneyIncreaseLevel += 1;
            moneyIncreaseAmount = moneyIncreaseLevel * 100;
            moneyIncreasePrice = moneyIncreaseLevel * 500;

            UpdateUpgradePanel();
        }
    }


    public Button buttonPrice;

    public void ButtonActiveCheck()
    {
        if (money >= moneyIncreasePrice)
        {
            buttonPrice.interactable = true;
        }
        else
        {
            buttonPrice.interactable = false;
        }
    }

    //고용 패널 처리
    #region Recruit
    public int employeeCount = 1;
    public Button buttonRecruit;
    public GameObject panelRecruit;
    Text textRecruit;
    //public int employeeIncreaseAmount;
    //public int employeeIncreasePrice;
    public void UpdateRecruitPanelText()
    {
        if (panelRecruit.activeSelf == true)
        {
            textRecruit.text = "Lv." + employeeCount + "신규 고용\n";
            textRecruit.text += "직원 외주 당 단가 >\n";
            textRecruit.text += AutoWork.autoMoneyIncreaseAmount.ToString("###,###") + "원\n";
            textRecruit.text += "업그레이드 가격 >\n";
            textRecruit.text += AutoWork.autoIncreasePrice.ToString("###,###") + "원";
        }
    }

    public void ButtonRecruitActiveCheck()
    {
        if (money >= AutoWork.autoIncreasePrice)
        {
            buttonRecruit.interactable = true;
        }
        else
        {
            buttonRecruit.interactable = false;
        }
    }

    //실제 직원(프리팹) 배치
    public int width; //가로 최대 배치 가능 직원 수
    public float space; //직원 간격
    public GameObject prefabEmployee;

    //직원을 만드는 함수
    void CreatEmployee()
    {
        Vector2 bossSpot = GameObject.Find("Boss").transform.position;
        float spotX = bossSpot.x + (employeeCount % width) * space;
        float spotY = bossSpot.y - (employeeCount / width) * space;
        Instantiate(prefabEmployee, new Vector2(spotX, spotY), Quaternion.identity);
    }


    public void Recuit()
    {
        if (money >= AutoWork.autoIncreasePrice)
        {
            CreatEmployee();
            money -= AutoWork.autoIncreasePrice;
            employeeCount += 1;
            AutoWork.autoMoneyIncreaseAmount += employeeCount * 5;
            AutoWork.autoIncreasePrice += employeeCount * 500;

            CreatFloor(); //바닥생성

            UpdateRecruitPanelText();
        }
    }



    #endregion

    //바닥 만들기
    public float spaceFloor;
    public int floorCapacity;//9명

    float currentFloor = 1;

    public GameObject prefabFloor;

    void CreatFloor()
    {
        Vector2 bgPosition = GameObject.Find("Background").transform.position;
        float nextFloor = (employeeCount) / floorCapacity;

        float spotX = bgPosition.x;
        float spotY = bgPosition.y;

        spotY -= spaceFloor * nextFloor;

        if (nextFloor >= currentFloor)
        {
            Instantiate(prefabFloor, new Vector2(spotX, spotY), Quaternion.identity);
            currentFloor += 1;

            Camera.main.GetComponent<CameraDrag>().limitMinY -= spaceFloor;
        }

    }

    void Save()
    {
        SaveData saveData = new SaveData();
        saveData.money = money;
        saveData.moneyIncreaseAmount = moneyIncreaseAmount;
        saveData.moneyIncreaseLevel = moneyIncreaseLevel;
        saveData.moneyIncreasePrice = moneyIncreasePrice;
        saveData.employeeCount = employeeCount;
        saveData.autoMoneyIncreaseAmount = AutoWork.autoMoneyIncreaseAmount;
        saveData.autoIncreasePrice = AutoWork.autoIncreasePrice;

        string path = Application.persistentDataPath + "/save.xml";

        XmlManager.XmlSave<SaveData>(saveData, path);
    }


    void Load()
    {
        SaveData saveData = new SaveData();
        string path = Application.persistentDataPath + "/save.xml";
        saveData = XmlManager.XmlLoad<SaveData>(path);
        money = saveData.money;
        moneyIncreaseAmount = saveData.moneyIncreaseAmount;
        moneyIncreaseLevel = saveData.moneyIncreaseLevel;
        moneyIncreasePrice = saveData.moneyIncreasePrice;
        employeeCount = saveData.employeeCount;
        AutoWork.autoMoneyIncreaseAmount = saveData.autoMoneyIncreaseAmount;
        AutoWork.autoIncreasePrice = saveData.autoIncreasePrice;
    }

    //옵션처리
    //사운드 볼륨 조절 
     //  public Slider bgm_silder;
    public AudioSource audioSource;
    public Slider bgm_silder;

    public void ChangeBgmSOund(float value)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = bgm_silder.value;

        // audioSource.mute =true
    }

}

[System.Serializable]
public class SaveData
{
    public long money;
    public long moneyIncreaseAmount;
    public long moneyIncreaseLevel;
    public long moneyIncreasePrice;
    public int employeeCount;

    public long autoMoneyIncreaseAmount;
    public long autoIncreasePrice;


}
