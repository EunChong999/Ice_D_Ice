using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkers : MonoBehaviour
{
    [SerializeField] Transform pos;

    private void Start()
    {
        transform.parent = null;
    }

    void Update()
    {
        transform.position = pos.position;
    }
}
