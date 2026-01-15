using UnityEngine;

public class CS_NpcController : MonoBehaviour
{
    bool canCommunication = false;
    public GameObject[] npcObject;
    int npcNumber;
    private void Start()
    {
    }
    public void Communication()
    {
        if (canCommunication == false)
        {
            return;
        }
        switch (npcNumber) {
            case (0):
                Debug.Log("1");
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "1")
        {
            npcNumber = 0;
        }
        canCommunication = true;
        Communication();
    }
}
