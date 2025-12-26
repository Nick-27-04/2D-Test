using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Src_Game : MonoBehaviour
{
    public TextMeshProUGUI stageVal, creditVal;
    public TextMeshProUGUI abilityCostTxt, employeeCostTxt, buildingCostTxt;


    public Image[] stg = new Image[4];

    int stage, credit;

    int ability, employee, building = 0;

    int abilityCost = 100;
    int employeeCost = 500;
    int buildingCost = 20000;

    int countA, countE, countB = 0;


    //public Button btnAbility;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        credit = 100;
        stage = 1;
        ability = employee = building = countA = countE = countB = 0;




        /*
        stg[0].gameObject.SetActive(true);
        stg[1].gameObject.SetActive(false);
        stg[2].gameObject.SetActive(false);
        stg[3].gameObject.SetActive(false);

        for(int i = 0; i < stg.Length; i++)
        {
            if(i == stage- 1)
            {
                stg[i].gameObject.SetActive(true);
            }
            else
            {
                stg[i].gameObject.SetActive(false);
            }
        }
        */
        CurrentStage((stage));
    }

    // Update is called once per frame
    void Update()
    {
        stageVal.text = (stage).ToString();
        creditVal.text = credit.ToString();

        /*
        btnAbility.interactable = false;

        if (credit >= 100 * (countA + 1))
        {
            btnAbility.interactable = true;
        }
        */
        //abilityCostTxt.text = "Cost : +" + abilityCost.ToString() + "per Buy";
        abilityCostTxt.text = string.Format("Cost : +{0} per Buy", (abilityCost).ToString());
        employeeCostTxt.text = string.Format("Cost : +{0} per Buy", (employeeCost).ToString());
        buildingCostTxt.text = string.Format("Cost : +{0} per Buy", (buildingCost).ToString());
    }


    public void CurrentStage(int stage)
    {
        for (int i = 0; i < stg.Length; i++)
        {
            if (i == stage - 1)
            {
                stg[i].gameObject.SetActive(true);
            }
            else
            {
                stg[i].gameObject.SetActive(false);
            }
        }
    }

    public void Cheat_credit()
    {
        credit += 5000;
    }

    public void ClickBtn()
    {
        //돈증가
        Debug.Log("돈증가");
        credit = credit + (1 + ability + employee + building);
        //credit++;
        //credit += 1;



    }
    //
    public void AddAbility()
    {
        //기술력 증가
        Debug.Log("기술력 증가");


        if (credit >= 100 * (countA + 1))
        {
            countA++;
            credit -= 100 * countA;
            ability += 10;
            abilityCost = 100 * (countA + 1);
        }
    }

    public void AddEmployee()
    {
        //고용인 증가
        Debug.Log("고용인 증가");

        if (credit >= 500 * (countE + 1))
        {
            countE++;
            credit -= 500 * countE;
            employee += 50;
            employeeCost = 500 * (countE + 1);
        }
    }
    //
    public void UpgradeBuilding()
    {
        //건물업그레이드
        Debug.Log("건물업그레이드");

        if (credit >= 20000 * (countB + 1))
        {
            countB++;
            credit -= (20000 * countB) / 2;
            building += 2000;
            buildingCost = 20000 * (countB + 1) / 2;

            //stage = countB+1;

            if (countB < 10)
            {
                stage = (countB / 3 + 1);
            }


            CurrentStage(stage);
            /*
            switch (countB / 3)
            {
                case 0:
                    stg[0].gameObject.SetActive(true);
                    break;
                case 1:
                    stg[0].gameObject.SetActive(false);
                    stg[1].gameObject.SetActive(true);
                    break;
                case 2:
                    stg[1].gameObject.SetActive(false);
                    stg[2].gameObject.SetActive(true);
                    break;
                case 3:
                    stg[2].gameObject.SetActive(false);
                    stg[3].gameObject.SetActive(true);
                    break;
                default:
                    break;
            

            }
            */
        }
    }
}
