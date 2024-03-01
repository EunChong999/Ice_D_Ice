using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    public float fadeSpeed;

    [Range(0, 1)]
    public float fadeAmount;

    [Range(0, 1)]
    public float originOpacity;

    Material[] materials = new Material[4];
    public bool doFade = false;
    public bool forceDoFade = false;

    private void Start()
    {
        for (int i = 0; i < GetComponent<Renderer>().materials.Length; i++) 
        {
            materials[i] = GetComponent<Renderer>().materials[i];
        }
    }

    private void Update()
    {
        if (forceDoFade || doFade)
            FadeNow();
        else
            ResetFade();
    }

    void FadeNow()
    {
        foreach (Material mat in materials)
        {
            if (mat != null)
            {
                Color currentColor = mat.color;
                Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
                    Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
                mat.color = smoothColor;
            }
        }
    }

    void ResetFade()
    {
        foreach (Material mat in materials)
        {
            if (mat != null)
            {
                Color currentColor = mat.color;
                Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
                    Mathf.Lerp(currentColor.a, originOpacity, fadeSpeed * Time.deltaTime));
                mat.color = smoothColor;
            }
        }
    }
}
