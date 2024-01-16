using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] bool isCompleted;
    [SerializeField] int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point") && isCompleted)
        {
            SceneManager.instance.ToStage(index);
        }
    }


}
