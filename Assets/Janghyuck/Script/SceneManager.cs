using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public bool isTutorialCompleted;

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
        if (Input.GetKeyDown(KeyCode.Escape) && !FadeEffect.instance.isFading)
        {
            ToTitle();
        }
    }

    //ESC를 눌렀을 때 Title로 이동하는 함수
    public void ToTitle()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
        {
            Cursor.visible = false;

            FadeEffect.instance.FadeOut();

            if (FadeEffect.instance.isFadeIn)
                StartCoroutine(SceneLoad(0));
        }
        else
        {
            Cursor.visible = true;

            Application.Quit();
        }
    }

    public void ToStage(int index)
    {
        FadeEffect.instance.FadeOut();

        if (FadeEffect.instance.isFadeIn)
            StartCoroutine(SceneLoad(index + 1));
    }

    IEnumerator SceneLoad(int index)
    {
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        FadeEffect.instance.FadeIn();
    }
}
