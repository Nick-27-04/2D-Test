using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject ShurikenPrefabs;
    public float FireRate = 1.0f;
    public Transform FirePoint;

    MonsterScanner scanner;
    float _timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _scanner = GetComponent<MonsterScaner>();
        if(_scanner == null )
        {
            Debug.LogError("스캔정보없어요!!");
        }

        if( FirePoint == null )
        {
            FirePoint = transform;

        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > FireRate)
        {
            FIreShuriken();
            _timer = 0f;

        }
    }

    private void FireShuriken()
    {
        Transform targetEnemy = _scanner.GetNearestEnemy();

        if (targetEnemy == null) { return; }

        Vector2 direction = (targetEnemy.position - FirePoint.position).normalized;

        GameObject shuriken =
            Instantiate(ShurikenPrefabs,FirePoint.position,Quaternion.identity);
        Shurikan shurikanComp = shuriken.GetComponent<Shurikan>();

        if (shurikanComp != null)
        { 
           shurikanComp.Init(direction);
        }

    }

}
