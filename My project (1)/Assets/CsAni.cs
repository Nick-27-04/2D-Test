using System.Collections;
using UnityEngine;

public class CsAni : MonoBehaviour
{
    Animator animator;

    public AnimationClip clip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

  public void FoxSit()
    {
        animator.SetInteger("any step", 1);
    }

    public void FoxJump()
    {
        animator.SetInteger("any step", 2);

        StartCoroutine(WaitIdle());
    }

    IEnumerator WaitIdle()
    {
        yield return new WaitForSeconds(clip.length);
        animator.SetInteger("any step", 0);
    }

    public void FoxWalk()
    {
        animator.SetInteger("any step", 3);
    }

    public void Fox()
    {
        animator.SetInteger("any step", 1);
    }

}
