using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public bool isCleared;
    [SerializeField] bool isFixType;
    [SerializeField] bool isChangedType;
    [SerializeField] float fixNum;
    [SerializeField] GameObject trueMat;
    [SerializeField] GameObject falseMat;
    [SerializeField] GameObject body;
    public GameObject[] ices;
    float angle;

    [SerializeField] GameObject effectMusic;
    AudioSource[] audioSources;

    private void Start()
    {
        audioSources = effectMusic.GetComponents<AudioSource>();
    }

    public void ChangeBody(int num, bool isShapeChanged)
    {
        if (!isFixType) 
        {
            Destroy(body);

            if (isShapeChanged)
            {
                switch (num)
                {
                    case 2:
                        angle = 90;
                        break;
                    case 3:
                        angle = 90;
                        break;
                    case 6:
                        angle = 0;
                        break;
                    default:
                        angle = 0;
                        break;
                }
            }
            else
            {
                switch (num)
                {
                    case 2:
                        angle = 0;
                        break;
                    case 3:
                        angle = 0;
                        break;
                    case 6:
                        angle = 90;
                        break;
                    default:
                        angle = 0;
                        break;
                }
            }

            body = Instantiate(ices[num - 1], transform.position, Quaternion.Euler(transform.eulerAngles.x, angle, transform.eulerAngles.z));
        }
        else
        {
            if (num == fixNum)
            {
                if (isShapeChanged)
                {
                    switch (num)
                    {
                        case 2:
                            if (isChangedType)
                            {
                                audioSources[0].Play();
                                isCleared = true;
                                trueMat.SetActive(true);
                                falseMat.SetActive(false);
                            }
                            else
                            {
                                audioSources[1].Play();
                                isCleared = false;
                                trueMat.SetActive(false);
                                falseMat.SetActive(true);
                            }
                            break;
                        case 3:
                            if (isChangedType)
                            {
                                audioSources[0].Play();
                                isCleared = true;
                                trueMat.SetActive(true);
                                falseMat.SetActive(false);
                            }
                            else
                            {
                                audioSources[1].Play();
                                isCleared = false;
                                trueMat.SetActive(false);
                                falseMat.SetActive(true);
                            }
                            break;
                        case 6:
                            if (isChangedType)
                            {
                                audioSources[1].Play();
                                isCleared = false;
                                trueMat.SetActive(false);
                                falseMat.SetActive(true);
                            }
                            else
                            {
                                audioSources[0].Play();
                                isCleared = true;
                                trueMat.SetActive(true);
                                falseMat.SetActive(false);
                            }
                            break;
                        default:
                            audioSources[0].Play();
                            isCleared = true;
                            trueMat.SetActive(true);
                            falseMat.SetActive(false);
                            break;
                    }
                }
                else
                {
                    switch (num)
                    {
                        case 2:
                            if (isChangedType)
                            {
                                audioSources[1].Play();
                                isCleared = false;
                                trueMat.SetActive(false);
                                falseMat.SetActive(true);
                            }
                            else
                            {
                                audioSources[0].Play();
                                isCleared = true;
                                trueMat.SetActive(true);
                                falseMat.SetActive(false);
                            }
                            break;
                        case 3:
                            if (isChangedType)
                            {
                                audioSources[1].Play();
                                isCleared = false;
                                trueMat.SetActive(false);
                                falseMat.SetActive(true);
                            }
                            else
                            {
                                audioSources[0].Play();
                                isCleared = true;
                                trueMat.SetActive(true);
                                falseMat.SetActive(false);
                            }
                            break;
                        case 6:
                            if (isChangedType)
                            {
                                audioSources[0].Play();
                                isCleared = true;
                                trueMat.SetActive(true);
                                falseMat.SetActive(false);
                            }
                            else
                            {
                                audioSources[1].Play();
                                isCleared = false;
                                trueMat.SetActive(false);
                                falseMat.SetActive(true);
                            }
                            break;
                        default:
                            audioSources[0].Play();
                            isCleared = true;
                            trueMat.SetActive(true);
                            falseMat.SetActive(false);
                            break;
                    }
                }
            }
            else
            {
                audioSources[1].Play();
                isCleared = false;
                trueMat.SetActive(false);
                falseMat.SetActive(true);
            }
        }
    }
}
