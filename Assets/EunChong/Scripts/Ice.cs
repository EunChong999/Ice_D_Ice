using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Ice : MonoBehaviour
{
    public bool isCleared;
    [SerializeField] bool isFixType;
    [SerializeField] bool isChangedType;
    [SerializeField] float fixNum;
    [SerializeField] GameObject trueMat;
    [SerializeField] GameObject falseMat;
    public GameObject[] ices;
    float angle;

    GameObject effectMusic;
    AudioSource[] audioSources;

    private void Start()
    {
        effectMusic = GameObject.Find("EffectMusic");
        audioSources = effectMusic.GetComponents<AudioSource>();

        if (transform.rotation.eulerAngles.y != 0) 
        {
            isChangedType = true;
        }
        else
        {
            isChangedType = false;
        }
    }

    public void ChangeBody(int num, bool isShapeChanged)
    {
        if (!isFixType) 
        {
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
