using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //积己 困摹
    [SerializeField]
    GameObject[] spawnPoints;

    //积己 畴飘
    [SerializeField]
    Transform[] spawnTransform;

    [SerializeField]
    GameObject gameUI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("CreatePoint", 2f, UnityEngine. Random.Range(1,6));
        
    }

    private void CreatePoint()
    {
        for (int i = 0;i < spawnPoints.Length; i++)
        {
            GameObject m_SpawnPoints = Instantiate(spawnPoints[i]);
           // m_SpawnPoints.transform.parent = gameUI.transform;
            m_SpawnPoints.transform.SetParent(gameUI.transform);
            m_SpawnPoints.transform.localPosition = spawnTransform[i].localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
