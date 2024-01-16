using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    public static BtnManager Instance;
    [SerializeField] bool isTutorialCompleted;

    [SerializeField] public GameObject setting;

    void Awake()
    {
        if(Instance != null)
        {
            Instance = this; 
        }
    }

    public void Setting()
    {
        setting.SetActive(true);
    }

    public void SettingExit()
    {
        setting.SetActive(false);
    }

    public void Tutorial()
    {
        if (isTutorialCompleted) 
        {
            SceneManager.instance.ToStage(1);
        }
        else
        {
            FadeEffect.instance.FadeOut();

            if (FadeEffect.instance.isFadeIn)
                StartCoroutine(SceneLoad());
        }
    }

    IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        FadeEffect.instance.FadeIn();
    }
}
