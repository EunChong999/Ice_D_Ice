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

    public static FadeEffect instance = null;

    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

        fadeTime = new WaitForSeconds(1);

        FadeIn();
    }

    //Scene이 시작할 때(Title빼고)
    public void FadeIn()
    {
        if (canFadeIn && !isFadeIn) 
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

    public void FadeOut()
    {
        if (canFadeOut && isFadeIn)
        {
            animator.SetTrigger("FadeOut");
            StartCoroutine(ResetFadeOut());
            //Scene이동
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
