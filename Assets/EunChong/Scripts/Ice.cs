using System;
using Unity.VisualScripting;
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

    [SerializeField] MeshFilter[] meshFilters = new MeshFilter[3];
    [SerializeField] MeshRenderer[] meshRenderers = new MeshRenderer[3];
    [SerializeField] IceMaterial[] iceMaterials = new IceMaterial[3];
    [SerializeField] IceMesh[] iceMeshes = new IceMesh[6];

    GameObject effectMusic;
    AudioSource[] audioSources;

    [Serializable]
    struct IceMesh
    {
        public Mesh[] meshes;
    }

    [Serializable]
    struct IceMaterial
    {
        public Material[] materials;
    }

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
        float angle;

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

            ChangeMesh(num);
            ChangeMaterial();
            ChangeAngle(angle);
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

    private void ChangeAngle(float angle)
    {
        body.transform.eulerAngles = new Vector3(-90, angle, 0);
    }

    private void ChangeMesh(int num)
    {
        for (int i = 0; i < meshFilters.Length; i++)
        {
            meshFilters[i].mesh = iceMeshes[num - 1].meshes[i];
        }
    }

    private void ChangeMaterial()
    {
        for (int i = 0; i < meshFilters.Length; i++)
        {
            meshRenderers[i].materials = iceMaterials[i].materials;
        }
    }
}
