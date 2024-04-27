using UnityEngine;
using System;

public class SettingPanel : MonoBehaviour
{
    public static SettingPanel Instance;

    [SerializeField] public GameObject setting;

    void Awake()
    {
        if (Instance != null) 
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
        if (Convert.ToBoolean(PlayerPrefs.GetInt("isTutorialCompleted"))) 
        {
            SceneManager.instance.LoadMapScene();
        }
        else
        {
            FadeEffect.instance.FadeOut();

            if (FadeEffect.instance.isFadeIn)
                SceneManager.instance.LoadTutorialScene();
        }
    }
}
