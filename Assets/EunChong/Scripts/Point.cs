using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] Transform dice;
    [SerializeField] bool isShapeChanged;
    [SerializeField] int num;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            other.transform.GetComponent<Ice>().ChangeBody(num - 1, dice.eulerAngles.y);
        }
    }
}
