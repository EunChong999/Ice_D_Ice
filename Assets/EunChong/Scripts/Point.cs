using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isShapeChanged;
    public int num;
    [SerializeField] Transform referencePoint;
    public bool isHidden;
    [SerializeField] GameObject effectMusic;
    AudioSource[] audioSources;

    private void Start()
    {
        audioSources = effectMusic.GetComponents<AudioSource>();
    }

    private void Update()
    {
        isHidden = Vector3.Distance(transform.position, referencePoint.position) > 5;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            other.transform.GetComponent<Ice>().ChangeBody(num, isShapeChanged);
            audioSources[3].Play();
        }

        if (other.CompareTag("Snow"))
        {
            audioSources[4].Play();
        }

        if (other.CompareTag("Dirt"))
        {
            audioSources[2].Play();
        }
    }

    public void FinSound()
    {
        audioSources[5].Play();
    }
}
