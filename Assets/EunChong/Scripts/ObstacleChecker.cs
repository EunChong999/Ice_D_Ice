using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    [SerializeField]
    float distance;
    public Transform referencePoint;
    public ObjectFader[] objectFaders;

    private void Awake()
    {
        objectFaders = FindObjectsOfType<ObjectFader>();
    }

    private void Update()
    {
        foreach (ObjectFader objectFader in objectFaders) 
        {
            if (Vector3.Distance(transform.position, objectFader.transform.position) < distance &&
                Vector3.Distance(objectFader.transform.position, referencePoint.position) < Vector3.Distance(transform.position, referencePoint.position))
            {
                objectFader.doFade = true;
            }
            else
            {
                objectFader.doFade = false;
            }
        }
    }
}
