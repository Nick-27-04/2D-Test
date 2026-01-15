using UnityEngine;

public class Door : MonoBehaviour
{
    //식별에 사용하기 위한 값, 배치 데이터를 저장하기 위해.
    public int arranged = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
           if(ItemKeeper.hasKeys>0)
            {
                ItemKeeper.hasKeys--;
                Destroy(this.gameObject);
            }

        }
    }


}
