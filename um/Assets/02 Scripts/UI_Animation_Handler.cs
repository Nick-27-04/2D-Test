using UnityEngine;

public class UI_Animation_Handler : MonoBehaviour
{

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimationChange(string temp)
    {
        animator.SetTrigger(temp);

    }
    public void Deactive() =>Destroy(gameObject);

}
