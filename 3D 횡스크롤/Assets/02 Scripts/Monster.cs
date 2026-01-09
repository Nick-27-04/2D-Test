using UnityEngine;

public class Monster : MonoBehaviour
{
    GameObject monster;
    public float moveSpeed;

    public void Die()
    {
        GetComponent<Animator>().SetTrigger("isDead");
        GetComponent<Collider>().enabled = false;

        // 현재 오브젝트의 부모를 삭제 (전체 삭제)
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject, 0.5f);
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime,Space.World);
    }
    // Monster ��ũ��Ʈ �ȿ� �߰��ϼ���
    private void OnCollisionEnter(Collision collision)
    {
        // 1. �浹�� ��ü�� �÷��̾����� Ȯ��
        if (collision.gameObject.CompareTag("Player"))
        {
            // 2. �÷��̾��� ��ġ�� ������ ��ġ���� ������ Ȯ�� (��Ҵ��� �Ǵ�)
            // contact.normal.y�� -0.7f ���� ������ ������ �Ʒ��� �浹�ߴٴ� ���Դϴ�.
            if (collision.contacts[0].normal.y < -0.7f)
            {
                Die();

                // (����) �÷��̾ ��¦ ���� ƨ�ܿ����� �����
                Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 7f);
            }
        }
    }
}
