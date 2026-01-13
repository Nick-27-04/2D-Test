using Unity.VisualScripting;
using UnityEngine;

public class CoolTime 
{
    public float cooltime;
    float coolCnt = 0;

    void Start()
    {
        coolCnt = Time.time;
    }

    public float Timer(float t)
    {
        cooltime += Time.deltaTime;
        if (coolCnt + t <= Time.time)
        {
            coolCnt = Time.time;
            cooltime = 0f;
        }
        return cooltime;
    }
}
