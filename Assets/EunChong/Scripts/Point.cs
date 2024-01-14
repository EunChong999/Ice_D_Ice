using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isShapeChanged;
    [SerializeField] int num;
    [SerializeField] Transform referencePoint;
    public bool isHidden;

    private void Update()
    {
        isHidden = Vector3.Distance(transform.position, referencePoint.position) > 5;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            other.transform.GetComponent<Ice>().ChangeBody(num, isShapeChanged);
        }
    }
}
