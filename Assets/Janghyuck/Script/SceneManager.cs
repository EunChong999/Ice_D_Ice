using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void Update()
    {
        Exit();
    }

    //ESC를 눌렀을 때 Title로 이동하는 함수
    public void Exit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FadeEffect.instance.FadeOut();
            StartCoroutine(SceneLoad());

            FadeEffect.instance.FadeIn();
            Debug.Log("ddas");
        }
    }

    IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
