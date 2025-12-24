using UnityEngine;

public class GameCotnter : MonoBehaviour
{
    public static int value; //공유하는 카운터의 값

    public int startCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        value = startCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
