using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] Transform dice;
    public bool isShapeChanged;
    [SerializeField] int num;
    [SerializeField] Transform referencePoint;
    public float distance;

    private void Update()
    {
        distance = Vector3.Distance(transform.position, referencePoint.position);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            other.transform.GetComponent<Ice>().ChangeBody(num, isShapeChanged);
        }
    }
}
