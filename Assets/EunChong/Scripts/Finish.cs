using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool isCompleted;
    [SerializeField] int index;
    [SerializeField] Ice[] ices;
    [SerializeField] new ParticleSystem particleSystem;

    public bool isLoading;

    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 1)
        {
            ices = FindObjectsOfType<Ice>();
        }
    }

    bool CheckAllTrue(Ice[] array)
    {
        // 배열 안에 있는 모든 값이 true인지 확인
        foreach (Ice value in array)
        {
            if (!value.isCleared)
            {
                // 하나라도 false가 있으면 false 반환
                return false;
            }
        }
        // 모든 값이 true일 경우 true 반환
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            // 배열 안에 있는 모든 bool 값이 true인지 확인
            if (CheckAllTrue(ices))
            {
                isCompleted = true;
            }
            else
            {
                isCompleted = false;
            }
        }

        if (other.CompareTag("Point") && isCompleted && !isLoading)
        {
            other.GetComponent<Point>().FinSound();

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game Tutorial Scene") 
            {
                SceneManager.instance.LoadMapScene();
            }
            else
            {
                SceneManager.instance.LoadPlayScene(SceneManager.instance.currentStageIndex + 1);

                switch (SceneManager.instance.currentMapIndex)
                {
                    case 1:
                        if (PlayerPrefs.GetInt("PlainWorldHighestLevel", 1) <= SceneManager.instance.currentStageIndex)
                            PlayerPrefs.SetInt("PlainWorldHighestLevel", SceneManager.instance.currentStageIndex);
                        break;
                    case 2:
                        if (PlayerPrefs.GetInt("ForestWorldHighestLevel", 1) <= SceneManager.instance.currentStageIndex - 21)
                            PlayerPrefs.SetInt("ForestWorldHighestLevel", SceneManager.instance.currentStageIndex - 21);
                        break;
                    case 3:
                        if (PlayerPrefs.GetInt("MountWorldHighestLevel", 1) <= SceneManager.instance.currentStageIndex - 42)
                            PlayerPrefs.SetInt("MountWorldHighestLevel", SceneManager.instance.currentStageIndex - 42);
                        break;
                }
            }

            particleSystem.Play();
            PlayerPrefs.SetInt("isTutorialCompleted", 1);  
            isLoading = true;
        }
    }
}
