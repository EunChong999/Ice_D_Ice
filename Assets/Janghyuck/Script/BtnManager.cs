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

    public void Tutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
