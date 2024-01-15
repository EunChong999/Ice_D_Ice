using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    Animator animator;
    [SerializeField] bool isFadeIn;
    [SerializeField] bool canFadeIn;
    [SerializeField] bool canFadeOut;
    WaitForSeconds fadeTime;

    private void Start()
    {
        animator = GetComponent<Animator>();

        fadeTime = new WaitForSeconds(1);

        FadeIn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isFadeIn)
        {
            FadeIn();
        }

        if (Input.GetKeyDown(KeyCode.X) && isFadeIn)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        if (canFadeIn) 
        {
            animator.SetTrigger("FadeIn");
            StartCoroutine(ResetFadeIn());
            canFadeIn = false;
        }
    }

    IEnumerator ResetFadeIn()
    {
        yield return fadeTime;
        isFadeIn = true;
        canFadeIn = true;
    }

    void FadeOut()
    {
        if (canFadeOut)
        {
            animator.SetTrigger("FadeOut");
            StartCoroutine(ResetFadeOut());
            canFadeOut = false;
        }
    }

    IEnumerator ResetFadeOut()
    {
        yield return fadeTime;
        isFadeIn = false;
        canFadeOut = true;
    }
}
