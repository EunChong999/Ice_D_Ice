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

            if (index == 0) 
            {
                SceneManager.instance.ToTitle();
            }
            else
            {
                SceneManager.instance.ToStage(index);
            }

            particleSystem.Play();
            SceneManager.instance.isTutorialCompleted = true;
            isLoading = true;
        }
    }
}
