using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnSpace : MonoBehaviour
{
    void Update()
    {
        // 스페이스바를 누르면 다음 씬으로 전환합니다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // 현재 씬의 빌드 인덱스를 가져옵니다.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 다음 씬의 빌드 인덱스를 계산합니다.
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        // 다음 씬으로 전환합니다.
        SceneManager.LoadScene(nextSceneIndex);
    }
}
