using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    [SerializeField] public GameObject setting;


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
        SceneManager.LoadScene(1);
    }

    public void StageChoice()
    {
        SceneManager.LoadScene(2);
    }

    public void InGame()
    {
        SceneManager.LoadScene(3);
    }
}
