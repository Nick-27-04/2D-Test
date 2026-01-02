using UnityEngine;
//using Items;
public class ItemManager : MonoBehaviour
{

    public GameObject[] ItemPrefabs = new GameObject[3];

    public Point[] Points = {
        new Point(0,0),
        new Point(1,1),
        new Point(1,-1),
        new Point(-1,1),
        new Point(-1,-1),
        new Point(2,2),
        new Point(2,-2),
        new Point(-2,2),
        new Point(-2,-2),
        new Point(3,3),
        new Point(3,-3),
        new Point(-3,3),
        new Point(-3,-3),
    };

    void Start()
    {
        //GameObject coinPrefabs = ItemPrefabs[(int)Items.Items.Coin];
        //GameObject speedUpPrefabs = ItemPrefabs[(int)Items.Items.SpeedUp];
        //GameObject powerUpPrefabs = ItemPrefabs[(int)Items.Items.PowerUp];

        /*
        for (int i = 0; i < ItemPrefabs.Length; i++)
        {
            GameObject itemPrefabs = ItemPrefabs[Random.Range(0,ItemPrefabs.Length)];
            Vector2 pos = Points[Random.Range(0,Points.Length)].GetPos();
            SpawnItem(itemPrefabs,pos);
        }
        */
        SpawnRandom();
    }

    public void SpawnItem(GameObject itemPrefab, Vector3 _position)
    {
        GameObject obj = Instantiate(itemPrefab);
        obj.transform.position = _position;
    }

    public void SpawnRandom()
    {
        GameObject prefab = ItemPrefabs[Random.Range(0, ItemPrefabs.Length)];
        Vector2 pos = Points[Random.Range(0, Points.Length)].GetPos();
        SpawnItem(prefab, pos);
        Invoke("SpawnRandom", 0.3f); //Àç±Í
    }

}



public struct Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 GetPos()
    {
        return new Vector2(x, y);
    }
}