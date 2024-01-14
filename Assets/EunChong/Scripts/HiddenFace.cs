using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenFace : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 originPos;
    [SerializeField] float speed;
    Vector3 velocity = Vector3.zero;

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
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, speed * Time.deltaTime);
            yield return null;
        }
    }

}
