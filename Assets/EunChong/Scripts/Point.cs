using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] int num;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            Debug.Log("»Æ¿Œ");
            other.transform.GetComponent<Ice>().ChangeBody(num - 1);
        }
    }
}
