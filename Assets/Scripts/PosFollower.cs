using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosFollower : MonoBehaviour
{
    [SerializeField] Transform pos;
    [SerializeField] Vector3 offset;
    [SerializeField] bool init;

    private void Start()
    {
        transform.parent = null;

        if (init)
        {
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.identity;
        }
    }

    void Update()
    {
        transform.position = new Vector3(
            pos.position.x + offset.x, 
            pos.position.y + offset.y, 
            pos.position.z + offset.z);
    }
}
