using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{

    public static int doorNumber = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");
        for (int i = 0; i < enters.Length; i++)
        { 
          GameObject doorObj = enters[i];
            Exit exit = doorObj.GetComponent<Exit>();
            if(doorNumber ==exit.doorNumber)
            {
                //같은 문 번호 일때 플레이어 캐릭터를 출입구로 이동
                float x = doorObj.transform.position.x;
                float y = doorObj.transform.position.y;
                if(exit.direction==ExitDirection.up)
                {
                    y += 1;
                }
                else if(exit.direction==ExitDirection.down)
               {
                    y -= 1; 
                }
                else if (exit.direction == ExitDirection.right)
                {
                    x += 1;
                }
                else if (exit.direction == ExitDirection.left)
                {
                    x -= 1;
                }
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x, y, 0);
                break;
            }
        }
    }

     public static void ChangeScene(string sceneName,int doorNum)
    {
        doorNumber = doorNum;
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
