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
        // 현재 맵 이름을 설정
        textMeshProUGUI.text = mapNames[SceneManager.instance.currentMapIndex - 1];

        // 각 세계의 최고 레벨을 로드
        PlainWorldHighestLevel = PlayerPrefs.GetInt("PlainWorldHighestLevel", 1);
        ForestWorldHighestLevel = PlayerPrefs.GetInt("ForestWorldHighestLevel", 0);
        MountWorldHighestLevel = PlayerPrefs.GetInt("MountWorldHighestLevel", 0);

        // 현재 맵에 따라 레벨 버튼들의 상호작용을 설정
        switch (SceneManager.instance.currentMapIndex)
        {
            case 1:
                // 평원 맵일 때
                for (int i = 0; i < levelButtons.Length; i++)
                {
                    int levelNum = i + 1;
                    if (levelNum > PlainWorldHighestLevel)
                    {
                        // 최고 레벨보다 높은 레벨 버튼 비활성화 및 잠금 이미지 활성화
                        levelButtons[i].interactable = false;
                        lockImgs[i].SetActive(true);
                    }
                    else
                    {
                        // 최고 레벨 이하의 레벨 버튼 활성화 및 잠금 이미지 비활성화
                        levelButtons[i].interactable = true;
                        lockImgs[i].SetActive(false);
                    }
                }
                break;
            case 2:
                // 숲 맵일 때
                for (int i = 0; i < levelButtons.Length; i++)
                {
                    int levelNum = i + 1;
                    if (levelNum > ForestWorldHighestLevel)
                    {
                        // 최고 레벨보다 높은 레벨 버튼 비활성화 및 잠금 이미지 활성화
                        levelButtons[i].interactable = false;
                        lockImgs[i].SetActive(true);
                    }
                    else
                    {
                        // 최고 레벨 이하의 레벨 버튼 활성화 및 잠금 이미지 비활성화
                        levelButtons[i].interactable = true;
                        lockImgs[i].SetActive(false);
                    }
                }
                break;
            case 3:
                // 산악 맵일 때
                for (int i = 0; i < levelButtons.Length; i++)
                {
                    int levelNum = i + 1;
                    if (levelNum > MountWorldHighestLevel)
                    {
                        // 최고 레벨보다 높은 레벨 버튼 비활성화 및 잠금 이미지 활성화
                        levelButtons[i].interactable = false;
                        lockImgs[i].SetActive(true);
                    }
                    else
                    {
                        // 최고 레벨 이하의 레벨 버튼 활성화 및 잠금 이미지 비활성화
                        levelButtons[i].interactable = true;
                        lockImgs[i].SetActive(false);
                    }
                }
                break;
        }
    }
}
