using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    [SerializeField] int index;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        index += ((SceneManager.instance.currentMapIndex - 1) * 21);
        SceneManager.instance.LoadPlayScene(index);
    }
}
