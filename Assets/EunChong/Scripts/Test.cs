using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 originPos;
    [SerializeField] float speed;

    private void Start()
    {
        originPos = transform.position;
    }

    void OnEnable()
    {
        StartCoroutine(move());
    }

    void OnDisable()
    {
        transform.position = originPos;
    }

    IEnumerator move()
    {
        while (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            yield return null;
        }
    }

}
