using UnityEngine;

namespace Items
{


 public abstract class Item : MonoBehaviour
 {
    public abstract void DestroyAfterTime();
    public abstract void ApplyItem();

    private void Start()
    {
        DestroyAfterTime();
    }
 }
    public enum Items
    {
        Coin, SpeedUp, PowerUp

    }
}

