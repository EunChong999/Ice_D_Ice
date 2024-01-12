using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    public GameObject intro;
    public GameObject howToPlay;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    

    public void Intro()
    {
        intro.SetActive(false);
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
    }

    public void HowToPlayExit()
    {
        howToPlay.SetActive(false);
    }

    public void InGame()
    {
        SceneManager.LoadScene(1);
    }
}
