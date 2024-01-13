using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] GameObject body;
    public GameObject[] ices;

    public void ChangeBody(int num)
    {
        Destroy(body);
        body = Instantiate(ices[num], transform.position, ices[num].transform.rotation);
    }
}
