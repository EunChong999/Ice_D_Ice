using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isShapeChanged;
    public int num;
    [SerializeField] Transform referencePoint;
    public bool isHidden;
    public bool isRolled;
    [SerializeField] GameObject effectMusic;
    [SerializeField] Dice dice;
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

            if (dice.isRolled)
                audioSources[3].Play();

            dice.isRolled = true;
        }

        if (other.CompareTag("Snow"))
        {
            if (dice.isRolled)
                audioSources[4].Play();

            dice.isRolled = true;
        }

        if (other.CompareTag("Dirt"))
        {
            if (dice.isRolled)
                audioSources[2].Play();

            dice.isRolled = true;
        }

        if (other.CompareTag("Fin"))
        {
            dice.isRolled = true;
        }
    }

    public void FinSound()
    {
        if (dice.isRolled)
            audioSources[5].Play();

        dice.isRolled = true;
    }
}
