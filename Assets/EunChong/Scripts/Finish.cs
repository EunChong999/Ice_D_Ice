using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] bool isCompleted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point") && isCompleted)
        {
            FadeEffect.instance.FadeOut();
        }
    }
}
