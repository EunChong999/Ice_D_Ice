using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    public static BtnManager Instance;


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

    public void Title()
    {
        SceneManager.LoadScene(0);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void InGame()
    {
        SceneManager.LoadScene(2);
    }
}
