
using UnityEngine;

public class CS_Gamemanager : MonoBehaviour
{
    public GameObject[] Type;  // 타입 종류 배열
    int count;  //  가중치
    int i = 0;// i 최대치 6
    bool darkCount = false;
    CS_Data Pdata;
    private void Start()
    {
        GetRandomType();
        Pdata.Type = Type[i].name;
    }
    private void Update()
    {

    }
    public void GetRandomType()  // 확률 설정
    {
        float ratio = 40f;
        darkCount = false;
        count = 0;
        int eggCount = 0;
            for (i = 0; i <= Type.Length - 1; i++)
            {
                float dice = Random.Range(1, 100);
                if (dice <= ratio)
                {
                    Debug.Log(Type[i].name);
                    i = Type.Length;
                }
                count++;
                if (count == 4)
                {
                    ratio = 4f;
                }
                if (count == Type.Length - 1 && darkCount)
                {
                    ratio = 1f;
                    i = 0;
                }

                else if (count == Type.Length - 1 && darkCount == false)
                {
                    i = 0;
                    count = 0;
                    darkCount = true;
                    eggCount++;
                }
                if (darkCount && ratio > dice && eggCount == 10)
                {
                    Jackpot();
                    Debug.Log("잭팟");
                    i = Type.Length;
                }
                else
                {
                    if (darkCount && eggCount == 10)
                    {
                        int index = Random.Range(0, 2);
                        Debug.Log(Type[index].name);
                        i = Type.Length;
                    }
                }
            
        }                    
    }
    void Jackpot()
    {

    }
}

