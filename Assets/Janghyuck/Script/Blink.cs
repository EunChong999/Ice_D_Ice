using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public GameObject image;
    public float flashInterval = 0.5f;

    private bool isFlashing = false;

    void Start()
    {
        StartFlashing();
    }

    void StartFlashing()
    {
        if (image != null)
        {
            isFlashing = true;
            InvokeRepeating("ToggleFlash", 0f, flashInterval);
        }
        else
        {
            Debug.LogError("Image not assigned!");
        }
    }

    void ToggleFlash()
    {
        if (isFlashing)
        {

            image.SetActive(!image.activeSelf);
        }
    }

    void StopFlashing()
    {
        isFlashing = false;
        image.SetActive(true); 
        CancelInvoke("ToggleFlash");
    }
}
