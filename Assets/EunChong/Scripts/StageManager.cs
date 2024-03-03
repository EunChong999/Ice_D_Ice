using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public string[] mapNames;

    public Button[] levelButtons;
    public GameObject[] lockImgs;
    public int PlainWorldHighestLevel;
    public int ForestWorldHighestLevel;
    public int MountWorldHighestLevel;

    void Start()
    {
        textMeshProUGUI.text = mapNames[SceneManager.instance.currentMapIndex - 1];

        PlainWorldHighestLevel = PlayerPrefs.GetInt("PlainWorldHighestLevel", 1);
        ForestWorldHighestLevel = PlayerPrefs.GetInt("ForestWorldHighestLevel", 1);
        MountWorldHighestLevel = PlayerPrefs.GetInt("MountWorldHighestLevel", 1);

        switch(SceneManager.instance.currentMapIndex)
        {
            case 1:
                for (int i = 0; i < levelButtons.Length; i++)
                {
                    int levelNum = i + 1;
                    if (levelNum > PlainWorldHighestLevel)
                    {
                        levelButtons[i].interactable = false;
                        lockImgs[i].SetActive(true);
                    }
                    else
                    {
                        levelButtons[i].interactable = true;
                        lockImgs[i].SetActive(false);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < levelButtons.Length; i++)
                {
                    int levelNum = i + 1;
                    if (levelNum > ForestWorldHighestLevel)
                    {
                        levelButtons[i].interactable = false;
                        lockImgs[i].SetActive(true);
                    }
                    else
                    {
                        levelButtons[i].interactable = true;
                        lockImgs[i].SetActive(false);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < levelButtons.Length; i++)
                {
                    int levelNum = i + 1;
                    if (levelNum > MountWorldHighestLevel)
                    {
                        levelButtons[i].interactable = false;
                        lockImgs[i].SetActive(true);
                    }
                    else
                    {
                        levelButtons[i].interactable = true;
                        lockImgs[i].SetActive(false);
                    }
                }
                break;
        }
    }
}
