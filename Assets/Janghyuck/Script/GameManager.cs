using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {

    }

    public void ToIntro()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }

    //게임 자체 종료
    public void Exit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
