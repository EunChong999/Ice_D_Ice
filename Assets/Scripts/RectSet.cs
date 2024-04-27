using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectSet : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;

    void Start()
    {
        rectTransform.anchoredPosition = new Vector3(-550, 0, 0);
    }
}
