using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public bool isCollisioning;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Snow") || other.CompareTag("Ice"))
        {
            isCollisioning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Snow") || other.CompareTag("Ice"))
        {
            isCollisioning = false;
        }
    }
}
