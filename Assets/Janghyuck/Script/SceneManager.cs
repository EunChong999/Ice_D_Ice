using System.Collections;
using System;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public bool isTutorialCompleted;
    public GameObject[] stages;
    public GameObject blockScreen;

    public int currentMapIndex;
    public int currentStageIndex;

    public static SceneManager instance;
    [SerializeField] float fadeTime;
    [SerializeField] float spawnTime;
    WaitForSeconds waitForFadeSeconds;
    WaitForSeconds waitForSpawnSeconds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        PlayerPrefs.SetInt("isTutorialCompleted", Convert.ToInt32(isTutorialCompleted));
        waitForFadeSeconds = new WaitForSeconds(fadeTime);
        waitForSpawnSeconds = new WaitForSeconds(spawnTime);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !FadeEffect.instance.isFading)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game Title Scene")
            {
                Application.Quit();
            }
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game Tutorial Scene")
            {
                LoadTitleScene();
            }
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game Map Scene")
            {
                LoadTitleScene();
            }
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game Stage Scene")
            {
                LoadMapScene();
            }
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game Play Scene")
            {
                LoadStageScene();
            }
        }

        if (FadeEffect.instance.isFading)
        {
            blockScreen.SetActive(true);
        }
        else
        {
            blockScreen.SetActive(false);
        }
    }

    public void LoadTitleScene()
    {
        StartCoroutine(SceneLoad("Game Title Scene"));
    }

    public void LoadTutorialScene()
    {
        StartCoroutine(SceneLoad("Game Tutorial Scene"));
    }

    public void LoadMapScene()
    {
        StartCoroutine(SceneLoad("Game Map Scene"));
    }

    public void LoadStageScene()
    {
        StartCoroutine(SceneLoad("Game Stage Scene"));
    }

    public void LoadPlayScene(int index)
    {
        if (index <= stages.Length) 
        {
            currentStageIndex = index;
            StartCoroutine(SceneLoad("Game Play Scene"));
            StartCoroutine(StageSpawn(currentStageIndex));
        }
        else
        {
            LoadStageScene();
        }
    }

    IEnumerator SceneLoad(string name)
    {
        FadeEffect.instance.FadeOut();

        yield return waitForFadeSeconds;

        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        FadeEffect.instance.FadeIn();
    }

    IEnumerator StageSpawn(int index)
    {
        yield return waitForSpawnSeconds;
        Instantiate(stages[index - 1], transform.position, Quaternion.identity);
    }
}
